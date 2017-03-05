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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        public Order()
        {
            InitializeComponent();
            OrderList orderList = new OrderList();
            orderList.orderNum.Content = "Order #1";
            
            OrderLists.Children.Add(orderList);

            Button addOrder = new Button();
            addOrder.Content = "+ Add Order";
            OrderLists.Children.Add(addOrder);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void resizeOrder(object sender, SizeChangedEventArgs e)
        {
            orderBorder.Padding = new Thickness(this.ActualHeight * 0.05);
            sendOrdBtn.FontSize = signalBtn.FontSize = this.ActualHeight * 0.03;
            sendOrdBtn.Height = signalBtn.Height = this.ActualHeight * 0.08;
            OrderList orderChild = OrderLists.Children[0] as OrderList;
            orderChild.orderNum.FontSize = orderChild.alreadyOrderedLabel.FontSize = orderChild.notOrderedLabel.FontSize = orderChild.total.FontSize = this.ActualHeight * 0.03;
        }
    }
}
