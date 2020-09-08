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
        private readonly CurrencyDefinitionDao CurrencyDefinitionDao=null;
        public List<CurrencyDefinition> CurrencyDefinitionListSuccessMessage()
        {
            try
            {
               List<CurrencyDefinition> List= CurrencyDefinitionDao.getCurrencyDefinitionList();
               return List;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}