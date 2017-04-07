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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        public AddOrderButton addOrderButton;
        public Order()
        {
            InitializeComponent();
            OrderList orderList = new OrderList();
            orderList.orderNum.Content = "Order #1";
            orderList.order = this;
            

            OrderLists.Children.Add(orderList);
            resizeSides();
            //chefImage.Height = 0;
            AddOrderButton addOrderButton = new AddOrderButton();
            


            //addOrder.Content = "+ Add Order";
            addOrderButton.Button.Click += addOrder_Click;
           
            OrderLists.Children.Add(addOrderButton);
            happyHour = new Image();
            Uri uri = new Uri("Images/happyHour.png", UriKind.Relative);
            happyHour.Source = new BitmapImage(uri);
            happyHour.TouchDown += goHappyHour;
            happyHour.MouseLeftButtonUp += goHappyHour;
            happyHour.MouseDown += goHappyHour;
            happyHour.MouseLeftButtonDown += goHappyHour;
            
            OrderLists.Children.Add(happyHour);
        }
        private void goHappyHour(object sender, TouchEventArgs e)
        {
            nav.tabControl.SelectedIndex = 2;
        }
        private void goHappyHour(object sender, MouseButtonEventArgs e)
        {
            nav.tabControl.SelectedIndex = 2;
        }
        public void resizeSides()
        {
            double maxChef = 0.0;
            double maxCoil = 0.0;
            for (int j = 0; j < OrderLists.Children.Count; j++)
            {

                OrderList orderChild = OrderLists.Children[j] as OrderList;
                if (orderChild != null)
                {
                    if (orderChild.NotOrderedYet.Height > maxCoil)
                    {
                       
                        maxCoil = orderChild.NotOrderedYet.Height;
                    }
                    if (orderChild.AlreadyOrdered.Height > maxChef)
                    {
                        maxChef = orderChild.AlreadyOrdered.Height;
                    }

                }
                
            }
            //chefImage.Height = (OrderLists.Children[0] as OrderList).AlreadyOrdered.ActualHeight;//maxChef;
            //coilImage.Height = (OrderLists.Children[0] as OrderList).NotOrderedYet.ActualHeight; //maxCoil;
        }
        public Image happyHour;
        private void addOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderList order2 = new OrderList();
            order2.orderNum.Content = "Order #2";
            order2.order = this;
            //coilImage.Height = 0;
            
            OrderLists.Children.Add(order2);
            OrderLists.Children.Remove(OrderLists.Children[1]);
            //OrderLists.Children.Remove(addOrderButton);

            OrderLists.Children.Remove(happyHour);
            OrderLists.Children.Add(happyHour);

            resizeOrder(null, null);

        }

        //Send order button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OrderList orderList = OrderLists.Children[0] as OrderList;
            orderList.sendOrder();
            OrderList order2 = OrderLists.Children[1] as OrderList;
            if (order2 != null)
            {
                order2.sendOrder();
            }
        }

        private void resizeOrder(object sender, SizeChangedEventArgs e)
        {
            double third = this.ActualWidth / 3;
            orderBorder.Padding = new Thickness(this.ActualHeight * 0.05);
            sendOrdBtn.FontSize = signalBtn.FontSize = this.ActualHeight * 0.03;
            sendOrdBtn.Margin = new Thickness(this.ActualWidth * 0.05, 0, 0, 0);
            sendOrdBtn.Width = this.ActualWidth / 3.5;
            signalBtn.Width = this.ActualWidth / 3;
            sendOrdBtn.Height = signalBtn.Height = this.ActualHeight * 0.08;
            for (int j = 0; j<OrderLists.Children.Count; j++)
            {
                OrderList orderChild = OrderLists.Children[j] as OrderList;
                if (orderChild != null)
                {
                    orderChild.orderNum.FontSize = orderChild.alreadyOrderedLabel.FontSize = orderChild.notOrderedLabel.FontSize = orderChild.total.FontSize = this.ActualHeight * 0.03;
                    orderChild.Height = ActualHeight * 0.7;
                    orderChild.Width = third;
                }
                AddOrderButton buttonChild = OrderLists.Children[j] as AddOrderButton;
                if (buttonChild != null)
                {
                    buttonChild.Height = ActualHeight * 0.7;
                    buttonChild.Width = third;
                }
                Image imageChild = OrderLists.Children[j] as Image;
                if (imageChild != null)
                {
                    imageChild.Height = ActualHeight * 0.7;
                    imageChild.Width = third;
                }
            }
           // OrderList orderChild = OrderLists.Children[0] as OrderList;
            
        }
        public Navigation nav;
        private void signalBtn_Click(object sender, RoutedEventArgs e)
        {
            nav.call_server(null, null);
        }
    }
}
