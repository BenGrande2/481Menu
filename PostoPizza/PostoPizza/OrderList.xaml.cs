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
    /// Interaction logic for OrderList.xaml
    /// </summary>
    public partial class OrderList : UserControl
    {
        
        private MenuItem [] alreadyOrderedList = { new MenuItem("Test Item", 43.00) };
        private MenuItem[] notOrderedList = { new MenuItem("Test Item2", 44.00) };

        public OrderList()
        {
            InitializeComponent();
            
            for (int i = 0; i < alreadyOrderedList.Length; i++)
            {
                OrderMenuItem or = new OrderMenuItem();
                or.menuItem = alreadyOrderedList[i];
                AlreadyOrdered.Children.Add(or);
            }
            for (int i = 0; i < notOrderedList.Length; i++)
            {
                OrderMenuItem or = new OrderMenuItem();
                or.menuItem = notOrderedList[i];
                NotOrderedYet.Children.Add(or);
            }
        }
    }
}
