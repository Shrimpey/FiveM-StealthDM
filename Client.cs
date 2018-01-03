using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace Client
{
    public class Client : BaseScript
    {
        //Assasination target information
        private Ped assasinationTarget;
        private String assasinationTargetName;

        private bool canGetTarget = true;

        //For randomizing models
        Random rnd = new Random();

        //Possible random model hashes
        private uint[] models = {
             0x5442C66B,
             0x55446010,
             0xB564882B,
             0x4BA14CCA,
             0x80E59F2E,
             0xD172497E,
             0x5D71A46F,
             0x62018559,
             0x9E08633D,
             0xDE9A30A,
             0xF1E823A2,
             0xFDA94268,
             0xC54E878A,
             0xE7714013,
             0x95C76ECD,
             0x63858A4A,
             0x62CC28E2,
             0xB2273D4E,
             0x40EABE3,
             0xF06B849D,
             0x68709618,
             0xF42EE883,
             0x231AF63F,
             0x158C439C,
             0x23B88069,
             0xE5A11106,
             0x780C01BD,
             0x4A8E5536,
             0xB4A6862,
             0x303638A7,
             0xC79F6928,
             0x403DB4FD,
             0x8427D398,
             0xD1FEB884,
             0x787FA588,
             0x23C7DC11,
             0xE7A963D9,
             0x7E0961B8,
             0xCA56FA52,
             0xBE086EFD,
             0x445AC854,
             0x54DBEE1F,
             0x76284640,
             0xA039335F,
             0x5C2CF7F8,
             0x3FB5C3D3,
             0x668BA707,
             0x20C8012F,
             0x36DF2D5D,
             0xB3F3EE34,
             0x7A05FA59,
             0x3BD99114,
             0x9FD4292D,
             0x379F9596,
             0xD8F9CD47,
             0x9AD32FE9,
             0x2799EFD8,
             0x7E6A64B7,
             0xC99F21C4,
             0x1FC37DBC,
             0x31430342,
             0xB3B3F5E6,
             0xAE86FDB4,
             0xA1435105,
             0xB7C61032,
             0xAD9EF1BB,
             0xF977CEB,
             0x2EFEAFD5,
             0xF6157D8F,
             0xB9DD0300,
             0x106D9A99,
             0x7E4F763F,
             0xFF71F826,
             0x625D6958,
             0x4498DDE,
             0x1A021B83,
             0xD7DA9E99,
             0xC5FEFADE,
             0x15F8700D,
             0x5E3DA4A4,
             0xFDC653C7,
             0xE497BBEF,
             0x9B557274,
             0xFF3E88AB,
             0x14D7B4E0,
             0x867639D1,
             0xD47303AC,
             0x22911304,
             0x654AD86E,
             0x2DADF4AA,
             0x75D30A91,
             0xF5908A06,
             0x9D3DCB7A,
             0xF5B0079D,
             0xF9A6F53F,
             0xA4471173,
             0x63C8D891,
             0x438A4AE,
             0x7DD91AC,
             0x168775F6,
             0x51C03FA4,
             0x689C2A80,
             0x77D41A3E,
             0xAA82FF9B,
             0x69F46BF3,
             0x4163A158,
             0xE83B93B7,
             0xDB729238,
             0x84302B09,
             0x4E0CE5D3,
             0x94562DD7,
             0xFAB48BCB,
             0xB5CF80E4,
             0x61D201B3,
             0x38BAD33B,
             0x163B875B,
             0xEDBC7546,
             0x26F067AD,
             0xB6B1EDA8,
             0x457C64FB,
             0x13C4818C,
             0xA956BD9E,
             0xEE75A00F,
             0x49EA5685,
             0xD1CCE036,
             0xA5720781,
             0x6DD569F,
             0x13AEF042,
             0x2F4AEC3E,
             0x61C81C85,
             0xAD54E7A8,
             0x9877EF71,
             0x3521A8D2,
             0x1880ED06,
             0x7DD8FB58,
             0xA9EB0E42,
             0xD71FE131,
             0x309E7DEA,
             0x418DFF92,
             0x6BD9B68C,
             0xE16D8F01,
             0xF161D212,
             0x2930C1AB,
             0x30830813,
             0x50F73C0C,
             0x6C9B2849,
             0x7B0E452F,
             0x1475B827,
             0x7D03E617,
             0x8247D331,
             0x2307A353,
             0x97F5FE8D,
             0x14D506EE,
             0xA5BA9A16,
             0x4E4179C6,
             0x199881DC,
             0x28ABF95,
             0x14C3E407,
             0x31640AC,
             0x739B1EF5,
             0xBAD7BB80,
             0x92D9CC1,
             0xDDCAAA2C,
             0x2A22FBCE,
             0xA96BD9EC,
             0x2DB7EEF3,
             0xDB134533,
             0x91CA3E2C,
             0x352A026F,
             0x247502A9,
             0x8FEDD989,
             0x7CCBE17A,
             0x52C824DE,
             0x47CF5E96,
             0xD15D7E71,
             0x1536D95A,
             0x1AF6542C,
             0x41018151,
             0x297FF13F,
             0x9E80D2CE,
             0x132C1A8E,
             0xDE0077FD,
             0xDB9C0997,
             0xFD5537DE,
             0x4F46D607,
             0x3D843282,
             0x32B11CDC,
             0x765AAAE4,
             0xE093C5C6,
             0x2FDE6EB7,
             0x7EA4FFA6,
             0xF2DAA2ED,
             0x65793043,
             0xF0259D83,
             0x58D696FE,
             0x72C0CAD2,
             0x696BE0A9,
             0x5761F4AD,
             0x4914D813,
             0xDD817EAD,
             0xBDDD5546,
             0x26EF3426,
             0x31A3498E,
             0x964D12DC,
             0xB25D16B2,
             0x3053E555,
             0xD55B2BF5,
             0xED0CE4C6,
             0x3CDCA742,
             0x64FDEA7D,
             0x77AC8FDA,
             0x64611296,
             0x2300C816,
             0xD85E6D28,
             0xE7B31432,
             0x4B652906,
             0xC923247C,
             0x681BD012,
             0xECCA8C15,
             0xB353629E,
             0x48114518,
             0xE75B4B1C,
             0xAB300C07,
             0xF63DE8E1,
             0x4F3FBA06,
             0xA2E86156,
             0xA9D9B69E,
             0x8384FC9F,
             0x62599034,
             0x7367324F,
             0x56C96FC6,
             0x5F2113A1,
             0xB1BB9B59,
             0x169BD1E1,
             0x9712C38F,
             0x9FC7F637,
             0xEF7135AE,
             0xF561A4C6,
             0xC05E1399,
             0x3C438CD2,
             0xC7496729,
             0x25305EEE,
             0x843D9D0F,
             0x3F789426,
             0x3BAD4184,
             0xDE0E0969,
             0xCCFF7D8A,
             0x4F2E038A,
             0x20208E4D,
             0xD7606C30,
             0x60F4A717,
             0xB28C4A45,
             0x964511B7,
             0x905CE0CA,
             0x278C8CB7,
             0x3273A285,
             0x3B8C510,
             0x6AF4185D,
             0xDB5EC400,
             0x4117D39B,
             0xAB594AB6,
             0xD768B228,
             0x4161D042,
             0xB144F9B9,
             0xAE47E4B0,
             0xA96E2604,
             0x6E122C06,
             0x3EECBA5D,
             0x695FE666,
             0xD9D7588C,
             0xAFFAC2E4,
             0xB097523B,
             0x1EEA6BD,
             0x1AE8BB58,
             0xB8D69E3,
             0x745855A1,
             0x3DFA1830,
             0x2C641D7A,
             0x6857C9B7,
             0x2AD8921B,
             0xE716BDCB,
             0xF322D338,
             0xA56DE716,
             0x5A8EF9CF,
             0x9F6D37E1,
             0x4086BD77,
             0xACA3C8CA,
             0x87B25415,
             0x8BD990BA,
             0xE32D8D0,
             0xC3F0F764,
             0xC2FBFEFE,
             0x8A3703F1,
             0xCDE955D2,
             0x9194CE03,
             0xCF92ADE9,
             0x98C7404F,
             0x8674D5FC,
             0xC2A87702,
             0x52580019,
             0x6E0FB794,
             0x5C14EDFA,
             0x795AC7A8,
             0x1C0077FB,
             0xFD1C49BB,
             0xDA1EAC6,
             0xCE9113A9,
             0x927F2323,
             0x2418C430,
             0x36C6E98C,
             0xB7292F0C,
             0xEAC2C7EE,
             0x8D8F1B10,
             0x312B5BC0,
             0x8502B6B2,
             0x94AE2B8C,
             0x550C79C6,
             0x546A5344,
             0x9CF26183,
             0x505603B9,
             0x563B8570,
             0xC89F0184,
             0x9123FB40,
             0x48F96F5B,
             0x1EC93FD0,
             0x174D4245,
             0x8CA0C266,
             0x53B57EB0,
             0xE0E69974,
             0xF70EC5C4,
             0x59511A6C,
             0x9FC37F22,
             0xD0BDE116,
             0xCA0050E9,
             0x5AA42C21,
             0x3B96F23E,
             0xC19377E7,
             0x19F41F65,
             0x4B64199D,
             0xDAB6A0EB,
             0x5D15BD00,
             0x379DDAB8,
             0x1FDF4294,
             0xFAE46146,
             0x31C9E669,
             0xAD4C724C,
             0x550D8D9D,
             0x441405EC,
             0xBE20FA04,
             0xC41B062E,
             0xAB0A7155
        };

        //Some instructions about gamemode
        private String instructions = "WELCOME TO STEALTH GAMEMODE!\nRed lines mark the game area.\nKill target players while remaining unseen. \n~r~Press TAB and wait 5 seconds for target information.";
        private String help = "For help and list of commands ~r~press M.";
        private bool shownHelp = false;

        //Constructor
        public Client()
        {
            //Listen for events
            EventHandlers["playerSpawned"] += new Action(OnPlayerSpawned);
            EventHandlers["onPlayerJoining"] += new Action(OnPlayerJoining);
            EventHandlers["onAssasinate"] += new Action<Player>(OnAssasinate);

            Tick += OnTick;
        }

        private void OnAssasinate(Player DeadPlayer)
        {
            TriggerEvent("chatMessage", "[DEBUG]", new[] { 255, 0, 0 }, "Shit's good bruh.");
            Screen.ShowNotification("DEBUG");
            /*
            if (Game.Player == Killer)
            {
                //Add money just for killing another player
                Game.PlayerPed.Money += 25;
                TriggerEvent("chatMessage", "+25", new[] { 0, 255, 0 }, " for killing another player.");

                if (DeadPlayer.Character == assasinationTarget)
                {
                    //Add money for killing target
                    Game.PlayerPed.Money += 150;
                    TriggerEvent("chatMessage", "+150", new[] { 0, 255, 0 }, " for assasinating target.");
                }
            }*/
        }

        public async Task OnTick()
        {
            //Disabling police
            if (Game.Player.WantedLevel > 0)
            {
                Game.Player.WantedLevel = 0;
            }

            //Showing help notifications after pressing "M"
            if (Game.IsControlJustReleased(0, Control.InteractionMenu))
            {
                //Draw notification with instructions
                Screen.ShowNotification(instructions);
            }

            //Display the target information after pressing "TAB"
            if (Game.IsControlJustReleased(0, Control.SelectWeapon))
            {
                //Get target and disable the ability to get target again for 5.1 seconds
                if (canGetTarget)
                {
                    DrawMugShot();
                    canGetTarget = false;
                    DisableGetTarget();
                }
                else
                {
                    Screen.ShowNotification("Wait for notifications to disappear before displaying the target again.");
                }
            }

            //If target has died - change the target to null
            if(assasinationTarget != null)
            {
                if (assasinationTarget.IsDead)
                {
                    assasinationTarget = null;
                    assasinationTargetName = " ";
                    //Notify the player about target change
                    DeathNotif();
                }
            }

            //Draw walls marking the game area
            //They are drawn around a small plaza in town
            //You need to create proper spawnpoints in map.lua on server's map
            DrawLine(new Vector3(75.3503f, -1010.71f, 31f), new Vector3(152.691f, -776.014f, 31f), new Vector4(255, 0, 0, 255));
            DrawLine(new Vector3(320.22f, -827.823f, 31f), new Vector3(152.691f, -776.014f, 31f), new Vector4(255, 0, 0, 255));
            DrawLine(new Vector3(320.22f, -827.823f, 31f), new Vector3(232.6191f, -1080.6f, 31f), new Vector4(255, 0, 0, 255));
            DrawLine(new Vector3(75.3503f, -1010.71f, 31f), new Vector3(232.6191f, -1080.6f, 31f), new Vector4(255, 0, 0, 255));
        }

        //Some delay before reenabling user to regain target by pressing TAB
        async void DisableGetTarget()
        {
            //Waiting 5.1 seconds to make sure everything is ready to regain target
            await BaseScript.Delay(5100);
            canGetTarget = true;
        }

        //Notification about target's death
        void DeathNotif()
        {
            Screen.ShowNotification("Assasination target is dead. ");
        }

        //Displaying target information
        void DrawMugShot()
        {
            //Get assasination target
            if (assasinationTarget == null)
            {
                assasinationTarget = GetRandomTarget();
            }

            //If target is still null return with below notification
            if (assasinationTarget == null)
            {
                Screen.ShowNotification("Currently there are no available targets. Try again after all the notifications disappear.");
                return;
            }
            else
            {
                //Mugshot async function
                MugShot();
            }
        }

        async void MugShot()
        {
            if (assasinationTarget != null)
            {
                //Get the mugshot of target
                int handle = Function.Call<int>(Hash.REGISTER_PEDHEADSHOT, assasinationTarget);
                //Wait for it to load
                await BaseScript.Delay(5000);
                if (assasinationTarget != null)
                {
                    //Check if Mugshot is valid and ready
                    if ( Function.Call<bool>(Hash.IS_PEDHEADSHOT_READY, handle) && Function.Call<bool>(Hash.IS_PEDHEADSHOT_VALID, handle))
                    {
                        string txdString = Function.Call<string>(Hash.GET_PEDHEADSHOT_TXD_STRING, handle);
                        //Display notification
                        Function.Call(Hash._SET_NOTIFICATION_TEXT_ENTRY, "STRING");
                        Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, "~b~Assasination request:\nFind and kill this person.");
                        Function.Call(Hash._SET_NOTIFICATION_MESSAGE_CLAN_TAG, txdString, txdString, 0, 7, assasinationTargetName, "Assasination Target", 0.4, "___KILL");
                        Function.Call(Hash._DRAW_NOTIFICATION, true, true);
                    }
                }
            }
        }

        //Getting random target from online players
        Ped GetRandomTarget()
        {
            //Get the list of players
            PlayerList pl = new PlayerList();

            if(pl.Count<Player>() < 1)
            {
                return null;
            }

            //Get random player, his Ped and name
            int randomInt = rnd.Next(0, pl.Count<Player>());
            Ped targetPed = pl.ElementAt(randomInt).Character;
            if (pl.ElementAt(randomInt) != null)
            {
                assasinationTargetName = pl.ElementAt(randomInt).Name;
            }

            int i = 0;

            //Retry to set the target if it has selected itself or selected target is dead
            while (targetPed == Game.PlayerPed || pl.ElementAt(randomInt).Character.IsDead)
            {
                randomInt = rnd.Next(0, pl.Count<Player>());
                targetPed = pl.ElementAt(randomInt).Character;
                if (pl.ElementAt(randomInt) != null)
                {
                    assasinationTargetName = pl.ElementAt(randomInt).Name;
                }

                //After 20 tries - abandon
                i++;
                if(i > 20)
                {
                    return null;
                }
            }

            //Return null if model has not been changed (is still set to Skater01AMY or Skater02AMY)
            //It may happen if player has just spawned and his model hasnt been changed to a random one
            //due to the model load delay
            if (targetPed.Model.GetHashCode().ToString() == "-1342520604" || targetPed.Model.GetHashCode().ToString() == "-1044093321")
            {
                return null;
            }

            //Return target player ped
            return targetPed;
        }

        //Setting weapons for player
        public void SetWeapons()
        {
            //Give player weapons
            //Random gun
            int randomWep = rnd.Next(0, 2);
            switch (randomWep) {
                case 0:
                    Game.PlayerPed.Weapons.Give(WeaponHash.Pistol, 24, false, true);
                    break;
                case 1:
                    Game.PlayerPed.Weapons.Give(WeaponHash.DoubleBarrelShotgun, 8, false, true);
                    break;
                case 2:
                    Game.PlayerPed.Weapons.Give(WeaponHash.PumpShotgun, 8, false, true);
                    break;
                default:
                    Game.PlayerPed.Weapons.Give(WeaponHash.Pistol, 24, false, true);
                    break;
            }

            //Random melee
            int randomMelee = rnd.Next(0, 2);
            switch (randomMelee)
            {
                case 0:
                    Game.PlayerPed.Weapons.Give(WeaponHash.Knife, 1, false, true);
                    break;
                case 1:
                    Game.PlayerPed.Weapons.Give(WeaponHash.Machete, 1, false, true);
                    break;
                case 2:
                    Game.PlayerPed.Weapons.Give(WeaponHash.Bat, 1, false, true);
                    break;
                default:
                    Game.PlayerPed.Weapons.Give(WeaponHash.Knife, 1, false, true);
                    break;
            }

            //Random special
            int randomSpecial = rnd.Next(0, 5);
            switch (randomSpecial)
            {
                case 0:
                    Game.PlayerPed.Weapons.Give(WeaponHash.Flare, 1, false, true);
                    break;
                case 1:
                    Game.PlayerPed.Weapons.Give(WeaponHash.SmokeGrenade, 1, false, true);
                    break;
                case 2:
                    Game.PlayerPed.Weapons.Give(WeaponHash.Molotov, 1, false, true);
                    break;
                default:
                    break;
            }

            //Switch to fists
            Game.PlayerPed.Weapons.Give(WeaponHash.Unarmed, 1, true, true);
        }

        //Setting random model
        async public void SetRandomSkin()
        {
            //Get random pedestrian model
            int randomModelInt = rnd.Next(0, models.Length);
            uint model = models[randomModelInt];

            //Request model
            Function.Call(Hash.REQUEST_MODEL, model);

            //Wait while loading model
            while (!Function.Call<bool>(Hash.HAS_MODEL_LOADED, model))
            {
                await BaseScript.Delay(0);
            }
            Function.Call(Hash.SET_PLAYER_MODEL, Game.Player, model);

            //Set weapons after setting skin
            SetWeapons();
        }

        //After player has spawned do the following stuff
        public void OnPlayerSpawned()
        {
            //Show help notification
            if (!shownHelp)
            {
                Screen.ShowNotification(help);
                shownHelp = true;
            }

            //Set random skin
            SetRandomSkin();
        }

        public void OnPlayerJoining()
        {
            //Disable drive-bys
            Function.Call(Hash.SET_PLAYER_CAN_DO_DRIVE_BY, Game.Player, false);
        }

        public void OnMapSpawn()
        {
            //Police should ignore players
            Function.Call(Hash.SET_MAX_WANTED_LEVEL, 1);
        }

        public void DrawLine(Vector3 a, Vector3 b, Vector4 col)
        {
            Function.Call(Hash.DRAW_LINE, a.X, a.Y, a.Z, b.X, b.Y, b.Z, col.X, col.Y, col.Z, col.W);
        }
    }
}
