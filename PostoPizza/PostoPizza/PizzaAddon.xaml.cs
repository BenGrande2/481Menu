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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //(order.OrderLists.Children[0] as OrderList).addItem(food);
            //customize.Page.Children.Remove(cover);
            if (proscuitto.IsChecked == true)
            {
               
                customize.addIngredient(new Ingredient("proscuitto"));
            }
            if (anchovy.IsChecked == true)
            {
                customize.addIngredient(new Ingredient("anchovy"));     
            }
            if (egg.IsChecked == true)
            {
                customize.addIngredient(new Ingredient("egg"));
            }
            if (truffleOil.IsChecked == true)
            {
                customize.addIngredient(new Ingredient("truffle oil"));
            }
            if (Arugula.IsChecked == true)
            {
                customize.addIngredient(new Ingredient("arugula"));
            }
            if (smoked_pancetta.IsChecked == true)
            {
                customize.addIngredient(new Ingredient("smoked pancetta"));
            }
            if (sausage.IsChecked == true)
            {
                customize.addIngredient(new Ingredient("sausage"));
            }
            if (salami.IsChecked == true)
            {
                customize.addIngredient(new Ingredient("salami"));
            }
            if (tomato.IsChecked == true)
            {
                customize.addIngredient(new Ingredient("tomato"));
            }
            if (gorgonzola.IsChecked == true)
            {
                customize.addIngredient(new Ingredient("gorgonzola"));
            }
            if (calabrese.IsChecked == true)
            {
                customize.addIngredient(new Ingredient("calabrese"));
            }
            customize.Page.Children.Remove(this);
        }
    }
}
