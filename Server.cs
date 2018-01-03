using System;
using System.Collections.Generic;
using System.Text;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace Server
{
    public class Server : BaseScript
    {
        public Server()
        {
            EventHandlers["onResourceStart"] += new Action(OnResource);
            EventHandlers["onPlayerKilled"] += new Action<Player, Player>(OnPlayerKilled);
        }

        public void OnPlayerKilled( Player DeadPlayer, Player Killer )
        {
            Debug.Write("[DEBUG] Triggered onPlayerKilled *\n");
            TriggerClientEvent(Killer, "onAssasinate", DeadPlayer);
        }

        public void OnResource()
        {
            Debug.Write("[Debug] Started resource *\n");
        }
    }
}
