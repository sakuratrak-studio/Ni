using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aiursoft.Pylon.Attributes;
using Aiursoft.Pylon.Exceptions;
using Aiursoft.Pylon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ni.Data;
using Ni.Models;

namespace Ni.Controllers
{
    [APIModelStateChecker]
    public class CommentController : Controller
    {
        private readonly NiDbContext _dbContext;

        public CommentController(NiDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IActionResult> ViewComments(Guid websiteId)
        {
            var website = await _dbContext.NiWebsites
                .Include(t => t.Comments)
                .Where(t => t.Id == websiteId)
                .SingleOrDefaultAsync();
            return Json(new AiurValue<IEnumerable<NiComment>>(website.Comments));

        }
    }
}
