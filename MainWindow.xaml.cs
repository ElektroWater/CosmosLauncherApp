using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CosmosLauncherApp;
using DiscordRPC;

namespace CosmosLauncherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string version = "1.0.0";
        int id;
        public MainWindow()
        {
            InitializeComponent();
            Folder_Label.Text = Properties.Settings.Default["Fortnite_Path"].ToString();
            Update(false);
            Discord();
        }

        private void Launch_btn_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Properties.Settings.Default["Fortnite_Path"] + "/FortniteGame/Binaries/Win64/FortniteLauncher.exe"))
            {
                if (Properties.Settings.Default["Username"] != null)
                {
                    var Fortnite_Path = Folder_Label.Text;
                    Process Fortnite = new Process()
                    {
                        StartInfo =
                        {
                            FileName = Fortnite_Path + "/FortniteGame/Binaries/Win64/FortniteLauncher.exe",
                            Arguments = $"{Properties.Settings.Default["Argument"]} -NOSSLPINNING -skippatchcheck -epicportal -skippatchcheck -NOSSLPINNING -NoCodeGuards -HTTP=WinINet -AUTH_LOGIN={Properties.Settings.Default["Username"]} -AUTH_PASSWORD=unused -AUTH_TYPE=epic"
                        }
                    };
                    Fortnite.Start();
                    id = Fortnite.Id;
                    //new Message("Erreur", Fortnite.Id, 110, 500).Show();
                }
                else
                {
                    new Message("Erreur", "Veuillez saisir un nom d'utilisateur dans les paramètres.", 110, 350).Show();
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

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            Update(true);
        }
        private void Update(bool message)
        {
            WebClient webClient = new WebClient();
            if(!webClient.DownloadString("https://pastebin.com/raw/0pJiM8gX").Contains(version))
            {
                var Update_Fenetre = new Update();
                Update_Fenetre.Show();
            } else
            {
                if (message)
                {
                    new Message("Mise à jour", "Vous êtes à jour", 110, 350).Show();
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
                Assets = new Assets()
                {
                    LargeImageKey = "bannier_v1",
                    LargeImageText = "Cosmos Battle Royale",
                }
            });
        }
    }
}
