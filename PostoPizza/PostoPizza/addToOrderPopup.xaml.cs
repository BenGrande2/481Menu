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
    /// Interaction logic for addToOrderPopup.xaml
    /// </summary>
    public partial class addToOrderPopup : UserControl
    {
        private Order _order;
        public Order order
        {
            set
            {
                OrderList ol = value.OrderLists.Children[1] as OrderList;
                if (ol != null)
                {
                    SelectOrderPopup pop = new SelectOrderPopup();
                    pop.popup = this;
                    pop.Margin = new Thickness(0, 0, 0, 0);
                
                    Page.Children.Add(pop);
                }
                this._order = value;
            }
            get
            {
                return _order;
            }
        }
        public MenuItem food;
        public Rectangle cover;
        public addToOrderPopup()
        {
            InitializeComponent();
        }

        private void resize(object sender, SizeChangedEventArgs e)
        {

        }
        public int childVal = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (food.isMod)
            {
                for (int j = 0; j < food.ingredients.Length; j++)
                {
                    food.Price += food.ingredients[j].cost;
                    if (food.ingredients[j].mod == true || food.ingredients[j].quantity != "Regular")
                    {
                        food.title += " + " + food.ingredients[j].quantity + " " + food.ingredients[j].name;
                    }
                }
            }
            (order.OrderLists.Children[childVal] as OrderList).addItem(food);
            Food foodS = ((this.Parent as Grid).Parent as Food);
            Drink drinkS = ((this.Parent as Grid).Parent as Drink);
            CustomizePizza pizzaS = ((this.Parent as Grid).Parent as CustomizePizza);
            if (foodS != null)
            {
                foodS.Page.Children.Remove(cover);
                foodS.Page.Children.Remove(this);
            }
            if (drinkS != null)
            {
                drinkS.Page.Children.Remove(cover);
                drinkS.Page.Children.Remove(this);
            }
            if (pizzaS != null)
            {
                pizzaS.Page.Children.Remove(cover);
                pizzaS.Page.Children.Remove(this);
                pizzaS.backToHome();
            }


            // (this.Parent as Food).Page.Children.Remove(this);
            // this.Parent.Page.Controls.Remove(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (food.isMod)
            {
                for (int j = 0; j < food.ingredients.Length; j++)
                {
                    food.Price += food.ingredients[j].cost;
                    if (food.ingredients[j].mod == true || food.ingredients[j].quantity != "Regular")
                    {
                        food.title += " + " + food.ingredients[j].quantity + " " + food.ingredients[j].name;
                    }
                }
            }
            (order.OrderLists.Children[childVal] as OrderList).addItem(food);
            Food foodS = ((this.Parent as Grid).Parent as Food);
            Drink drinkS = ((this.Parent as Grid).Parent as Drink);
            CustomizePizza pizzaS = ((this.Parent as Grid).Parent as CustomizePizza);
            if (foodS != null)
            {
                foodS.changeToOrder();
                foodS.Page.Children.Remove(cover);
                foodS.Page.Children.Remove(this);
            }
            if (drinkS != null)
            {
                drinkS.changeToOrder();
                drinkS.Page.Children.Remove(cover);
                drinkS.Page.Children.Remove(this);
            }
            if (pizzaS != null)
            {
                pizzaS.changeToOrder();
                pizzaS.Page.Children.Remove(cover);
                pizzaS.Page.Children.Remove(this);
                pizzaS.backToHome();
            }
        }
    }
}
