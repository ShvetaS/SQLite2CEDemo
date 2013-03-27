using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Threading;
using Microsoft.Phone.Shell;
 
namespace SQLite2CEDemo
{
    public partial class Media : PhoneApplicationPage
    {
        public Media()
        {
            InitializeComponent();
        }
        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Pause();
        }
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Play();
        }
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Stop();
        }

    }
}