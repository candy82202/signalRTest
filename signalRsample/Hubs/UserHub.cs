using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
namespace signalRsample.Hubs
{
    public class UserHub:Hub
    {
        public static int TotalViews { get; set; } =0;
        public static int TotalUsers { get; set; } = 0;
        public override Task OnConnectedAsync()
        {
            TotalUsers++;
           Clients.All.SendAsync("updateTotalUsers", TotalUsers).GetAwaiter().GetResult();
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            TotalUsers--;
            Clients.All.SendAsync("updateTotalUsers", TotalUsers).GetAwaiter().GetResult();
            return base.OnDisconnectedAsync(exception);
        }
        public async Task<string> NewWindowLoaded()
        { 
        TotalViews++;
            //寄送給所有客戶更新的總觀看次數
            await Clients.All.SendAsync("updateTotalViews", TotalViews);
            return $"total views - {TotalViews}";
        }
    }
}
