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
        public OrderList parentList;
        public bool _notOrderedYet;
        public bool notOrderedYet
        {
            set
            {
                _notOrderedYet = value;
                if (value)
                {
                    xButton.Visibility = Visibility.Visible;
                    xButton.Content = "X";
                }
                else
                {
                    if (menuItem.type != "Drink")
                    {
                        xButton.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        xButton.Content = "Refill";
                    }
                    
                }
            }
            get
            {
                return _notOrderedYet;
            }
        }
        public MenuItem _menuItem;
        public MenuItem menuItem
        {
            set
            {
                this.label.Text = value.title + " - " + Math.Round(value.Price,2).ToString("0.00");
                this._menuItem = value;
            }
            get
            {
                return this._menuItem;
            }
        }
       
        public OrderMenuItem()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (notOrderedYet || menuItem.type != "Drink")
            {
                parentList.removeOrderItem(this);
            }
            else
            {
                parentList.addItem(this.menuItem);
            }
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            label.Width = ActualWidth * 0.8;
            xButton.Width = ActualWidth * 0.2;
        }
    }
}
