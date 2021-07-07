using DateTimeManagement.Core;
using DateTimeManagement.Infra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateTimeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IANADateController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public IANADateController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public Operation Get(long id)
        {
            return dbContext.MonEntittyWithIANADateTimes.Single(i => i.Id == id);
        }

        [HttpPost("filter")]
        public List<Operation> Filter([FromBody] IANADateTime startDate)
        {
            return dbContext.MonEntittyWithIANADateTimes.Where(i => i.BilingDate.OffsetUTC >= startDate.OffsetUTC).ToList();
        }

        [HttpPost]
        public void Add(Operation entity)
        {
            dbContext.Add(entity);

            dbContext.SaveChanges();
        }
    }
}
