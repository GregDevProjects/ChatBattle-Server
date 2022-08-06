using chat.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);

        }

        public async Task CountDown()
        {
            await SendMessage("CountDown Started");
            new SecondsTimer(5, () => {
                Console.WriteLine("finished");
                //SendMessage("hi");
            }, 
            () => {
                Console.WriteLine("tick");
               // SendMessage("hi");
            }
            );
        }
    }
}