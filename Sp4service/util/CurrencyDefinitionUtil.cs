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
               var response =CurrencyDefinitionDao.getCurrencyDefinitionList();
               return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}