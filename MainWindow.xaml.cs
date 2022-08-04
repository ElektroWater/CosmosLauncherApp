using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using DiscordRPC;


namespace CosmosLauncherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        string version = "2.0";
        public Process CosmosServerProcess { get; set; }
        public MainWindow()
        {
            var lang = Properties.Settings.Default.language;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            Update();
            InitializeComponent();
            Folder_Label.Text = Properties.Settings.Default["Fortnite_Path"].ToString();
            Discord();
             //C:\Program Files\nodejs
            Init_CosmosServer();
            CosmosServerProcess.Start();
            //CheckIfNodeInstalled();
        }
        private void CheckIfNodeInstalled()
        {
            if(!File.Exists("C:/Program Files/nodejs/node.exe"))
            {
                new Message("Erreur", "NodeJS doit être installer.", 110, 350).Show();
                this.Close();
            }
        }
        private void Init_CosmosServer()
        {
            Process CosmosServer = new Process()
            {
                StartInfo =
                            {
                                FileName = AppDomain.CurrentDomain.BaseDirectory + "CosmosServer\\start.bat",
                                CreateNoWindow = Properties.Settings.Default["Logs_Server"].ToString() == "True",
                                WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory +  "CosmosServer/"
                            }
            };
            CosmosServerProcess = CosmosServer;
        }

        private static void SupprimeProcess(string imageName)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "taskkill",
                Arguments = $"/im {imageName} /f /t",
                CreateNoWindow = true,
                UseShellExecute = false
            }).WaitForExit();
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {

                return true;
            }

            return false;
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        private void Launch_btn_Click(object sender, RoutedEventArgs e)
        {
            SupprimeProcess("FortniteClient-Win64-Shipping.exe");
            SupprimeProcess("FortniteLauncher.exe");

            string StringClientBypass = Properties.Settings.Default["Fortnite_Path"] + "/FortniteGame/Binaries/Win64/ClientBypassV5.dll";
            string StringMemoryLeakFixerPatch = Properties.Settings.Default["Fortnite_Path"] + "/FortniteGame/Binaries/Win64/MemoryLeakFixer.dll";
            string StringMemoryClientDLLPatchImportant = Properties.Settings.Default["Fortnite_Path"] + "/FortniteGame/Binaries/Win64/api-ClientDLL-x64.dll";
            string FortniteLauncherImportant = Properties.Settings.Default["Fortnite_Path"] + "/FortniteGame/Binaries/Win64/FortniteLauncher.exe";

            DownloadFiles(StringClientBypass, StringMemoryLeakFixerPatch, StringMemoryClientDLLPatchImportant, FortniteLauncherImportant);

            if (File.Exists(Properties.Settings.Default["Fortnite_Path"] + "/FortniteGame/Binaries/Win64/FortniteLauncher.exe"))
            {
                if (Properties.Settings.Default["Username"] != "")
                {

                    

                    var Fortnite_Path = Folder_Label.Text;
                    Process Fortnite = new Process()
                    {
                        StartInfo =
                        {
                            FileName = Fortnite_Path + "/FortniteGame/Binaries/Win64/FortniteLauncher.exe",
                            Arguments =  $"{Properties.Settings.Default["Argument"]} -NOSSLPINNING -skippatchcheck -epicportal -HTTP=WinINet -AUTH_LOGIN={Properties.Settings.Default["Username"]} -AUTH_PASSWORD=unused -AUTH_TYPE=epic",
                            CreateNoWindow = Properties.Settings.Default["Logs"].ToString() == "True",
                            WorkingDirectory = Fortnite_Path + "/FortniteGame/Binaries/Win64/"
                        }
                    };
                    Fortnite.Start();
                    System.Threading.Thread.Sleep(12000);
                    var processes = Process.GetProcessesByName("FortniteClient-Win64-Shipping");
                    foreach (var process in processes)
                    {
                        Injector.Injector.InjectDll(process.Id, StringClientBypass);
                        new InjectMessagexaml(process.Id, StringMemoryLeakFixerPatch, StringMemoryClientDLLPatchImportant).Show();

                    }
                }
                else
                {
                    if (Properties.Settings.Default["Fortnite_Path"] == "fr")
                    {
                        new Message("Erreur", "Veuillez saisir un nom d'utilisateur dans les paramètres.", 110, 360).Show();
                    }
                    if (Properties.Settings.Default["Fortnite_Path"] == "en-US")
                    {
                        new Message("Error", "Please enter a user name in the settings.", 110, 360).Show();
                    }
                    if (Properties.Settings.Default["Fortnite_Path"] == "de")
                    {
                        new Message("Fehler", "Bitte geben Sie in den Einstellungen einen Benutzernamen ein.", 110, 360).Show();
                    }
                }
            }
            else
            {
                if (Properties.Settings.Default["Fortnite_Path"] == "fr")
                {
                    new Message("Erreur", "Dossier d'installation de Fortnite invalide.", 110, 350).Show();
                }
                if (Properties.Settings.Default["Fortnite_Path"] == "en-US")
                {
                    new Message("Error", "Invalid Fortnite installation folder.", 110, 350).Show();
                }
                if (Properties.Settings.Default["Fortnite_Path"] == "de")
                {
                    new Message("Fehler", "Ungültiger Installationsordner von Fortnite.", 110, 350).Show();
                }
            }
        }
        private void DownloadFiles(string StringClientBypass, string StringMemoryLeakFixerPatch, string StringMemoryClientDLLPatchImportant, string FortniteLauncherImportant)
        {
            if (File.Exists(Properties.Settings.Default["Fortnite_Path"] + "/FortniteGame/Binaries/Win64/FortniteLauncher.exe"))
            {
                if (!File.Exists(StringClientBypass))
                {
                    File.Delete(Properties.Settings.Default["Fortnite_Path"] + "/FortniteGame/Binaries/Win64/FortniteLauncher.exe");
                    try
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("https://cosmosfn.xyz/CosmosManager/FortniteLauncherV2.exe", FortniteLauncherImportant);
                    }
                    catch (WebException ex)
                    {
                        if (Properties.Settings.Default["Fortnite_Path"] == "fr")
                        {
                            new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows - ClientDLLV2 !\nSinon, désactiver votre antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "en-US")
                        {
                            new Message("Error", "Cosmos may be unavailable or synchronize date and time in your windows settings - ClientDLLV2 !\nOtherwise, disable your antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "de")
                        {
                            new Message("Erreur", "Cosmos ist möglicherweise nicht verfügbar oder synchronisieren Sie Datum und Uhrzeit in Ihren Windows-Einstellungen - ClientDLLV2 !\nAndernfalls deaktivieren Sie Ihr Antivirenprogramm.", 125, 670).Show();
                        }
                    }
                }

                string StringPacthLibCrypto = Properties.Settings.Default["Fortnite_Path"] + "/FortniteGame/Binaries/Win64/libcrypto-1_1-x64.dll";
                if (!File.Exists(StringPacthLibCrypto))
                {
                    try
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("https://cosmosfn.xyz/CosmosManager/libcrypto-1_1-x64.dll", StringPacthLibCrypto);
                    }
                    catch (WebException ex)
                    {
                        if (Properties.Settings.Default["Fortnite_Path"] == "fr")
                        {
                            new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows - ClientDLLV2 !\nSinon, désactiver votre antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "en-US")
                        {
                            new Message("Error", "Cosmos may be unavailable or synchronize date and time in your windows settings - ClientDLLV2 !\nOtherwise, disable your antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "de")
                        {
                            new Message("Erreur", "Cosmos ist möglicherweise nicht verfügbar oder synchronisieren Sie Datum und Uhrzeit in Ihren Windows-Einstellungen - ClientDLLV2 !\nAndernfalls deaktivieren Sie Ihr Antivirenprogramm.", 125, 670).Show();
                        }
                    }
                }

                string StringPacthLibssl = Properties.Settings.Default["Fortnite_Path"] + "/FortniteGame/Binaries/Win64/libssl-1_1-x64.dll";
                if (!File.Exists(StringPacthLibssl))
                {
                    try
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("https://cosmosfn.xyz/CosmosManager/libssl-1_1-x64.dll", StringPacthLibssl);
                    }
                    catch (WebException ex)
                    {
                        if (Properties.Settings.Default["Fortnite_Path"] == "fr")
                        {
                            new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows - ClientDLLV2 !\nSinon, désactiver votre antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "en-US")
                        {
                            new Message("Error", "Cosmos may be unavailable or synchronize date and time in your windows settings - ClientDLLV2 !\nOtherwise, disable your antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "de")
                        {
                            new Message("Erreur", "Cosmos ist möglicherweise nicht verfügbar oder synchronisieren Sie Datum und Uhrzeit in Ihren Windows-Einstellungen - ClientDLLV2 !\nAndernfalls deaktivieren Sie Ihr Antivirenprogramm.", 125, 670).Show();
                        }
                    }
                }


                string StringPacthPackPleasent1 = Properties.Settings.Default["Fortnite_Path"] + "/FortniteGame/Content/Paks/pakchunkPleasantFix-WindowsClient.pak";
                if (!File.Exists(StringPacthPackPleasent1))
                {
                    try
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("https://cosmosfn.xyz/CosmosManager/Paks/pakchunkPleasantFix-WindowsClient.pak", StringPacthPackPleasent1);
                    }
                    catch (WebException ex)
                    {
                        if (Properties.Settings.Default["Fortnite_Path"] == "fr")
                        {
                            new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows - ClientDLLV2 !\nSinon, désactiver votre antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "en-US")
                        {
                            new Message("Error", "Cosmos may be unavailable or synchronize date and time in your windows settings - ClientDLLV2 !\nOtherwise, disable your antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "de")
                        {
                            new Message("Erreur", "Cosmos ist möglicherweise nicht verfügbar oder synchronisieren Sie Datum und Uhrzeit in Ihren Windows-Einstellungen - ClientDLLV2 !\nAndernfalls deaktivieren Sie Ihr Antivirenprogramm.", 125, 670).Show();
                        }
                    }
                }


                string StringPacthPackPleasent2 = Properties.Settings.Default["Fortnite_Path"] + "/FortniteGame/Content/Paks/pakchunkPleasantFix-WindowsClient.sig";
                if (!File.Exists(StringPacthPackPleasent2))
                {
                    try
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("https://cosmosfn.xyz/CosmosManager/Paks/pakchunkPleasantFix-WindowsClient.sig", StringPacthPackPleasent2);
                    }
                    catch (WebException ex)
                    {
                        if (Properties.Settings.Default["Fortnite_Path"] == "fr")
                        {
                            new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows - ClientDLLV2 !\nSinon, désactiver votre antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "en-US")
                        {
                            new Message("Error", "Cosmos may be unavailable or synchronize date and time in your windows settings - ClientDLLV2 !\nOtherwise, disable your antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "de")
                        {
                            new Message("Erreur", "Cosmos ist möglicherweise nicht verfügbar oder synchronisieren Sie Datum und Uhrzeit in Ihren Windows-Einstellungen - ClientDLLV2 !\nAndernfalls deaktivieren Sie Ihr Antivirenprogramm.", 125, 670).Show();
                        }
                    }
                }

                if (!File.Exists(StringClientBypass))
                {
                    try
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("https://cosmosfn.xyz/CosmosManager/ClientBypassV5.dll", StringClientBypass);
                    }
                    catch (WebException ex)
                    {
                        if (Properties.Settings.Default["Fortnite_Path"] == "fr")
                        {
                            new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows - ClientDLLV2 !\nSinon, désactiver votre antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "en-US")
                        {
                            new Message("Error", "Cosmos may be unavailable or synchronize date and time in your windows settings - ClientDLLV2 !\nOtherwise, disable your antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "de")
                        {
                            new Message("Erreur", "Cosmos ist möglicherweise nicht verfügbar oder synchronisieren Sie Datum und Uhrzeit in Ihren Windows-Einstellungen - ClientDLLV2 !\nAndernfalls deaktivieren Sie Ihr Antivirenprogramm.", 125, 670).Show();
                        }
                    }
                }

                if (!File.Exists(StringMemoryLeakFixerPatch))
                {
                    try
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("https://cosmosfn.xyz/CosmosManager/MemoryLeakFixer.dll", StringMemoryLeakFixerPatch);
                    }
                    catch (WebException ex)
                    {
                        if (Properties.Settings.Default["Fortnite_Path"] == "fr")
                        {
                            new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows - ClientDLLV2 !\nSinon, désactiver votre antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "en-US")
                        {
                            new Message("Error", "Cosmos may be unavailable or synchronize date and time in your windows settings - ClientDLLV2 !\nOtherwise, disable your antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "de")
                        {
                            new Message("Erreur", "Cosmos ist möglicherweise nicht verfügbar oder synchronisieren Sie Datum und Uhrzeit in Ihren Windows-Einstellungen - ClientDLLV2 !\nAndernfalls deaktivieren Sie Ihr Antivirenprogramm.", 125, 670).Show();
                        }
                    }
                }
                /*
                                if (!File.Exists(StringClientBypassV2))
                                {
                                    try
                                    {
                                        WebClient webClient = new WebClient();
                                        webClient.DownloadFile("https://cosmosfn.xyz/CosmosManager/Pla.dll", StringMemoryLeakFixerPatch);
                                    }
                                    catch (WebException ex)
                                    {
                                        new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows - MemoryLeak !\nSinon, désactiver votre antivirus.", 125, 670).Show();
                                    }
                                }*/

                if (!File.Exists(StringMemoryClientDLLPatchImportant))
                {
                    try
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("https://cosmosfn.xyz/CosmosManager/ClientDLL.dll", StringMemoryClientDLLPatchImportant);
                    }
                    catch (WebException ex)
                    {
                        if (Properties.Settings.Default["Fortnite_Path"] == "fr")
                        {
                            new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows - ClientDLLV2 !\nSinon, désactiver votre antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "en-US")
                        {
                            new Message("Error", "Cosmos may be unavailable or synchronize date and time in your windows settings - ClientDLLV2 !\nOtherwise, disable your antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "de")
                        {
                            new Message("Erreur", "Cosmos ist möglicherweise nicht verfügbar oder synchronisieren Sie Datum und Uhrzeit in Ihren Windows-Einstellungen - ClientDLLV2 !\nAndernfalls deaktivieren Sie Ihr Antivirenprogramm.", 125, 670).Show();
                        }
                    }
                }
                else
                {
                    File.Delete(StringMemoryClientDLLPatchImportant);
                    try
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("https://cosmosfn.xyz/CosmosManager/ClientDLL.dll", StringMemoryClientDLLPatchImportant);
                    }
                    catch (WebException ex)
                    {
                        if (Properties.Settings.Default["Fortnite_Path"] == "fr")
                        {
                            new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows - ClientDLLV2 !\nSinon, désactiver votre antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "en-US")
                        {
                            new Message("Error", "Cosmos may be unavailable or synchronize date and time in your windows settings - ClientDLLV2 !\nOtherwise, disable your antivirus.", 125, 670).Show();
                        }
                        if (Properties.Settings.Default["Fortnite_Path"] == "de")
                        {
                            new Message("Erreur", "Cosmos ist möglicherweise nicht verfügbar oder synchronisieren Sie Datum und Uhrzeit in Ihren Windows-Einstellungen - ClientDLLV2 !\nAndernfalls deaktivieren Sie Ihr Antivirenprogramm.", 125, 670).Show();
                        }
                    }
                }
            }
        }

        private void Folder_btn_Click(object sender, RoutedEventArgs e)
        {
            var folderDlg = new System.Windows.Forms.FolderBrowserDialog();
            DialogResult result = folderDlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(folderDlg.SelectedPath + "/FortniteGame/Binaries/Win64/FortniteLauncher.exe"))
                {
                    Folder_Label.Text = folderDlg.SelectedPath;
                    Properties.Settings.Default["Fortnite_Path"] = folderDlg.SelectedPath;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    if (Properties.Settings.Default["Fortnite_Path"] == "fr")
                    {
                        new Message("Erreur", "Dossier d'installation de Fortnite invalide.", 110, 350).Show();
                    }
                    if (Properties.Settings.Default["Fortnite_Path"] == "en-US")
                    {
                        new Message("Error", "Invalid Fortnite installation folder.", 110, 350).Show();
                    }
                    if (Properties.Settings.Default["Fortnite_Path"] == "de")
                    {
                        new Message("Fehler", "Ungültiger Installationsordner von Fortnite.", 110, 350).Show();
                    }
                }
            }
        }

        private void Discord_btn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.discord.gg/cosmos") { UseShellExecute = true });
        }

        private void Help_btn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://discord.com/channels/989199793362436177/989268371482759248") { UseShellExecute = true });
        }

        private void Settings_btn_Click(object sender, RoutedEventArgs e)
        {
            new Settings().Show();
        }
        private void Update()
        {
            WebClient webClient = new WebClient();
            if (!webClient.DownloadString("https://cosmosfn.xyz/CosmosManager/versioncheck.txt").Contains(version))
            {
                var Update_Fenetre = new Update();
                Update_Fenetre.Show();
                this.Close();
            }
        }
        private void Discord()
        {
            var client = new DiscordRpcClient("996719729085530182");
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = "discord.gg/cosmos",
                State = "Dans le lanceur",
                Buttons = new DiscordRPC.Button[]
                   {
                    new DiscordRPC.Button() { Label = "Discord", Url = "https://discord.gg/cosmos" },
                   },
                Assets = new DiscordRPC.Assets()
                {
                    LargeImageKey = "bannier_v1",
                    LargeImageText = "Cosmos Battle Royale",
                }
            });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CosmosServerProcess.Kill();
            CosmosServerProcess.CloseMainWindow();
            SupprimeProcess("FortniteClient-Win64-Shipping.exe");
            SupprimeProcess("FortniteLauncher.exe");
        }
    }
}
