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
    /// Logique d'interaction pour Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        public Message(string title, string message, int height, int width)
        {
            InitializeComponent();
            Message_Label.Content = message;
            this.Title = title;
            this.Height = height;
            this.Width = width;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
