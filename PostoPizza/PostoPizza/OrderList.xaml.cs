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
        
        //private MenuItem[] alreadyOrderedList = { new MenuItem("Test Item", 43.00), new MenuItem("Pizza", 32.00), new MenuItem("Beer", 5.50) };
        //private MenuItem[] notOrderedList = { new MenuItem("Test Item2", 44.00), new MenuItem("Wine", 36.00), new MenuItem("Bread Appetizer", 12.00) };
        private List<MenuItem> alreadyOrderedList = new List<MenuItem>();
        private List<MenuItem> notOrderedList = new List<MenuItem>();

        private double _price = 0;

        public OrderList()
        {
            InitializeComponent();
            updateDisplay(true, null);
        }

        private void updateDisplay(bool clear, MenuItem item)
        {
            //clear NotOrderedList only if kitchen button has been pressed
            if (clear == true)
            {
                NotOrderedYet.Children.Clear();

                for (int i = 0; i < alreadyOrderedList.Count; i++)
                {
                    OrderMenuItem ord = new OrderMenuItem();
                    ord.menuItem = alreadyOrderedList[i];
                    AlreadyOrdered.Children.Add(ord);
                }

                alreadyOrderedList.Clear();
                notOrderedList.Clear();
                this.total.Content = "Total: $" + Math.Round(_price, 2).ToString("0.00");
            }

            OrderMenuItem or = new OrderMenuItem();
            if (item != null)
            {
                or.menuItem = item;
                NotOrderedYet.Children.Add(or);
            }
            //notOrderedList.Clear();
        }

        private void resizeOrderlist(object sender, SizeChangedEventArgs e)
        {
            orderListStack.Width = alreadyOrderedLabel.ActualWidth * 1.5;
            for (int i = 0; i < alreadyOrderedList.Count; i++)
            {
                OrderMenuItem or = AlreadyOrdered.Children[i] as OrderMenuItem;
                or.FontSize = this.ActualHeight * 0.03;
            }
            for (int i = 0; i < notOrderedList.Count; i++)
            {
                OrderMenuItem or = NotOrderedYet.Children[i] as OrderMenuItem;
                or.FontSize = this.ActualHeight * 0.03;
            }
        }

        /// <summary>
        /// Takes in each item to be added to notOrderedList
        /// </summary>
        /// <param name="item"></param>
        public void addItem(MenuItem item)
        {
            //add item to 
            notOrderedList.Add(item);

            //update price
            _price += item.Price;

            //update display
            updateDisplay(false, item);
        }

        /// <summary>
        /// Called by event listener for send to kitchen button. Updates total bill and clears Not ordered display
        /// </summary>
        public void sendOrder()
        {
            for(int i = 0; i < notOrderedList.Count; i++)
            {
                alreadyOrderedList.Add(notOrderedList[i]);
            }

            updateDisplay(true, null);
        }
    }
}
