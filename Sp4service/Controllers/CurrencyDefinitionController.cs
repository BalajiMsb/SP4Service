using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sp4service.service;
using Sp4service.vo;
namespace Sp4service.controllers
{
    [Route("api/[controller]")]
    public class CurrencyDefinitionController
    {
        CurrencyDefinitionService CurrencyDefinitionService=new CurrencyDefinitionService();
        public CurrencyDefinitionController(CurrencyDefinitionService dataAccessProvider)
        {
            CurrencyDefinitionService = dataAccessProvider;
        }
        
        [HttpGet("list")]
        public List<CurrencyDefinition> Get()
        {
            return CurrencyDefinitionService.CurrencyDefinitionSevice();
        }
    }
}