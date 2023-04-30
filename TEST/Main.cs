using MelonLoader;
using UnityEngine;
using System;
using CodeStage.AntiCheat.ObscuredTypes;
using System.Linq;
using System.Reflection;
using SteamworksNative;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;
using System.Collections.Generic;

//Locals
using PersistentPlayerData = MonoBehaviourPublicBofrhnBoObInUnique;
using PlayerMovement = MonoBehaviourPublicGaplfoGaTrorplTrRiBoUnique;
using PlayerStatus = MonoBehaviourPublicObcumaObInplInObUnique;
using _Weapons = MonoBehaviourPublicItDi2ObIninInTrweGaUnique;
using _Weapons2 = MonoBehaviour2PublicGathObauTrgumuGaSiBoUnique;
using _allweapon = MonoBehaviourPublicObInCoIE85SiAwVoFoCoUnique;
using _glass = MonoBehaviourPublicObpiInObUnique;
using items = MonoBehaviourPublicDi2InItidGamoObInUnique;
using chat = MonoBehaviourPublicRaovTMinTemeColoonCoUnique;

// Online
using PlayerManager = MonoBehaviourPublicCSstReshTrheObplBojuUnique;
using OnlinePlayerMovement = MonoBehaviourPublicObVeSiVeRiSiAnVeanTrUnique;
using GameManager = MonoBehaviourPublicDi2UIObacspDi2UIObUnique;
using QuestManager = MonoBehaviourPublicLi1QudaDi2InquQuacUnique;
using GameLoop = MonoBehaviourPublicObInLi1GagasmLi1GaUnique;
using SteamManager = MonoBehaviourPublicObInUIgaStCSBoStcuCSUnique;
using ChatBox = MonoBehaviourPublicRaovTMinTemeColoonCoUnique;
using MenuUI = MonoBehaviourPublicCSDi2UIInstObUIloDiUnique;
using VersionUI = MonoBehaviourPublicTeveObInUnique;
using PauseUI = MonoBehaviourPublicTrpaGasemaGainBoGapaUnique;
using server = MonoBehaviourPublicInInUnique;
using ItemMelee = MonoBehaviour2PublicTrguGamubuGaSiBoSiUnique;
using Prompt = MonoBehaviourPublicGaprLi1ObGaprInUnique;
using UnityEngine.UI;

namespace Main
{
    public class Main : MelonMod
    {
        
        public static string AuthorizationChecker = "https://whis99.com/crabbb/guvenlik/crab.txt";
        public static string AuthorizationChecker2 = "https://whis99.com/crabbb/guvenlik/crabduyuru.txt";
        public static Rect AnaMenu = new Rect(10, 50, 250, 375);
        public static Rect HostMenu = new Rect(260, 50, 250, 600);
        public static Rect Stats = new Rect(510, 50, 250, 275);
        public static Rect Troll = new Rect(760, 50, 250, 350);
        public static Rect PlayerList = new Rect(760, 50, 250, 350);
        public static Rect crabfight = new Rect(510, 325, 250, 275);
        public static Rect Weapons = new Rect(510, 575, 250, 225);
        public static Rect Namee = new Rect(510, 575, 250, 225);

        public static OnlinePlayerMovement selectedPlayer;
        public static List<OnlinePlayerMovement> players = null;
        public static bool Weaponss;
        public static bool crabfightt;
        public static bool HosstMenu;
        public static bool openmenukey;
        public static bool trollmenu;
        public static bool stattmenu;
        public static bool playerrlist;
        public static bool name;
        public static bool IsInLobby = false;
        public static float speed = 1.4f;

        public static PlayerMovement PlayerMovement => PlayerMovement.field_Private_Static_MonoBehaviourPublicGaplfoGaTrorplTrRiBoUnique_0; //localplayer
        protected bool InGame => PlayerMovement != null;
        public static bool fly { get; set; }
        public static bool espp { get; set; }


        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            IsInLobby = true;
        }

        public override void OnApplicationStart()
        {
            
            Console.Title = string.Format("Whisky Hacks");
            String address = "";
            WebRequest requestip = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = requestip.GetResponse())
            using (StreamReader streamCC = new StreamReader(response.GetResponseStream()))
            {
                address = streamCC.ReadToEnd();
                int first = address.IndexOf("Address: ") + 9;
                int last = address.LastIndexOf("</body>");
                address = address.Substring(first, last - first);
            }
            WebClient webxD = new WebClient();
            webxD.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:93.0) Gecko/20100101 Firefox/93.0");
            System.IO.Stream streamxD = webxD.OpenRead(AuthorizationChecker);
            System.IO.Stream streamxD2 = webxD.OpenRead(AuthorizationChecker2);
            System.IO.StreamReader readerxD = new System.IO.StreamReader(streamxD);
            System.IO.StreamReader readerxD2 = new System.IO.StreamReader(streamxD2);

            string hwid = readerxD.ReadToEnd();
            string duyuru = readerxD2.ReadToEnd();
            if (hwid.Contains(SystemInfo.deviceUniqueIdentifier) == true)
            {
                //  MessageBox.Show("Satın aldığınız için teşekkürler.\nIP Addresiniz : " + address, "Whisky", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Console.WriteLine("Welcome to Whisky Hacks Crab Game");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Your HWID: " + SystemInfo.deviceUniqueIdentifier);
                Console.WriteLine("ANNOUNCEMENTS:");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(duyuru);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine(duyuru);
                Clipboard.SetText(SystemInfo.deviceUniqueIdentifier);
                Console.WriteLine("Not Registered Device" + Environment.NewLine + "Send Your HWID to whis99.com" + Environment.NewLine + "HWID : " + SystemInfo.deviceUniqueIdentifier);
                MessageBox.Show("Looks like you haven't purchased a license yet\nContact whis99.com for more informations.please copy your hwid and send mods\n" + SystemInfo.deviceUniqueIdentifier, "Whis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Thread.Sleep(100000);
                Environment.Exit(0);
            }
           
        }



        public override void OnGUI()
        {
            try {

                if (GameObject.Find("UI/CreateLobby/GameSettingsWindow") && IsInLobby)
                {
                    GameObject.Find("UI/CreateLobby/GameSettingsWindow/Settings/Container/Content/SliderSetting/Interact/Slider").GetComponent<Slider>().m_MaxValue = 1000;
                    IsInLobby = false;
                }



                if (WeaponBuff && InGame)
                {
                    _Weapons component = UnityEngine.Object.FindObjectOfType<_Weapons>().gameObject.GetComponent<_Weapons>();
                    if(component.currentItem == null)
                    {
                        WeaponBuff = false;
                        return;
                    }
                    
                    if (component.currentItem.gameObject.GetComponent<ItemMelee>() && InGame)
                    {
                        ItemMelee component2 = component.currentItem.gameObject.GetComponent<ItemMelee>();
                        component2.itemData.damage = int.MaxValue;
                        component2.itemData.reloadTime = 0f;
                        component2.itemData.gunComponent.accuracy = float.NegativeInfinity;
                        component2.itemData.gunComponent.recoilAmount = 0f;
                        component2.itemData.gunComponent.maxDamage = int.MaxValue;
                        component2.itemData.gunComponent.minDamage = int.MaxValue;
                        component2.itemData.gunComponent.bulletsPerShot = 200;
                        component2.itemData.gunComponent.pushOtherForce = int.MaxValue;
                        component2.itemData.gunComponent.startFalloffDistance = int.MaxValue;
                        component2.itemData.gunComponent.rpm = 1000f;
                        component2.itemData.gunComponent.endFalloffDistance = int.MaxValue;
                        component2.itemData.currentAmmo = 9999;
                        component2.itemData.damage = 999;
                    }
                    {
                    if (component.currentItem.gameObject.GetComponent<_Weapons2>() && InGame)
                    {
                        _Weapons2 component3 = component.currentItem.gameObject.GetComponent<_Weapons2>();
                        component3.itemData.gunComponent.recoilAmount = 0f;
                        component3.itemData.gunComponent.multiplierDamage = float.PositiveInfinity;
                        component3.itemData.gunComponent.pushSelfForce = 0;
                        component3.itemData.gunComponent.pushOtherForce = int.MaxValue;
                        component3.itemData.gunComponent.accuracy = float.PositiveInfinity;
                        component3.itemData.gunComponent.rpm = float.PositiveInfinity;
                        component3.itemData.currentAmmo = 9999;
                            component3.itemData.gunComponent.bulletsPerShot = 200;
                            component3.itemData.gunComponent.cameraShake = 0f;
                            component3.itemData.gunComponent.automatic = true;
                       // component3.maxShootDistance = float.MaxValue;
                        component3.itemData.gunComponent.bulletsPerShot = 50;
                        component3.itemData.gunComponent.startFalloffDistance = 99999;
                        component3.itemData.gunComponent.endFalloffDistance = int.MaxValue;
                    }
                    }
                }


            if (GodMode && InGame)
            {
                PlayerStatus.Instance.currentHp = new ObscuredInt(12800000);
                    PlayerStatus.Instance.maxHp = new ObscuredInt(12800000);
                    PlayerMovement.dead = false;
                    PlayerMovement.grounded = true;
                }
            if (infpunch && InGame)
            {
                var punch = PlayerMovement.punchPlayers;
                punch.field_Private_Boolean_0 = true;
                punch.field_Private_Single_0 = 3.1f;
            }


            if (breakable==true && InGame)
            {
                    if (_glass.Instance == null)
                    {
                        breakable = false;
                        glassesp = "Breakable Glass ESP Off";
                        return;
                    }
                foreach (var xd in _glass.Instance.pieces)
                  {
                    if (xd == null) continue;
                    if (xd.gameObject.name.Contains("Solid")) continue;
                     float distance = Vector3.Distance(PlayerStatus.Instance.transform.position, xd.transform.position);
                      int distanceToint = (int)distance;
                      GUIStyle style = new GUIStyle
                      {
                         alignment = TextAnchor.UpperCenter
                      };
                      style.normal.textColor = Color.red;
                    style.fontSize = 18;
                    style.fontStyle = FontStyle.Bold;
                    Vector3 w2s = Camera.main.WorldToScreenPoint(xd.transform.position);
                         // player.name.Replace("(Clone)", "")
                    GUI.Label(new Rect(w2s.x, (float)UnityEngine.Screen.height - w2s.y, 0f, 0f), "Breakable glass! " + " [" + distanceToint + "m]", style);//Name Esp
                  }
                 

            }
            else
            {
                breakable = false;
                glassesp = "GlassESP Turned off";
            }
            if (espp == true && InGame)    //nameesp
            {
                foreach (PlayerManager player in UnityEngine.Object.FindObjectsOfType<PlayerManager>())
                {

                        float distance = Vector3.Distance(PlayerStatus.Instance.transform.position, player.transform.position);
                        int distanceToint = (int)distance;
                        GUIStyle style = new GUIStyle
                        {
                            alignment = TextAnchor.MiddleCenter
                        };
                        style.normal.textColor = UnityEngine.Color.white;
                        Vector3 w2s = Camera.main.WorldToScreenPoint(player.transform.position);

                        /////box esp için

                        float playerNeckMid = UnityEngine.Screen.height - player.transform.position.y;
                        float playerBottomMid = UnityEngine.Screen.height - w2s.y;
                        float playerTopMid = playerNeckMid - (playerBottomMid - playerNeckMid) / 5;
                        float boxHeight = (playerBottomMid - playerTopMid);
                        float boxWidth = boxHeight / 1.8f;


                        ////boxx
                        if (w2s.z > 0f)
                        {
                            GUIStyle myStyle = new GUIStyle();
                            myStyle.fontSize = 25;
                            myStyle.fontStyle = FontStyle.Bold;
                            myStyle.normal.textColor = Color.green;


                         //   Drawing.Drawing.DrawBoxOutline(new Vector2(w2s.x - (boxWidth / 2f), playerNeckMid), boxWidth, boxHeight, Color.green); //box esp
                            GUI.Label(new Rect(w2s.x, (float)UnityEngine.Screen.height - w2s.y, 0f, 0f), player.username.Replace("(Clone)", "") + " [" + distanceToint + "m]", myStyle);//Name Esp

                        }


                    }
                }


             if (openmenukey == true)
            {
                GUI.color = Color.white;
                AnaMenu = GUI.Window(1, AnaMenu, (GUI.WindowFunction)MainMenu, "Whisky Hacks Main");
                if (HosstMenu == true)
                {
                    HostMenu = GUI.Window(2, HostMenu, (GUI.WindowFunction)HostMenuu, "Whisky Crab Chat");
                        if (crabfightt == true)
                        {
                            crabfight = GUI.Window(5, crabfight, (GUI.WindowFunction)CrabMenuu, "Whisky Crab Chat");
                        }
                    }
                if (stattmenu == true)
                {
                    Stats = GUI.Window(3, Stats, (GUI.WindowFunction)StatMenu, "Whisky Crab Chat");
                }

                    if (playerrlist == true)
                    {
                        PlayerList = GUI.Window(31, PlayerList, (GUI.WindowFunction)PlayerListMenu, "Whisky Crab Chat");
                    }

                    if (name == true)
                {
                    Namee = GUI.Window(7, Namee, (GUI.WindowFunction)NameMenu, "Whisky Crab Chat");
                }
                if (trollmenu == true)
                {
                    Troll = GUI.Window(4, Troll, (GUI.WindowFunction)TrollMenuu, "Whisky Crab Chat");
                }
                if (Weaponss == true)
                {
                    Weapons = GUI.Window(6, Weapons, (GUI.WindowFunction)WeaponMenuu, "Whisky Crab Chat");
                }
            }
            }
            catch (Exception)
            {
            }
        }
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.CapsLock))
            {
                if (openmenukey == true)  //close
                {
                    if (InGame == false)
                    {
                        openmenukey = false;
                        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
                        UnityEngine.Cursor.visible = true;
                        PauseUI.paused = false;
                    }
                    if (InGame == true)
                    {
                        openmenukey = false;
                        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                        UnityEngine.Cursor.visible = false;
                        PauseUI.paused = false;
                    }
                }
                else if (openmenukey == false)  //open
                {
                    openmenukey = true;
                    UnityEngine.Cursor.lockState = CursorLockMode.Confined;
                    UnityEngine.Cursor.visible = true;
                    PauseUI.paused = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                fly = !fly;
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                espp = !espp;
            }

            if (fly == true && InGame==true)
            {
                Rigidbody rb1 = PlayerMovement.GetRb();
                rb1.AddForce(Vector3.up * 65);
                PlayerMovement.GetRb().velocity = new Vector3(0f, 0f, 0f);
                if (KeyControl.KeyControll.GetKey(32))
                {
                    PlayerStatus.Instance.transform.position = new Vector3(PlayerStatus.Instance.transform.position.x, PlayerStatus.Instance.transform.position.y + speed, PlayerStatus.Instance.transform.position.z);
                }
                Vector3 playerTransformPosVec = PlayerStatus.Instance.transform.position;
                if (KeyControl.KeyControll.GetKey(119))
                {
                    PlayerStatus.Instance.transform.position = new Vector3(playerTransformPosVec.x + Camera.main.transform.forward.x * Camera.main.transform.up.y * speed, playerTransformPosVec.y + Camera.main.transform.forward.y * speed, playerTransformPosVec.z + Camera.main.transform.forward.z * Camera.main.transform.up.y * speed);
                }
                if (KeyControl.KeyControll.GetKey(115))
                {
                    PlayerStatus.Instance.transform.position = new Vector3(playerTransformPosVec.x - Camera.main.transform.forward.x * Camera.main.transform.up.y * speed, playerTransformPosVec.y - Camera.main.transform.forward.y * speed, playerTransformPosVec.z - Camera.main.transform.forward.z * Camera.main.transform.up.y * speed);
                }
                if (KeyControl.KeyControll.GetKey(100))
                {
                    PlayerStatus.Instance.transform.position = new Vector3(playerTransformPosVec.x + Camera.main.transform.right.x * speed, playerTransformPosVec.y, playerTransformPosVec.z + Camera.main.transform.right.z * speed);
                }
                if (KeyControl.KeyControll.GetKey(97))
                {
                    PlayerStatus.Instance.transform.position = new Vector3(playerTransformPosVec.x - Camera.main.transform.right.x * speed, playerTransformPosVec.y, playerTransformPosVec.z - Camera.main.transform.right.z * speed);
                }

            }
            else if (fly == false)
            {


            }
            if (airjump)
            {
                if(InGame && Input.GetKeyDown(KeyCode.Space))
                {
                    var velocity = PlayerMovement.GetRb().velocity;
                    velocity.y = 20f;
                    PlayerMovement.GetRb().velocity = velocity;
                }
            }
            if (noshake)
            {
             CurrentSettings.Instance.UpdateCamShake(false);
            }
            else
            {
                CurrentSettings.Instance.UpdateCamShake(true);
            }


            //imlece ışınlan
            if (Input.GetKeyDown(KeyCode.F3))
            {
                PlayerMovement.GetRb().position = FindTarget();
            }

            //////////
            ///
            var types = Assembly.GetAssembly(typeof(CodeStage.AntiCheat.Common.ACTk)).GetTypes().Where(t =>
                t.IsPublic);
            foreach (Type t in types)
            {
                ExecutePublicStaticVoidMethods(t);
            }
        }

        //anticheat

        //anticheat


        private GameObject[] GetHeads()
        {
            List<GameObject> heads = new();

            foreach (PlayerManager manager in GameManager.Instance.activePlayers.Values)
            {
                if (manager.dead || manager.steamProfile.m_SteamID == SteamUser.GetSteamID().m_SteamID)
                    continue;
                heads.Add(manager.head.gameObject);
            }

            return heads.ToArray();
        }

        private static Vector3 FindTarget()
        {
            Transform playerTarget = PlayerMovement.playerCam;

            bool target = Physics.Raycast(playerTarget.position, playerTarget.forward, out var raycastHit, 5000f, GameManager.Instance.whatIsGround);
            Vector3 result;
            if (target)
            {
                Vector3 vector = Vector3.one;
                result = raycastHit.point + vector;
            }
            else
            {
                result = Vector3.zero;
            }
            return result;
        }
        private static void ExecutePublicStaticVoidMethods(Type t)
        {
            // Find StopDetection Method.
            var methods = t.GetMethods().Where(m =>
            m.IsStatic &&
            m.IsPublic &&
            m.Name.Contains("Stop"));

            foreach (MethodInfo method in methods)
            {
                method.Invoke(null, null);
            }
        }




        public static string glassesp = "Glass Esp Only for GlassGame";
        public void MainMenu(int id)
        {
            try
            {
                GUI.color = Color.yellow;
                GUILayout.Label("WhiskyHacks CrabGame", new GUILayoutOption[0]);
                GUILayout.Label("whis99.com", new GUILayoutOption[0]);
                GUI.color = Color.cyan;
                GUILayout.Space(5f);
                GUILayout.Label("TP to AIM[F3]", new GUILayoutOption[0]);
                if (GUILayout.Toggle(fly, "Fly And NoClip [F2]", new GUILayoutOption[0]) != fly)
                {
                    fly = !fly;
                    if (fly==true)
                    {
                        if (InGame == true)
                        {
                            Console.WriteLine("Fly Actived");
                        }
                    }
                    if (fly == false)
                    {
                        Console.WriteLine("Fly Disabled");
                    }

                }

                if (GUILayout.Toggle(espp, "ESP [leftCTRL]", new GUILayoutOption[0]) != espp  )
                {
                    espp = !espp;

                }

                speed = GUILayout.HorizontalSlider(speed, 1.4f, 55f, new GUILayoutOption[0]);
                GUI.color = Color.red;
                GUILayout.Label("Fly speed: " + (float)(int)speed, new GUILayoutOption[0]);
                GUI.color = Color.cyan;


                if (GUILayout.Button("Host Menu", new GUILayoutOption[0]))
                {
                    HosstMenu = !HosstMenu;
                }
                if (GUILayout.Button("Stats Menu", new GUILayoutOption[0]))
                {
                    stattmenu = !stattmenu;
                }
                GUI.color = Color.red;
                if (GUILayout.Button("Player List", new GUILayoutOption[0]))
                {
                    playerrlist = !playerrlist;
                }
                GUI.color = Color.cyan;
                if (GUILayout.Button("Change Nick", new GUILayoutOption[0]))
                {
                    name = !name;
                }
                if (GUILayout.Button("Troll Menu", new GUILayoutOption[0]))
                {
                    trollmenu = !trollmenu;
                }
                if (GUILayout.Button(glassesp, new GUILayoutOption[0]))
                {
                    
                    if (breakable == false && GameManager.Instance.gameMode.freezeTimer.field_Private_Single_0 < 18)
                    {
                        breakable = true;
                        glassesp = "Breakable Glass ESP On";
                    }
                   else if (breakable == true && GameManager.Instance.gameMode.freezeTimer.field_Private_Single_0 < 18)
                    {
                        breakable = false;
                        glassesp = "Breakable Glass ESP Off";
                    }
                }
                GUI.color = Color.yellow;
                if (GUILayout.Button("HELP", new GUILayoutOption[0]))
                {
                    System.Diagnostics.Process.Start("https://whis99.com");
                }
                GUI.color = Color.white;
                GUI.DragWindow();
            }

            catch (Exception) { }
        }


        public void WeaponMenuu(int id)
        {
            try
            {
                GUILayout.Label("Host Weapons Menu", new GUILayoutOption[0]);
                if (GUILayout.Button("Give all AK47", new GUILayoutOption[0]))
                {
                    _allweapon.ForceGiveAllWeapon(0);
                }
                if (GUILayout.Button("Give all Pistol", new GUILayoutOption[0]))
                {
                    _allweapon.ForceGiveAllWeapon(1);
                }
                if (GUILayout.Button("Give all Revolver", new GUILayoutOption[0]))
                {
                    _allweapon.ForceGiveAllWeapon(2);
                }
                if (GUILayout.Button("Give all Shotgun", new GUILayoutOption[0]))
                {
                    _allweapon.ForceGiveAllWeapon(3);
                }
                if (GUILayout.Button("Give all bomb", new GUILayoutOption[0]))
                {
                    _allweapon.ForceGiveAllWeapon(5);
                }
                if (GUILayout.Button("Give all Katana", new GUILayoutOption[0]))
                {
                    _allweapon.ForceGiveAllWeapon(6);
                }
                if (GUILayout.Button("Remove all weapons", new GUILayoutOption[0]))
                {
                    _allweapon.ForceRemoveAllWeapons();
                }
                GUI.DragWindow();
            }
            catch (Exception) { }
        }
        public void HostMenuu(int id)
        {
            try
            {
                /*
                KK localhwid = new KK();
                BQ ss = localhwid.OpenRead(AuthorizationChecker);
                BZ HH = new BZ(ss);
                string ag = HH.ReadToEnd();
                if (ag.Contains(WW.deviceUniqueIdentifier) == true)
                {
                }
                else
                {
                   UnityEngine.Application.Quit();
                    Environment.Exit(0);
                }
                */
                GUI.color = Color.yellow;
                GUILayout.Label("Host Menu", new GUILayoutOption[0]);
                GUI.color = Color.white;
                GUILayout.Space(5f);
                if (GUILayout.Button("Force Start", new GUILayoutOption[0]))
                {
                    GameLoop.Instance.StartGames();
                }
                if (GUILayout.Button("Force End", new GUILayoutOption[0]))
                {
                    UnityEngine.Object.FindObjectOfType<GameMode>().GameOver();
                }
                if (GUILayout.Button("Force NextGame", new GUILayoutOption[0]))
                {   
                    GameLoop.Instance.NextGame();
                }
                if (GUILayout.Button("Restart Lobby", new GUILayoutOption[0]))
                {
                    GameLoop.Instance.RestartLobby();
                }
                if (GUILayout.Button("Win the Game", new GUILayoutOption[0]))
                {
                    server.SendWinner(0, 0);
                }
                if (GUILayout.Button("Weapons Menu", new GUILayoutOption[0]))
                {
                    Weaponss = !Weaponss;
                }
                if (GUILayout.Button("CrabFight Game Menu", new GUILayoutOption[0]))
                {
                    crabfightt = !crabfightt;
                }

                if (GUILayout.Button("ChangeColor", new GUILayoutOption[0]))
                {
                    server.ChangeColor(0, 5);
                }

                if (GUILayout.Button("DropItem", new GUILayoutOption[0]))
                {
                    server.DropItem(0, 1, 1, 1);
                }

                if (GUILayout.Button("DropMoney", new GUILayoutOption[0]))
                {
                    server.DropMoney(0, 111111, 111111);
                }


                if (GUILayout.Button("RequestCosmetics", new GUILayoutOption[0]))
                {
                    server.RequestCosmetics(0);
                }


                if (GUILayout.Button("givehat", new GUILayoutOption[0]))
                {
                    server.GiveHat(0, 2);
                }

                if (GUILayout.Button("RespawnPlayer", new GUILayoutOption[0]))
                {
                    server.RespawnPlayer(0, PlayerStatus.Instance.transform.position);
                }


                if (GUILayout.Button("SendCrabBall", new GUILayoutOption[0]))
                {
                    server.SendCrabBall(PlayerStatus.Instance.transform.position, 1);
                }


                if (GUILayout.Button("SpawnBoulder", new GUILayoutOption[0]))
                {
                    server.SpawnBoulder(0);
                }


                if (GUILayout.Button("TagPlayer", new GUILayoutOption[0]))
                {
                    server.TagPlayer(0,1);
                }

                if (GUILayout.Button("PlayerAnimation", new GUILayoutOption[0]))
                {
                    server.PlayerAnimation(0, 1, true);
                }

                if (GUILayout.Button("Freeze all players", new GUILayoutOption[0]))
                {
                    server.FreezePlayers(true);
                }
                if (GUILayout.Button("Unfreeze all players", new GUILayoutOption[0]))
                {
                    server.FreezePlayers(false);
                }
                if (GUILayout.Button("AD", new GUILayoutOption[0]))
                {
                    for (int i = 0; i < 15; i++)
                    {
                        server.SendChatMessage(0, "whis99.com The best Cheats");
                    }
                }
                if (GUILayout.Button("Set Bomber", new GUILayoutOption[0]))
                {
                    server.SetBomber(0, 0);

                }
                GUI.DragWindow();
            }
            catch (Exception)
            {
            }
        
      }


        public static string crabhp = "Crab HP";
        public void CrabMenuu(int id)
        {
            try
            {
                GUILayout.Label("CrabFight Menu", new GUILayoutOption[0]);
                crabhp = GUILayout.TextArea(crabhp, new GUILayoutOption[0]);

                if (GUILayout.Button("Set Crab HP[BETA]", new GUILayoutOption[0]))
                {
                    server.CrabHp(float.Parse(crabhp));
                }
                if (GUILayout.Button("Crab attack 1", new GUILayoutOption[0]))
                {
                    server.CrabAnimation(1);
                }
                if (GUILayout.Button("Crab attack 2", new GUILayoutOption[0]))
                {
                    server.CrabAnimation(2);
                }
                if (GUILayout.Button("Crab attack 3", new GUILayoutOption[0]))
                {
                    server.CrabAnimation(3);
                }
                if (GUILayout.Button("Crab attack 4", new GUILayoutOption[0]))
                {
                    server.CrabAnimation(4);
                }
                if (GUILayout.Button("Kill Crab", new GUILayoutOption[0]))
                {
                    server.CrabAnimation(5);
                }
                if (GUILayout.Button("Set Crab Diffculty to Max", new GUILayoutOption[0]))
                {
                    server.CrabDifficulty(int.MaxValue);
                }
                GUI.DragWindow();
            }
            catch(Exception) { }
        }
        public void TrollMenuu(int id)
        {
            try
            {
                /*
                KK localhwid = new KK();
                BQ ss = localhwid.OpenRead(AuthorizationChecker);
                BZ HH = new BZ(ss);
                string ag = HH.ReadToEnd();
                if (ag.Contains(WW.deviceUniqueIdentifier) == true)
                {
                }
                else
                {
                    UnityEngine.Application.Quit();
                    Environment.Exit(0);
                }
               */
                GUI.color = Color.red;
                GUILayout.Label("Troll Menu", new GUILayoutOption[0]);
                GUI.color = Color.white;
                

                if (GUILayout.Button("AD", new GUILayoutOption[0]))
                {
                    UnityEngine.Object.FindObjectOfType<ChatBox>().SendMessage("Best Hacks!! whis99.com");
                    UnityEngine.Object.FindObjectOfType<ChatBox>().SendMessage("Best Hacks!! whis99.com");
                    UnityEngine.Object.FindObjectOfType<ChatBox>().SendMessage("Best Hacks!! whis99.com");
                    UnityEngine.Object.FindObjectOfType<ChatBox>().SendMessage("Best Hacks!! whis99.com");
                    UnityEngine.Object.FindObjectOfType<ChatBox>().SendMessage("Best Hacks!! whis99.com");
                    UnityEngine.Object.FindObjectOfType<ChatBox>().SendMessage("Best Hacks!! whis99.com");
                }
                if (GUILayout.Button("Doom Game Full Birght", new GUILayoutOption[0]))
                {
                    UnityEngine.Object.FindObjectOfType<GameModePublicSiprBoStBoUnique>().ToggleLights(true);
                }

                    if (GUILayout.Button("Blow Up All BreakeAble Glass's", new GUILayoutOption[0]))
                {
                    if (GameManager.Instance != null && GameManager.Instance.gameMode.freezeTimer.field_Private_Single_0 < 18)
                        return;

                    foreach (var glass in _glass.Instance.pieces)
                    {
                        if (glass == null) continue;

                        if (glass.gameObject.name.Contains("Solid")) continue;

                        glass.LocalInteract();
                        glass.AllInteract(SteamUser.GetSteamID().m_SteamID);
                    }
                }
                if (GUILayout.Button("Reset Daily Quest", new GUILayoutOption[0]))
                {
                    SaveManager.Instance.state.nextQuestAvailableTime = Il2CppSystem.DateTime.Now;
                    SaveManager.Instance.Save();
                }
                if (GUILayout.Button("Complete Daily Quest", new GUILayoutOption[0]))
                {
                    SaveManager.Instance.state.AddQuestProgress(187);
                    SaveManager.Instance.Save();
                }
                if (GUILayout.Button("Give AK47", new GUILayoutOption[0]))
                {
                    _Weapons.Instance.ForceGiveItem(items.GetItemById(0));
                }
                if (GUILayout.Button("Give Pistol", new GUILayoutOption[0]))
                {
                    _Weapons.Instance.ForceGiveItem(items.GetItemById(1));
                }
                if (GUILayout.Button("Give Revolver", new GUILayoutOption[0]))
                {
                    _Weapons.Instance.ForceGiveItem(items.GetItemById(2));
                }
                if (GUILayout.Button("Give Shotgun", new GUILayoutOption[0]))
                {
                    _Weapons.Instance.ForceGiveItem(items.GetItemById(3));
                }
                if (GUILayout.Button("Give Bomb", new GUILayoutOption[0]))
                {
                    _Weapons.Instance.ForceGiveItem(items.GetItemById(5));
                }
                if (GUILayout.Button("Give Katana", new GUILayoutOption[0]))
                {
                    _Weapons.Instance.ForceGiveItem(items.GetItemById(6));
                }
                if (GUILayout.Button("Give Grenade", new GUILayoutOption[0]))
                {
                    _Weapons.Instance.ForceGiveItem(items.GetItemById(13));
                }
                GUI.DragWindow();
            }
           
            catch (Exception) { }
        }

        public static bool airjump;
        public static bool GodMode;
        public static bool infpunch;
        public static bool noshake;
        public static bool nopush;
        public static bool breakable;
        public static bool WeaponBuff;
        public static string falldmgbutton = "No Fall Damage";
        public static string nopushbutton = "No Push";
        public static float hiz;
        public static bool antikick;
        public static string antikickbtn = "Anti Kick - No Dmg";


        public static string playerName;
        public static string playernum;
        public void NameMenu(int id)
        {
            try
            {
                GUI.color = Color.yellow;
                GUILayout.Label("Name Changer", new GUILayoutOption[0]);

                GUI.color = Color.cyan;

                GUI.SetNextControlName("changeName");
                playerName = GUILayout.TextArea(playerName, new GUILayoutOption[0]);
                if (GUILayout.Button("Change Name", new GUILayoutOption[0]))
                {
                    Console.WriteLine(UnityEngine.Object.FindObjectOfType<PlayerManager>().username);
                    UnityEngine.Object.FindObjectOfType<PlayerManager>().username = playerName; //random birinin adını asd yapıyor bu 
                    UnityEngine.Object.FindObjectOfType<PlayerManager>().waitingReady = true;
                    UnityEngine.Object.FindObjectOfType<PlayerManager>().Mute(false);
                    UnityEngine.Object.FindObjectOfType<PlayerManager>().SetSpectator(0);
                    UnityEngine.Object.FindObjectOfType<PlayerManager>().SetColor(5);
                    UnityEngine.Object.FindObjectOfType<PlayerManager>().dead = false;

                }
                GUILayout.Label("Number Changer", new GUILayoutOption[0]);
                playernum = GUILayout.TextArea(playernum, new GUILayoutOption[0]);
                if (GUILayout.Button("Change Number", new GUILayoutOption[0]))
                {
                    UnityEngine.Object.FindObjectOfType<PlayerManager>().playerNumber = int.Parse(playernum);
                }
                    GUI.color = Color.red;
                if (GUILayout.Button("CLOSE", new GUILayoutOption[0]))
                {
                    name = false;


                }
                GUI.DragWindow();
            }
            catch(Exception) { }
        }





        public void PlayerListMenu(int id)
        {
            try
            {
                GUI.color = Color.yellow;
                GUILayout.Label("In Game Player List", new GUILayoutOption[0]);
                GUILayout.Space(5f);
                if (selectedPlayer != null)
                {
                    GUILayout.Label("Selected Player : " + selectedPlayer.name, new GUILayoutOption[0]);
                }
                else
                {
                    GUILayout.Label("Selected Player : " + null, new GUILayoutOption[0]);
                }
                GUILayout.Space(5f);
                GUI.color = Color.cyan;
                if (InGame==false)
                {
                    foreach (OnlinePlayerMovement p in players)
                    {
                        if (GUILayout.Button("Name : " + p.name + "\nPosition : " + p.transform.position.ToString() + "\nUser ID : ", null))
                        {
                            selectedPlayer = p;
                        }
                    }
                }

                GUILayout.Space(8f);
                GUI.color = Color.yellow;
                GUILayout.Label("Player Options", new GUILayoutOption[0]);
                GUI.color = Color.cyan;
                GUILayout.Space(5f);

                if (GUILayout.Button("Revive Selected Player", new GUILayoutOption[0]))
                {

                }

                GUI.color = Color.red;
                if (GUILayout.Button("CLOSE", new GUILayoutOption[0]))
                {
                    playerrlist = false;
                }

                GUI.DragWindow();

            }

            catch (Exception) { }
        }


        public void StatMenu(int id)
        {
            try
            {
                /*
                KK localhwid = new KK();
                BQ ss = localhwid.OpenRead(AuthorizationChecker);
                BZ HH = new BZ(ss);
                string ag = HH.ReadToEnd();
                if (ag.Contains(WW.deviceUniqueIdentifier) == true)
                {
                }
                else
                {
                    UnityEngine.Application.Quit();
                    Environment.Exit(0);
                }
                */
                GUILayout.Label("Stat Menu", new GUILayoutOption[0]);
                if (GUILayout.Toggle(GodMode, "GodMode", new GUILayoutOption[0]) != GodMode)
                {
                    GodMode = !GodMode;
                }
                if (GUILayout.Toggle(airjump, "AirJump", new GUILayoutOption[0]) != airjump)
                {
                    airjump = !airjump;
                }
                if (GUILayout.Toggle(infpunch, "Infinte Punch", new GUILayoutOption[0]) != infpunch)
                {
                    infpunch = !infpunch;
                }
                if (GUILayout.Toggle(noshake, "No-Shake", new GUILayoutOption[0]) != noshake)
                {
                    noshake = !noshake;
                }
                if (GUILayout.Toggle(WeaponBuff, "Buff Weapons", new GUILayoutOption[0]) != WeaponBuff)
                {
                    WeaponBuff = !WeaponBuff;
                }
                if (GUILayout.Toggle(antikick, antikickbtn, new GUILayoutOption[0]) != antikick)
                {
                    if (antikick ==false)
                    {
                        NoKickk1.NoKickk1.NoKick = true;
                        NoKickk2.NoKickk2.NoKick2 = true;
                        antikick = true;
                        antikickbtn = "Anti Kick - NoDmg ON";
                    }
                    else
                    {
                        NoKickk1.NoKickk1.NoKick = false;
                        NoKickk2.NoKickk2.NoKick2 = false;
                        antikick = false;
                        antikickbtn = "Anti Kick - NoDmg OFF";
                    }
                }
                if (GUILayout.Button(nopushbutton, new GUILayoutOption[0]))
                {
                    if (nopush == false )
                    {
                        nopushbutton = "NoPush On";
                        Element_ToggleChanged(true);
                        nopush = true;
                    }
                    else if(nopush == true)
                        {
                        nopushbutton = "NoPush Off";
                        Element_ToggleChanged(false);
                        nopush = false;

                    }
                }
                if (GUILayout.Button(falldmgbutton, new GUILayoutOption[0]))
                {
                    if (bypass.Patch.PlayerStatusPatch.NoFall == false)
                    {
                        bypass.Patch.PlayerStatusPatch.NoFall = true;
                        falldmgbutton = "No Fall Damage On";
                    }
                    else if(bypass.Patch.PlayerStatusPatch.NoFall == true)
                    {
                        falldmgbutton = "No Fall Damage Off";
                        bypass.Patch.PlayerStatusPatch.NoFall = false;
                    }
                }

                if (GUILayout.Button("Set Speed", new GUILayoutOption[0]))
                {
                    PlayerMovement.field_Private_ObscuredFloat_6 = new ObscuredFloat(hiz*6.5f);  //default 6.5
                    PlayerMovement.field_Private_ObscuredFloat_5 = new ObscuredFloat(hiz*13); //default 13


                }
                GUI.color = Color.green;
                hiz = GUILayout.HorizontalSlider(hiz, 6f, 200f, new GUILayoutOption[0]);

                GUI.DragWindow();
                GUI.color = Color.white;
            }

            catch (Exception) { }
        }

       
        private void Element_ToggleChanged(bool toggled)
        {
           NoPushhhhhhhhh.NoPushhhh.NoPush = toggled;
        }

        public bool playersnapline;
        public int lineposition;
        public Vector2 scrollPosition = Vector2.zero;
    }
}
