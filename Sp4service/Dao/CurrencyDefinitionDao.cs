using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System;
using Npgsql;
using Sp4service.Vo;
using Sp4service.util.Common;
namespace Sp4service.dao
{
    public class CurrencyDefinitionDao
    {
        private readonly string _connectionString;
        string CONNECTION_STRING="Host=172.16.14.17;Port=5432;User ID=allsecit;Password=Allsec@123;Database=payroll_allsec;Pooling=true;";
        public CurrencyDefinitionDao(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
            _connectionString = CONNECTION_STRING;
        }

        public List<CurrencyDefinition> getCurrencyDefinitionList()
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
                    response.Add(MapCurrencyDefValue(reader));
                }
                con.Close();

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
    }
}