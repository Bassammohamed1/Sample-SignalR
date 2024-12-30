using Microsoft.AspNetCore.SignalR;
using SampleSignalR.Data;

namespace SampleSignalR.Hubs
{
    public class ChatHub : Hub
    {
        AppDbContext db;
        public ChatHub(AppDbContext db)
        {
            this.db = db;
        }
        public void sendmessage(string name, string message)
        {
            //save message in DB.

            //broadcasting to all online clients.
            Clients.All.SendAsync("newmessage", name, message);
        }
        public void joingroup(string name, string groupname)
        {
            //checks if the group exists or no if no, add the group to the groups table.
            //save the groupId and the userId in table UserGroups.
            //Add the connectionId to group.
            Groups.AddToGroupAsync(Context.ConnectionId, groupname);

            //broadcasting to all group members.
            Clients.OthersInGroup(groupname).SendAsync("newmember", $"{name} has joined {groupname}");

            //broadcasting to caller.
            Clients.Caller.SendAsync("newmember", $"Welcome {name}!!");
        }

        public void sendtogroup(string name, string groupname, string message)
        {
            //broadcasting to all group members.
            Clients.Group(groupname).SendAsync("newgroupmessage", name, groupname, message);
        }

        public override Task OnConnectedAsync()
        {
            //save the userId and connectionId in Db.
            //check with userId in table UserGroups and if userId exists add the new connectionId to tha group.

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            //remove the userId and connectionId from Db.
            return base.OnDisconnectedAsync(exception);
        }

    }
}
