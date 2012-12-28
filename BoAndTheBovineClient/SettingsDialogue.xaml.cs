using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace BoAndTheBovineClient
{
    /// <summary>This window is the dialogue for settings.
    /// As by the time of writing it is just an About dialogue and hardly that.
    /// </summary>
    public partial class SettingsDialogue : Window
    {
        private readonly SettingsDialogueViewModel _viewmodel = new SettingsDialogueViewModel();

        public SettingsDialogue()
        {
            InitializeComponent();
            base.DataContext = _viewmodel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            _viewmodel.Version = version.ToString();
        }

        private void CloseButton_Click(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
