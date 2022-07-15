using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CosmosLauncherApp
{
    /// <summary>
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            Username_Textbox.Text = Properties.Settings.Default["Username"].ToString();
            Argument_Textbox.Text = Properties.Settings.Default["Argument"].ToString();
            Logs_Checkbox.IsChecked = Properties.Settings.Default["Logs"].ToString() == "True";
        }
        private void Save_Username_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Username_Textbox.Text.Length == 0)
            {
                new Message("Erreur","Vous devez saisir un nom d'utilisateur.", 110, 350).Show();
            }
            else
            {
                Properties.Settings.Default["Username"] = Username_Textbox.Text;
                Properties.Settings.Default.Save();
                new Message("Succès", "Nom d'utilisateur sauvegarder avec succès.", 110, 350).Show();
            }
            
        }

        private void Save_Argument_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default["Argument"] = Argument_Textbox.Text;
            Properties.Settings.Default.Save();
            new Message("Succès", "Arguments additionnels sauvegarder avec succès.", 110, 350).Show();
        }

        private void Save_Logs(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default["Logs"] = Logs_Checkbox.IsChecked;
            Properties.Settings.Default.Save();
            new Message("Succès", "Le paramètre est sauvegarder avec succès.", 110, 350).Show();
        }
    }
}
