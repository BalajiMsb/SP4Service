using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sp4service.Service;
using Sp4service.Vo;
namespace Sp4service.Controllers
{
    [Route("api/[controller]")]
    public class CurrencyDefinitionController
    {
        private readonly CurrencyDefinitionService CurrencyDefinitionService;
        public CurrencyDefinitionController(CurrencyDefinitionService dataAccessProvider)
        {
            CurrencyDefinitionService = dataAccessProvider;
        }
        
        [HttpGet("list")]
        public List<CurrencyDefinition> Get()
        {
            return CurrencyDefinitionService.CurrencyDefinitionList();
        }
    }
}