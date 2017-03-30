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
    /// Interaction logic for OrderMenuItem.xaml
    /// </summary>
    public partial class OrderMenuItem : UserControl
    {
        public MenuItem menuItem
        {
            set
            {
                this.label.Content = value.title + " - " + Math.Round(value.Price,2).ToString("0.00");
            }
        }
       
        public OrderMenuItem()
        {
            InitializeComponent();
        }
    }
}
