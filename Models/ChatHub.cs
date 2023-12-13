using Microsoft.AspNetCore.SignalR;
using SignalR.Models;

namespace WebApplication1.Models
{
    public class ChatHub : Hub
    {
        private readonly Context _context;

        public ChatHub(Context context)
        {
            _context = context;
        }

        public async Task sendMessage(string from, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", from, message);

            Chat data = new Chat()
            {
                Message = message,
                Name = from
            };
            await _context.Chats.AddAsync(data);
            _context.SaveChanges();
        }
    }
}
