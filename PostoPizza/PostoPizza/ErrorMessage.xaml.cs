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
    /// Interaction logic for ErrorMessage.xaml
    /// </summary>
    public partial class ErrorMessage : UserControl
    {
        public ErrorMessage()
        {
            InitializeComponent();
        }
        public CustomizePizza parent;
        public Rectangle back;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (parent != null)
            {
                parent.Page.Children.Remove(back);
                parent.Page.Children.Remove(this);
                
            }
        }
    }
}
