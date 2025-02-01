using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Concurrent;

public class VoiceChatHub : Hub
{
    private static readonly ConcurrentDictionary<string, string> _userConnections = new();

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var user = _userConnections.FirstOrDefault(x => x.Value == Context.ConnectionId);
        if (user.Key != null)
        {
            _userConnections.TryRemove(user.Key, out _);
        }
        await base.OnDisconnectedAsync(exception);
    }

    public async Task RegisterUser(string userId)
    {
        _userConnections[userId] = Context.ConnectionId;
    }

    public async Task CallUser(string targetUserId)
    {
        if (_userConnections.TryGetValue(targetUserId, out var targetConnectionId))
        {
            await Clients.Client(targetConnectionId).SendAsync("IncomingCall", Context.ConnectionId);
        }
    }

    public async Task AcceptCall(string callerId)
    {
        if (_userConnections.TryGetValue(callerId, out var callerConnectionId))
        {
            await Clients.Client(callerConnectionId).SendAsync("CallAccepted", Context.ConnectionId);
        }
    }

    public async Task RejectCall(string callerId)
    {
        if (_userConnections.TryGetValue(callerId, out var callerConnectionId))
        {
            await Clients.Client(callerConnectionId).SendAsync("CallRejected");
        }
    }

    public async Task SendOffer(string targetConnectionId, string sdp)
    {
        await Clients.Client(targetConnectionId).SendAsync("ReceiveOffer", Context.ConnectionId, sdp);
    }

    public async Task SendAnswer(string targetConnectionId, string sdp)
    {
        await Clients.Client(targetConnectionId).SendAsync("ReceiveAnswer", Context.ConnectionId, sdp);
    }

    public async Task SendIceCandidate(string targetConnectionId, string candidate)
    {
        await Clients.Client(targetConnectionId).SendAsync("ReceiveIceCandidate", Context.ConnectionId, candidate);
    }
}
