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
        CurrencyDefinitionUtil CurrencyDefinitionUtil=new CurrencyDefinitionUtil();
        public List<CurrencyDefinition> CurrencyDefinitionSevice()
        {
            try
            {
                List<CurrencyDefinition> List=new List<CurrencyDefinition>();
                List= CurrencyDefinitionUtil.CurrencyDefinitionListSuccessMessage();
                return List;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}