using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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

using TimeNow.Settings;

namespace TimeNow
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();

            this.Closing += SettingsWindow_Closing;
        }

        private void SettingsWindow_Closing(object sender, CancelEventArgs e)
        {
            SettingsManager.Apply();
        }

        private void xLocalization_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ComboBoxItem) xLocalization.SelectedItem;
            SettingsManager.CurrentCulture = new CultureInfo((string)item.Tag);
        }
    }
}
