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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Timers;

namespace PostoPizza.Images
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Page
    {
        Timer aTimer;
        public HomeScreen()
        {
            InitializeComponent();
            DateTime now = new DateTime();
            label1.Content = label1.Content = DateTime.Now.ToString("hh:mm");

            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += HandleTimer;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            
                
            

            
        }
        private void HandleTimer(Object source, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {

                label1.Content = DateTime.Now.ToString("hh:mm");
            });
            
        }

        private void openMenu(object sender, MouseButtonEventArgs e)
        {
            aTimer.Stop();
            aTimer.Dispose();
            (Window.GetWindow(this) as MainWindow).openMenu();
        }

        private void resizeHome(object sender, SizeChangedEventArgs e)
        {
            image.Width = this.ActualWidth * 0.9;
            image.Height = this.ActualHeight * 0.8;
            label.FontSize = this.ActualHeight * 0.06;
            label.Margin = new Thickness(0, 0, 0, this.ActualHeight * 0.175);
            button.FontSize = this.ActualHeight * 0.03;
            label1.FontSize = this.ActualHeight * 0.03;
        }
    }
}
