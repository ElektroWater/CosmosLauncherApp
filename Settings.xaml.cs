﻿using System;
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
        }
        private void Save_Username_btn_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default["Username"] = Username_Textbox.Text;
            Properties.Settings.Default.Save();
        }

        private void Save_Argument_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default["Argument"] = Argument_Textbox.Text;
            Properties.Settings.Default.Save();
        }
    }
}
