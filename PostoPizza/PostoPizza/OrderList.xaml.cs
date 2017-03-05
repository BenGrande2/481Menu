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
        
        private MenuItem[] alreadyOrderedList = { new MenuItem("Test Item", 43.00), new MenuItem("Pizza", 32.00), new MenuItem("Beer", 5.50) };
        private MenuItem[] notOrderedList = { new MenuItem("Test Item2", 44.00), new MenuItem("Wine", 36.00), new MenuItem("Bread Appetizer", 12.00) };

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

        private void resizeOrderlist(object sender, SizeChangedEventArgs e)
        {
            orderListStack.Width = alreadyOrderedLabel.ActualWidth * 1.5;
            for (int i = 0; i < alreadyOrderedList.Length; i++)
            {
                OrderMenuItem or = AlreadyOrdered.Children[i] as OrderMenuItem;
                or.FontSize = this.ActualHeight * 0.03;
            }
            for (int i = 0; i < notOrderedList.Length; i++)
            {
                OrderMenuItem or = NotOrderedYet.Children[i] as OrderMenuItem;
                or.FontSize = this.ActualHeight * 0.03;
            }
        }
    }
}
