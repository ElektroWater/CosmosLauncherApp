using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CosmosLauncherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string version = "1.0.0";
        public MainWindow()
        {
            InitializeComponent();
            Folder_Label.Text = Properties.Settings.Default["Fortnite_Path"].ToString();
            Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Fortnite_Path = Folder_Label.Text;
            Process Fortnite = new Process();
            Fortnite.StartInfo.FileName = Fortnite_Path + "/FortniteGame/Binaries/Win64/FortniteClient-Win64-Shipping.exe";
            Fortnite.StartInfo.Arguments = $"{Properties.Settings.Default["Argument"]} -skippatchcheck -epicportal -HTTP=WinINet -log -AUTH_LOGIN={Properties.Settings.Default["Username"]} -AUTH_PASSWORD=unused -AUTH_TYPE=epic";
            Fortnite.Start();
        }

        private void Folder_btn_Click(object sender, RoutedEventArgs e)
        {
            var folderDlg = new System.Windows.Forms.FolderBrowserDialog();
            DialogResult result = folderDlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Folder_Label.Text = folderDlg.SelectedPath;
                Properties.Settings.Default["Fortnite_Path"] = folderDlg.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
        private void Update()
        {
            WebClient webClient = new WebClient();
            if(!webClient.DownloadString("https://pastebin.com/raw/0pJiM8gX").Contains(version))
            {
                var Update_Fenetre = new Update();
                Update_Fenetre.Show();
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
            var Update_Settings = new Settings();
            Update_Settings.Show();
        }
    }
}
