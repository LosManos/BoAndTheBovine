using System.IO;
using Microsoft.Win32;
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
using System.Windows.Navigation;

namespace BoAndTheBovineClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewmodel = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
            base.DataContext = _viewmodel;
            _viewmodel.Actual = "actual text";
            _viewmodel.Expected = "expected text";
            _viewmodel.Result = "resulting diff";
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(0);
        }

        private void CompareButton_Click(object sender, RoutedEventArgs e)
        {
            _viewmodel.Result =
                string.Join(
                    Environment.NewLine,
                    Compare(_viewmodel.Actual, _viewmodel.Expected)
                );
        }

        private void CopyFromVS2012Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var text = Clipboard.GetText();

                Tuple<string, string> strings = WashFromVSResult(text);

                _viewmodel.Expected = strings.Item1;
                _viewmodel.Actual = strings.Item2;

                _viewmodel.Result =
                    string.Join(
                        Environment.NewLine,
                        Compare(_viewmodel.Actual, _viewmodel.Expected)
                    );
            }
            catch (Exception)
            {
                MessageBox.Show("Something when wrong.  Did you copy the text from the unit test output of VS2012 or is it something wrong inside BoandtheBovine?",
                    "Bo and the Bovine", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenExpectedFileButton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
                {
                    Multiselect = true
                };
            var res = dlg.ShowDialog();
            if (res.Value)
            {
                switch (dlg.FileNames.Length)
                {
                    case 0:
                        MessageBox.Show("Nothing was selected and nothing is updated.  Select 1 or 2.");
                        return;
                    case 1:
                        _viewmodel.ExpectedPathAndFilename = dlg.FileNames.Single();
                        _viewmodel.Expected = ReadTextOfFile(_viewmodel.ExpectedPathAndFilename);
                        return;
                    case 2:
                        _viewmodel.ExpectedPathAndFilename = dlg.FileNames[0];
                        _viewmodel.Expected = ReadTextOfFile(_viewmodel.ExpectedPathAndFilename);
                        _viewmodel.ActualPathAndFilename = dlg.FileNames[1];
                        _viewmodel.Actual = ReadTextOfFile(_viewmodel.ActualPathAndFilename);
                        return;
                    default:
                        MessageBox.Show("Too many files where selected, please limit to 1 or 2.");
                        return;
                }
            }
        }

        /// <summary>This method reads a text document and returns its contents as a string.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        private static string ReadTextOfFile(string path, string filename)
        {
            return ReadTextOfFile(Path.Combine(path, filename));
        }

        /// <summary>This method reads a text document and returns its contents as a string.
        /// </summary>
        /// <param name="pathAndFilename"></param>
        /// <returns></returns>
        private static string ReadTextOfFile(string pathAndFilename)
        {
            string ret = null;
            using (var sr = File.OpenText(pathAndFilename))
            {
                ret = sr.ReadToEnd();
            }
            return ret;
        }
        private void ShowSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new SettingsDialogue();
            wnd.ShowDialog();
        }

        private static IEnumerable<string> Compare( string s1, string s2 ){
            Bompare.CompareResult compareResult = Bompare.Compare.Execute(s1, s2);

            if (compareResult.Similar)
            {
                return new List<string>() { "Similar" };
            }

            var strList = new List<string>();
            foreach (Bompare.CompareResult.StringDifferencePair cmp in compareResult.StringDifferenceList)
            {
                strList.Add(
                    cmp.Similar ?
                    "." + cmp.Text1 :
                    Environment.NewLine +
                    "!" + cmp.Text1 + Environment.NewLine +
                    "!" + cmp.Text2 + Environment.NewLine
                );
            }

            return strList;
        }

        private Tuple<string, string> WashFromVSResult(string outputFromVS2012)
        {
            return Bompare.Wash.FromVS2012TestOutput(outputFromVS2012);
        }

    }
}
