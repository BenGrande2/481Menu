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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PostoPizza
{
    /// <summary>
    /// Interaction logic for SelectOrderPopup.xaml
    /// </summary>
    public partial class SelectOrderPopup : UserControl
    {
        public SelectOrderPopup()
        {
            InitializeComponent();
        }
        public addToOrderPopup popup;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            popup.childVal = 0;
            popup.Page.Children.Remove(this);
               
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            popup.childVal = 1;
            popup.Page.Children.Remove(this);
               
        }
    }
}
