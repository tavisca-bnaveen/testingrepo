using MySql.Data.MySqlClient;
using nextgen_call_tracking_system.DAL.DatabaseModels;
using nextgen_call_tracking_system.DAL.Translators.ReportTranslators;
using nextgen_call_tracking_system.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nextgen_call_tracking_system.DAL.DatabaseService
{
    public class SqlServices : IStore
    {
        IDbConfiguration _configuration;
        private MySqlConnection _mySqlConnection;
        private MySqlCommand _mySqlCommand;
        private string _connection;
        private IReportTranslator _reportTranslator;
        public SqlServices(IDbConfiguration configuration)
        {
            _configuration = configuration;
            _connection = _configuration.GetConnection();
            _mySqlConnection = new MySqlConnection(_connection);
            _mySqlCommand = _mySqlConnection.CreateCommand();
            _reportTranslator = new ReportTranslator();
        }
        public async Task<List<Report>> GenerateReports(string StartTime, string EndTime)
        {
            var dataReports = new List<DataReport>();
            try
            {
                _mySqlConnection.Open();
                _mySqlCommand.CommandText = "call generate_report('" + StartTime+"','"+EndTime+"')";
                var reader = await _mySqlCommand.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    int Count = 0;
                    while (reader.Read())
                    {
                        dataReports.Add(new DataReport
                        {
                            Id = ++Count,
                            EmployeeId = reader["EmployeeCode"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            CallsInitiated = int.Parse(reader["CallInitiated"].ToString()),
                            CallsAcknowledged = int.Parse(reader["CallAcknowledged"].ToString()),
                            HoursOnSupport = double.Parse(reader["TotalHoursOnSupport"].ToString())
                        });
                    }
                }
            }
            finally
            {
                _mySqlConnection.Close();
            }
            return await _reportTranslator.ConvertDataToReport(dataReports);
        }

        public async Task<string> CheckAuthenticatedUser(UserCredentials credentials)
        {
            var response = "";
            _mySqlCommand.CommandText = "call login('"+credentials.UserId+"','"+credentials.Password+"','"+credentials.Role+"')";
        /*    _mySqlCommand.CommandText = "call checkUser(?UserId,?password,?role)";
            _mySqlCommand.Parameters.Add(new MySqlParameter("UserId", credentials.UserId));
            _mySqlCommand.Parameters.Add(new MySqlParameter("password", credentials.Password));
            _mySqlCommand.Parameters.Add(new MySqlParameter("role", credentials.Role));
        */    try
            {
                await _mySqlConnection.OpenAsync();
                var reader = await _mySqlCommand.ExecuteReaderAsync();
                response = await reader.ReadAsync() ? "Login successfull" : "Invalid UserId or Password";
            }
            catch (Exception ex)
            {
                response = "Login Unsuccessfull due to error: " + ex.Message;
            }
            finally
            {
                _mySqlConnection.Close();
            }
            return response;
        }

        public async Task<string> CheckUserWithAUserIdExists(string userId)
        {
            var response = "";
            _mySqlCommand.CommandText = "call forgot_password('"+userId+"')";
            //_mySqlCommand = new MySqlCommand(query, _mySqlConnection);
            //_mySqlCommand.Parameters.Add(new MySqlParameter("UserId", userId));

            try
            {
                _mySqlConnection.Open();
                var reader = _mySqlCommand.ExecuteReader();
                response = await reader.ReadAsync() ? "User Exists" : "User Does Not Exists";
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            finally
            {
                _mySqlConnection.Close();
            }
            return response;
        }

        public async Task<string> UpdatePasswordInDatabase(UserCredentials credentials)
        {
            var response = "";
            _mySqlCommand.CommandText = "call update_login_details('"+credentials.UserId+"','"+credentials.Password+"')";
            //_mySqlCommand = new MySqlCommand(query, _mySqlConnection);
            //_mySqlCommand.Parameters.Add(new MySqlParameter("UserId", credentials.UserId));
            //_mySqlCommand.Parameters.Add(new MySqlParameter("password", credentials.Password));
            try
            {
                _mySqlConnection.Open();
                await _mySqlCommand.ExecuteNonQueryAsync();
                response = "successfully updated";
            }
            catch (Exception ex)
            {
                response = "cannot update due to error: " + ex.Message;
            }
            finally
            {
                _mySqlConnection.Close();
            }
            return response;
        }
    }
}
