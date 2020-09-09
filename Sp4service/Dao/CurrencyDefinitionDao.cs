using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System;
using Npgsql;
using Sp4service.vo;
using Sp4service.util.Common;
using MySql.Data.MySqlClient;
namespace Sp4service.dao
{
    public class CurrencyDefinitionDao
    {
        private readonly string _connectionString;

        string CONNECTION_STRING_POSTGRESQL=ServiceNameConstants.CONNECTION_STRING_POSTGRESQL;
        // public CurrencyDefinitionDao(IConfiguration configuration)
        // {
        //     _connectionString = configuration.GetConnectionString("defaultConnection");
        //     _connectionString = CONNECTION_STRING_POSTGRESQL;
        // }

        public List<CurrencyDefinition> getCurrencyDefinitionList()
        {
            Console.WriteLine("here");
            try
            {
                var sqls="Mysql";
                var response = new List<CurrencyDefinition>();
                if(sqls == "postgresql"){
                    var cs =CONNECTION_STRING_POSTGRESQL;
                    using var con = new NpgsqlConnection(cs);
                    con.Open();
                    var xmlquery="SELECT * FROM currencyDefinition";
                    using var cmd = new NpgsqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText =xmlquery;
                    NpgsqlDataReader reader =cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        response.Add(MapCurrencyDefValue(reader));
                    }
                    con.Close();
                }else{
                    string MyConnection2 = ServiceNameConstants.CONNECTION_STRING_MYSQL;  
                    string Query = "DELETE FROM testtable WHERE ID='1';";  
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);  
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);  
                    MySqlDataReader MyReader2;  
                    MyConn2.Open();  
                    MyReader2 = MyCommand2.ExecuteReader();
                }
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        private CurrencyDefinition MapCurrencyDefValue(NpgsqlDataReader reader)
        {
            return new CurrencyDefinition()
            {
                CurrencyId = (int)reader[CurrencyDefinitionProperties.CurrencyId],
                Code = reader[CurrencyDefinitionProperties.CurrencyCode].ToString(),
                Name = reader[CurrencyDefinitionProperties.Name].ToString(),
                CountryImage = reader[CurrencyDefinitionProperties.Name].ToString(),
                Status = reader[CurrencyDefinitionProperties.Status].ToString(),
                createdBy = reader[CurrencyDefinitionProperties.CreatedBy].ToString(),
                createdDate = reader[CurrencyDefinitionProperties.CreatedDate].ToString(),
                updatedBy = reader[CurrencyDefinitionProperties.UpdatedBy].ToString(),
                updatedDate = reader[CurrencyDefinitionProperties.UpdateDate].ToString()
            };
        }

        // private CurrencyDefinition MapCurrencyDefValue1(MySqlDataReader reader)
        // {
        //     return new CurrencyDefinition()
        //     {
        //         CurrencyId = (int)reader[CurrencyDefinitionProperties.CurrencyId],
        //         Code = reader[CurrencyDefinitionProperties.CurrencyCode].ToString(),
        //         Name = reader[CurrencyDefinitionProperties.Name].ToString(),
        //         CountryImage = reader[CurrencyDefinitionProperties.Name].ToString(),
        //         Status = reader[CurrencyDefinitionProperties.Status].ToString(),
        //         createdBy = reader[CurrencyDefinitionProperties.CreatedBy].ToString(),
        //         createdDate = reader[CurrencyDefinitionProperties.CreatedDate].ToString(),
        //         updatedBy = reader[CurrencyDefinitionProperties.UpdatedBy].ToString(),
        //         updatedDate = reader[CurrencyDefinitionProperties.UpdateDate].ToString()
        //     };
        // }
    }
}