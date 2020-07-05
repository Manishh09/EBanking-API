using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EBanking.API.Service.App_Code
{
    public static class SqlConnectionFactory
    {
        public static SqlConnection GetConnection(string connectionString, string identityEndpoint, string environment)
        {
            //Use sql connection string builder to build the connection string with Data Source Name and Database Name only.
            //var connectionStringBuilder = new SqlConnectionStringBuilder();
            //connectionStringBuilder.DataSource = dataSourceName;
            //connectionStringBuilder.InitialCatalog = dbName;
            var sqlConnection = new SqlConnection(connectionString);
            if (environment.ToUpper() != "LOCAL")
            {
                sqlConnection.AccessToken = GetMSIAccessToken(identityEndpoint);
            }
            return sqlConnection;
        }

        public static string GetMSIAccessToken(string identityEndpoint)
        {
            //call the api endpoint (identityEndpoint) to get the access token.
            try
            {
                using (var webclient = new HttpClient())
                {
                    //specify the web request as Metadata 
                    webclient.DefaultRequestHeaders.Add("Metadata", "true");
                    var result = webclient.GetAsync(identityEndpoint).GetAwaiter().GetResult();
                    result.EnsureSuccessStatusCode();
                    if (result == null)
                    {
                        return string.Empty;
                    }
                    var stringResult = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    if (string.IsNullOrEmpty(stringResult))
                    {
                        return string.Empty;
                    }
                    dynamic jsonResponse = JsonConvert.DeserializeObject(stringResult);
                    //return access token if its not null.
                    return jsonResponse.access_token == null ? string.Empty : string.IsNullOrEmpty(jsonResponse.access_token.Value) ? string.Empty : jsonResponse.access_token.Value;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
