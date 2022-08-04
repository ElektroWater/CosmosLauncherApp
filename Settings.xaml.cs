using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            var lang = Properties.Settings.Default.language;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            InitializeComponent();
            Lang();
            Username_Textbox.Text = Properties.Settings.Default["Username"].ToString();
            Argument_Textbox.Text = Properties.Settings.Default["Argument"].ToString();
            Logs_Checkbox.IsChecked = Properties.Settings.Default["Logs"].ToString() == "True";
            Logs_Checkbox_Server.IsChecked = Properties.Settings.Default["Logs_Server"].ToString() == "True";
        }

        private void Lang()
        {
            if (Properties.Settings.Default.language == "fr")
            {
                comboBox_Lang.SelectedIndex = 0;
            }
            if (Properties.Settings.Default.language == "en-US")
            {
                comboBox_Lang.SelectedIndex = 1;
            }
            if (Properties.Settings.Default.language == "de")
            {
                comboBox_Lang.SelectedIndex = 2;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboBox_Lang.SelectedIndex == 0)
            {
                Properties.Settings.Default.language = "fr";
            }
            if (comboBox_Lang.SelectedIndex == 1)
            {
                Properties.Settings.Default.language = "en-US";
            }
            if (comboBox_Lang.SelectedIndex == 2)
            {
                Properties.Settings.Default.language = "de";
            }
            Properties.Settings.Default.Save();
        }

        private void Logs_Checkbox_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default["Logs"] = Logs_Checkbox.IsChecked;
            Properties.Settings.Default.Save();
        }

        private void Logs_Checkbox_Server_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default["Logs_Server"] = Logs_Checkbox_Server.IsChecked;
            Properties.Settings.Default.Save();
        }

        private void Username_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Properties.Settings.Default["Username"] = Username_Textbox.Text;
            Properties.Settings.Default.Save();
        }

        private void Argument_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Properties.Settings.Default["Argument"] = Argument_Textbox.Text;
            Properties.Settings.Default.Save();
        }
    }
}
