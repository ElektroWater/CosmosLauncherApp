using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
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
        public MainWindow()
        {
            InitializeComponent();
            Folder_Label.Text = Properties.Settings.Default["Fortnite_Path"].ToString();
            Discord();
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        private void Launch_btn_Click(object sender, RoutedEventArgs e)
        {
            string StringClientBypass = Properties.Settings.Default["Fortnite_Path"] + "/FortniteGame/Binaries/Win64/ClientBypass.dll";
            string StringMemoryLeakFixerPatch = Properties.Settings.Default["Fortnite_Path"] + "/FortniteGame/Binaries/Win64/MemoryLeakFixer.dll";
            string StringMemoryClientDLLPatchImportant = Properties.Settings.Default["Fortnite_Path"] + "/FortniteGame/Binaries/Win64/api-ClientDLL-x64.dll";
            string FortniteLauncherImportant = Properties.Settings.Default["Fortnite_Path"] + "/FortniteGame/Binaries/Win64/CosmosLauncher.exe";

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
                        //Injector.Injector.InjectDll(process.Id, StringClientBypass);
                        new InjectMessagexaml(process.Id, StringMemoryLeakFixerPatch, StringMemoryClientDLLPatchImportant).Show();

                    }
                }
                else
                {
                    new Message("Erreur", "Veuillez saisir un nom d'utilisateur dans les paramètres.", 110, 360).Show();
                }
            }
            else
            {
                new Message("Erreur", "Dossier d'installation de Fortnite invalide.", 110, 350).Show();
            }
        }
        private void DownloadFiles(string StringClientBypass, string StringMemoryLeakFixerPatch, string StringMemoryClientDLLPatchImportant, string FortniteLauncherImportant)
        {
            if (File.Exists(Properties.Settings.Default["Fortnite_Path"] + "/FortniteGame/Binaries/Win64/FortniteLauncher.exe"))
            {
                if (!File.Exists(FortniteLauncherImportant))
                {
                    try
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("https://download944.mediafire.com/lbcohj9cf4cg/knbmlh3s7m2yu8c/FortniteLauncher.exe", FortniteLauncherImportant);
                    }
                    catch (WebException ex)
                    {
                        new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows !\nSinon, désactiver votre antivirus.", 125, 670).Show();
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
                        new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows !\nSinon, désactiver votre antivirus.", 125, 670).Show();
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
                        new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows !\nSinon, désactiver votre antivirus.", 125, 670).Show();
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
                        new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows !\nSinon, désactiver votre antivirus.", 125, 670).Show();
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
                        new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows !\nSinon, désactiver votre antivirus.", 125, 670).Show();
                    }
                }

                if (!File.Exists(StringClientBypass))
                {
                    try
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("https://cosmosfn.xyz/CosmosManager/ClientBypass.dll", StringClientBypass);
                    }
                    catch (WebException ex)
                    {
                        new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows !\nSinon, désactiver votre antivirus.", 125, 670).Show();
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
                        new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows !\nSinon, désactiver votre antivirus.", 125, 670).Show();
                    }
                }

                if (!File.Exists(StringMemoryClientDLLPatchImportant))
                {
                    try
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("https://cosmosfn.xyz/CosmosManager/ClientDLL.dll", StringMemoryClientDLLPatchImportant);
                    }
                    catch (WebException ex)
                    {
                        new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows !\nSinon, désactiver votre antivirus.", 125, 670).Show();
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
                        new Message("Erreur", "Cosmos est peut être indisponible ou synchroniser date et heures dans vos paramètres windows !\nSinon, désactiver votre antivirus.", 125, 670).Show();
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
                    new Message("Erreur", "Dossier d'installation de Fortnite invalide.", 110, 350).Show();
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
    }
}
