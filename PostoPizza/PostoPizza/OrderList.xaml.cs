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
        public Order order;
        public OrderList()
        {
            InitializeComponent();
            updateDisplay(true, null);
            resizeSides();
            AlreadyOrdered.Width = ActualWidth*0.8;
            NotOrderedYet.Width = ActualWidth * 0.8;
           

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
                    ord.parentList = this;
                    ord.menuItem = alreadyOrderedList[i];
                    ord.notOrderedYet = false;
                    AlreadyOrdered.Children.Add(ord);
                }

                alreadyOrderedList.Clear();
                notOrderedList.Clear();
                this.total.Content = "Total: $" + Math.Round(_price, 2).ToString("0.00");
            }

            OrderMenuItem or = new OrderMenuItem();
            or.parentList = this;
            if (item != null)
            {
                or.menuItem = item;
                or.notOrderedYet = true;
                NotOrderedYet.Children.Add(or);
            }
            if (order != null)
            {
                order.resizeSides();
            }
            resizeSides();
            //notOrderedList.Clear();
            //resizeOrderlist(null, null);
            AlreadyOrdered.Width = ActualWidth * 0.8;
            NotOrderedYet.Width = ActualWidth * 0.8;
        }
        private void resizeSides()
        {
            if (NotOrderedYet.Children.Count == 0)
            {
                Chef.Height = AlreadyOrdered.ActualHeight;
                Coil.Height = 0.0;
            }
            else
            {
                Chef.Height = AlreadyOrdered.ActualHeight;
                Coil.Height = NotOrderedYet.ActualHeight;
            }
            
        }

        private void resizeOrderlist(object sender, SizeChangedEventArgs e)
        {
            /*orderListStack.Width = alreadyOrderedLabel.ActualWidth * 1.5;
            AlreadyOrdered.Width = ActualWidth;
            NotOrderedYet.Width = ActualWidth;
            for (int i = 0; i < AlreadyOrdered.Children.Count; i++)
            {
                OrderMenuItem or = AlreadyOrdered.Children[i] as OrderMenuItem;
                or.Width = this.ActualWidth;
                or.FontSize = this.ActualHeight * 0.03;
            }
            for (int i = 0; i < NotOrderedYet.Children.Count; i++)
            {
                OrderMenuItem or = NotOrderedYet.Children[i] as OrderMenuItem;
                or.Width = this.ActualWidth;
                or.FontSize = this.ActualHeight * 0.03;
            }
            resizeSides();*/

        }

        /// <summary>
        /// Takes in each item to be added to notOrderedList
        /// </summary>
        /// <param name="item"></param>
        public void addItem(MenuItem item)
        {
            //add item to 
            notOrderedList.Add(item);
            order.resizeSides();
            //update price
            _price += item.Price;

            //update display
            updateDisplay(false, item);
            resizeSides();
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
            resizeSides();
        }
        public void removeOrderItem(OrderMenuItem item)
        {
            _price -= item.menuItem.Price;
            notOrderedList.Remove(item.menuItem);
            NotOrderedYet.Children.Remove(item);
            resizeSides();
        }
    }
}
