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
    /// Interaction logic for PizzaAddon.xaml
    /// </summary>
    public partial class PizzaAddon : UserControl
    {
        public CustomizePizza customize;
        public PizzaAddon()
        {
            InitializeComponent();
        }
        private void cancel_add(object sender, RoutedEventArgs e)
        {
            customize.Page.Children.Remove(this);
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            //(order.OrderLists.Children[0] as OrderList).addItem(food);
            //customize.Page.Children.Remove(cover);
            CheckBox[] boxes = new CheckBox[] { proscuitto, anchovy, egg, truffleOil, Arugula, smoked_pancetta, sausage, salami, tomato, gorgonzola, calabrese };
            int count = 0;
            for (int j = 0; j < boxes.Length; j++)
            {
                if (boxes[j].IsChecked == true)
                {
                    count++;
                }
            }
            if (count + customize.ingCount() <= 7)
            {
                if (proscuitto.IsChecked == true)
                {
                    customize.addIngredient(new Ingredient("proscuitto", 3, true));
                }
                if (anchovy.IsChecked == true)
                {
                    customize.addIngredient(new Ingredient("anchovy", 3, true));
                }
                if (egg.IsChecked == true)
                {
                    customize.addIngredient(new Ingredient("egg", 3, true));
                }
                if (truffleOil.IsChecked == true)
                {
                    customize.addIngredient(new Ingredient("truffle oil", 3, true));
                }
                if (Arugula.IsChecked == true)
                {
                    customize.addIngredient(new Ingredient("arugula", 3, true));
                }
                if (smoked_pancetta.IsChecked == true)
                {
                    customize.addIngredient(new Ingredient("smoked pancetta", 6, true));
                }
                if (sausage.IsChecked == true)
                {
                    customize.addIngredient(new Ingredient("sausage", 6, true));
                }
                if (salami.IsChecked == true)
                {
                    customize.addIngredient(new Ingredient("salami", 6, true));
                }
                if (tomato.IsChecked == true)
                {
                    customize.addIngredient(new Ingredient("tomato", 6, true));
                }
                if (gorgonzola.IsChecked == true)
                {
                    customize.addIngredient(new Ingredient("gorgonzola", 6, true));
                }
                if (calabrese.IsChecked == true)
                {
                    customize.addIngredient(new Ingredient("calabrese", 6, true));
                }
                customize.Page.Children.Remove(this);
            }
            else
            {
                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.parent = customize;
                errorMessage.Width = customize.ActualWidth * 0.4;

                Rectangle back = new Rectangle();
                back.Width = customize.ActualWidth;
                back.Height = customize.ActualHeight;

                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Color.FromScRgb(0.3f, 255, 255, 255);
                
                back.Fill = brush;
                customize.Page.Children.Add(back);
                errorMessage.Header.Content = "Uh oh! You have too many toppings";
                errorMessage.Body.Text = "Having too many toppings makes your pizza cook unevenly. To make sure your pizza is cooked to perfection, you can only choose up to 7 toppings";
                errorMessage.back = back;
                customize.Page.Children.Add(errorMessage);
            }
        }
    }
}
