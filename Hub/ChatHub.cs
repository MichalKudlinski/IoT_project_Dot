using mkproject.Models;
using mkproject.DB;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace mkproject.Hub
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly MessageDb _dbContext;

        public ChatHub(MessageDb dbContext)
        {
            _dbContext = dbContext;
        }

        public const string ReceiveMessage = "ReceiveMessage";

        public async Task SendMessage(ChatMessage msg)
        {
            _dbContext.ChatMessages.Add(msg);
            await _dbContext.SaveChangesAsync();

            await Clients.All.SendAsync(ReceiveMessage, msg);
        }
    }
}
