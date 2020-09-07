using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System;
using Npgsql;
using Sp4service.vo;
using Sp4service.util;
namespace Sp4service.service
{
    public class CurrencyDefinitionService
    {
        private readonly CurrencyDefinitionUtil CurrencyDefinitionUtil;
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