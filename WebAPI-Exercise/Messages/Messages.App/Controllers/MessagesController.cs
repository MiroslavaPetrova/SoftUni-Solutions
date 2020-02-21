using Messages.App.Models;
using Messages.Data;
using Messages.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messages.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : Controller
    {
        private readonly MessagesDbContext context;

        public MessagesController(MessagesDbContext context)
        {
            this.context = context;
        }

        [HttpPost(Name = "Create")]
        [Route("Create")]
        public async Task<ActionResult> Create(MessagesCreateInputModel inputModel)
        {
            Message message = new Message
            {
                Content = inputModel.Content,
                User = inputModel.User,
                CreatedOn = DateTime.UtcNow
            };

            await this.context.Messages.AddAsync(message);
            await this.context.SaveChangesAsync();

            return this.Ok();
        }

        [HttpGet(Name = "All")]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<Message>>> AllOrderedByCreatedOnAscending()
        {
            return this.context
                   .Messages
                   .OrderBy(m => m.CreatedOn)
                   .ToList();
        }
    }
}
