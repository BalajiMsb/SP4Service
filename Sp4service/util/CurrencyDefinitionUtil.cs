using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System;
using Npgsql;
using Sp4service.vo;
using Sp4service.dao;
namespace Sp4service.util
{
    public class CurrencyDefinitionUtil
    {
        private readonly string _connectionString;
        private readonly CurrencyDefinitionDao CurrencyDefinitionDao;
        string CONNECTION_STRING="Host=172.16.14.17;Port=5432;User ID=allsecit;Password=Allsec@123;Database=payroll_allsec;Pooling=true;";
        public CurrencyDefinitionUtil(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
            _connectionString = CONNECTION_STRING;
        }

        public List<CurrencyDefinition> CurrencyDefinitionListSuccess()
        {
            try
            {
               return CurrencyDefinitionDao.getCurrencyDefinitionList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}