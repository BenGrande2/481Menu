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
        public MenuItem pizza
        {
            set
            {
                for (int i = 0; i < value.ingredients.Length; i++)
                {
                    IngredientModifier ing = new IngredientModifier();
                    ing.ingredient = value.ingredients[i];
                    Ingredients.Children.Add(ing);
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
    }
}
