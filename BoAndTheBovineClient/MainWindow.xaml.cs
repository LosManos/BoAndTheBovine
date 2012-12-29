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
            if (_viewmodel.IsSingleLine)
            {
                _viewmodel.Result =
                    string.Join(
                        Environment.NewLine,
                        Compare(_viewmodel.Actual, _viewmodel.Expected)
                        );
            }
            else
            {
                var compareResult = Bompare.Compare.Execute(_viewmodel.Actual, _viewmodel.Expected);
                for (var i = 0; i < compareResult.StringDifferenceList.Count; ++i)
                {
                    var cmpPair = compareResult.StringDifferenceList[i];
                    var textbox = new TextBox();
                    if (cmpPair.Similar)
                    {
                        textbox.Text = cmpPair.Text1;
                        textbox.Background = (Brush)new BrushConverter().ConvertFrom("#67E667");
                    }
                    else
                    {
                        textbox.Text = cmpPair.Text1 + Environment.NewLine + cmpPair.Text2;
                        textbox.Background = (Brush)new BrushConverter().ConvertFrom("#FF7373");
                    }

                    var stackpanel = new StackPanel() {Orientation = Orientation.Horizontal};
                    stackpanel.Children.Add(
                        new Label() {Content = i.ToString()}
                        );
                    stackpanel.Children.Add(textbox);
                    ResultStackpanel.Children.Add(stackpanel);
                }
            }
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

        private void OpenActualFileButton_Click(object sender, RoutedEventArgs e)
        {
#if DEBUG
            //HACK.  This is for some fast debugging.
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                _viewmodel.ExpectedPathAndFilename = "Z:\\Documents\\Development\\Projects\\EverCoow\\EverCoow.Net\\EverCoow\\EverCoow.UnitTest\\Data\\ MyArticlesChapter2.enex";
                _viewmodel.Expected = ReadTextOfFile(_viewmodel.ExpectedPathAndFilename);
                _viewmodel.ActualPathAndFilename = "Z:\\Documents\\Development\\Projects\\EverCoow\\EverCoow.Net\\EverCoow\\EverCoow.UnitTest\\Data\\ArticleAsPlaceholder.enex";
                _viewmodel.Actual = ReadTextOfFile(_viewmodel.ActualPathAndFilename);
                return;
            }
#endif
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

        private void ShowSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new SettingsDialogue();
            wnd.ShowDialog();
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

        private static IEnumerable<string> Compare(string s1, string s2)
        {
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
