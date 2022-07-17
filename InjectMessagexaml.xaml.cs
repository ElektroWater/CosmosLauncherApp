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
    /// Logique d'interaction pour InjectMessagexaml.xaml
    /// </summary>
    public partial class InjectMessagexaml : Window
    {
        int FortniteProcessId;
        string StringMemoryLeakFixerPatch;
        string StringMemoryClientDLLPatchImportant;
        public InjectMessagexaml(int id, string MemoryLeakFixer, string ClientDLL)
        {
            InitializeComponent();
            FortniteProcessId = id;
            StringMemoryLeakFixerPatch = MemoryLeakFixer;
            StringMemoryClientDLLPatchImportant = ClientDLL;
        }

        private void Ok_btn_Click(object sender, RoutedEventArgs e)
        {
            Injector.Injector.InjectDll(FortniteProcessId, StringMemoryLeakFixerPatch);
            Injector.Injector.InjectDll(FortniteProcessId, StringMemoryClientDLLPatchImportant);
            this.Close();
        }
    }
}
