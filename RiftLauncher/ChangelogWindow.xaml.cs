using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace RiftLauncher
{
    /// <summary>
    /// Interaction logic for ChangelogWindow.xaml
    /// </summary>
    public partial class ChangelogWindow : Window
    {
        public ChangelogWindow()
        {
            InitializeComponent();
        }

        private async void Changelog_Loaded(object sender, RoutedEventArgs e)
        {
            string Link = "";
            HttpClient val = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, Link);
            if ((await val.SendAsync(message)).IsSuccessStatusCode)
            {
                view.Visibility = Visibility.Visible;

                view.Source = new Uri(Link);
            }

        }

        private void WebView2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.R)
            {
                view.Reload();
            }
        }

        private void Changelog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            view.Dispose();
        }
    }
}
