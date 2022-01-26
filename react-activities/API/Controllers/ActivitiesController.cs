using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext context;
        public ActivitiesController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Domain.Activity>>> GetActivities()
        {
            return await context.Activities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Activity>> GetActivity(Guid id)
        {
            return await context.Activities.FindAsync(id);
        }
    }
}