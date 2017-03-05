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
    /// Interaction logic for SpecialItem.xaml
    /// </summary>
    public partial class MenuFoodItem : UserControl
    {
        private MenuItem _menuitem;
        public MenuItem menuItem {
            set
            {
                if (value.ingredients != null)
                {
                    string ings = string.Join<Ingredient>(", ", value.ingredients);
                    Description.Text = value.title + " " + ings + " " + value.Price;
                }
                else
                {
                    Description.Text = value.title;
                }
                _menuitem = value;
            }
            get
            {
                return _menuitem;
            }
        }
        public MenuFoodItem()
        {
            InitializeComponent();
        }
    }
}
