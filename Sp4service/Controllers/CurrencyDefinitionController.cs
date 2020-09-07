using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sp4service.dao;
using Sp4service.Vo;
namespace Sp4service.Controllers
{
    [Route("api/[controller]")]
    public class CurrencyDefinitionController
    {
        private readonly CurrencyDefinitionDao CurrencyDefinitionDao;
        public CurrencyDefinitionController(CurrencyDefinitionDao dataAccessProvider)
        {
            CurrencyDefinitionDao = dataAccessProvider;
        }
        
        [HttpGet("list")]
        public List<CurrencyDefinition> Get()
        {
            return CurrencyDefinitionDao.CurrencyDefinitionList();
        }
    }
}