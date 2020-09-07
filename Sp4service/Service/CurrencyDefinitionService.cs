using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System;
using Npgsql;
using Sp4service.Vo;
using Sp4service.Common;
using Sp4service.util;
namespace Sp4service.Service
{
    public class CurrencyDefinitionService
    {
        private readonly string _connectionString;
        private readonly CurrencyDefinitionUtil CurrencyDefinitionUtil;
        string CONNECTION_STRING="Host=172.16.14.17;Port=5432;User ID=allsecit;Password=Allsec@123;Database=payroll_allsec;Pooling=true;";
        public CurrencyDefinitionService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
            _connectionString = CONNECTION_STRING;
        }

        public List<CurrencyDefinition> CurrencyDefinitionList()
        {
            try
            {
                return CurrencyDefinitionUtil.CurrencyDefinitionListSuccess();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}