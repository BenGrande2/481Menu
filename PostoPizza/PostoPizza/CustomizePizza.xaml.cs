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
    /// Interaction logic for CustomizePizza.xaml
    /// </summary>
    public partial class CustomizePizza : Page
    {
        private MenuItem _pizza;
        public Order order;
        public MenuItem pizza
        {
            set
            {
                for (int i = 0; i < value.ingredients.Length; i++)
                {
                   // IngredientModifier ing = new IngredientModifier();
                   // ing.ingredient = value.ingredients[i];
                    //ing.custom = this;
                    addIngredient(value.ingredients[i]);
                    //Ingredients.Children.Add(ing);
                }
                //Ingredients.Children.Add()
                Uri uri = new Uri("Images/Ingredients/pizzaBase.png", UriKind.Relative);
                BitmapImage pizzaBase = new BitmapImage(uri);
                Image img = new Image();
                img.Height = 100;
               
                img.Source = pizzaBase;
                Ingredients.Children.Add(img);
                _pizza = value;
            }
            get
            {
                return _pizza;
            }
        }
        public CustomizePizza()
        {
            InitializeComponent();
        }

        private void resize(object sender, SizeChangedEventArgs e)
        {
            double tenthHeight = ActualHeight / 20;
            HelpButton.Height = tenthHeight;
            CancelButton.Height = tenthHeight;
            AddButton.Height = tenthHeight;
            ServerButton.Height = tenthHeight;

            double qWidth = ActualWidth / 4;
            HelpButton.Width = qWidth;
            CancelButton.Width = qWidth;
            AddButton.Width = qWidth;
            ServerButton.Width = qWidth;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PizzaAddon addMenu = new PizzaAddon();
            addMenu.HorizontalAlignment = HorizontalAlignment.Center;
            addMenu.VerticalAlignment = VerticalAlignment.Center;
            addMenu.Width = 400;
            addMenu.Height = 500;
            addMenu.customize = this;
            Page.Children.Add(addMenu);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            backToHome();
        }
        public void backToHome()
        {
            Frame parent = Parent as Frame;
            Food customize = new Food();
            customize.order = order;
            NavigationService.Navigate(customize);
            if (parent != null)
            {
                Console.WriteLine("Double clicked2");
                parent.Source = new Uri("Food.xaml", UriKind.Relative);
            }
        }
        public void addIngredients(Ingredient[] ings)
        {
            for (int j = 0; j < ings.Length; j ++)
            {
                IngredientModifier ing = new IngredientModifier();
                ing.ingredient = ings[j];
                ing.custom = this;
                Ingredients.Children.Insert(0, ing);
            }
        }
        public void addIngredient(Ingredient ingredient)
        {
            IngredientModifier ing = new IngredientModifier();
            ing.ingredient = ingredient;
            ing.custom = this;
            Ingredients.Children.Insert(0, ing);

            if (Ingredients.Children.Count > 5)
            {
                double percHeight = (ActualHeight * 0.7) / Ingredients.Children.Count;
                
                for (int j = 0; j < Ingredients.Children.Count; j++)
                {
                    IngredientModifier ingMod = (Ingredients.Children[j] as IngredientModifier);
                    if (ingMod != null) {
                        ingMod.resize();
                        ingMod.Height = percHeight;
                    }
                    else
                    {
                        Image img = (Ingredients.Children[j] as Image);
                        if (img != null)
                        {
                            img.Height = percHeight;
                        }
                    }
                }
            }
            // TODO - figure out how to append
            //pizza.ingredients = pizza.ingredients.Union(new Ingredient[] { ingredient }) as Ingredient[];
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            addToOrderPopup popup = new addToOrderPopup();
            popup.food = pizza;
            popup.order = order;
            Page.Children.Add(popup);
            
        }
        public Navigation nav;
        public void changeToOrder()
        {
            nav.changeToOrder();
        }
        public void removeIng(IngredientModifier ing)
        {
            // TODO - figure out how to remove
            //pizza.ingredients = pizza.ingredients.Except(new Ingredient[] { ing.ingredient }) as Ingredient[];
            Ingredients.Children.Remove(ing);
        }
    }
}
