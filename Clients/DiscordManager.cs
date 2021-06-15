using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiscordRPC;

namespace TimeNow.Clients
{
    public class DiscordManager
    {
        public const string APPLICATION_ID = "851813873936760892";

        public static DiscordRpcClient Client { get; private set; }
        public static bool IsRunning { get; private set; }

        public static bool Initialize()
        {
            Client = new DiscordRpcClient(APPLICATION_ID);
            var isInitialized = Client.Initialize();

            if (!isInitialized)
            {
                Dispose();
                return false;
            }

            Client.SetPresence(new RichPresence
            {
                Assets = new Assets
                {
                    LargeImageKey = "studying"
                },
                Timestamps = new Timestamps(DateTime.UtcNow)
            });
            IsRunning = true;

            return true;
        }

        public static void Dispose()
        {
            Client.Dispose();
            Client = null;

            IsRunning = false;
        }
    }
}
