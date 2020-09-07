using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System;
using Npgsql;
using Sp4service.Vo;
namespace Sp4service.Dao
{
    public class CurrencyDefinitionDao
    {
        private readonly string _connectionString;
        //pgsqlDbOperations db = new pgsqlDbOperations();
        //xmlOperations xml = new xmlOperations();
        //CommonUtil common=new CommonUtil();
        string CONNECTION_STRING="Host=172.16.14.17;Port=5432;User ID=allsecit;Password=Allsec@123;Database=payroll_allsec;Pooling=true;";
        public CurrencyDefinitionDao(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
            _connectionString = CONNECTION_STRING;
        }

        public List<CurrencyDefinition> CurrencyDefinitionList()
        {
            try
            {
                var response = new List<CurrencyDefinition>();
                var cs =CONNECTION_STRING;
                using var con = new NpgsqlConnection(cs);
                con.Open();
                var xmlquery="SELECT * FROM currencyDefinition";
                using var cmd = new NpgsqlCommand();
                cmd.Connection = con;
                cmd.CommandText =xmlquery;
                NpgsqlDataReader reader =cmd.ExecuteReader();
                while (reader.Read())
                {
                    //response.Add(MapCurrencyDefValue(reader));
                }
                con.Close();

                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}