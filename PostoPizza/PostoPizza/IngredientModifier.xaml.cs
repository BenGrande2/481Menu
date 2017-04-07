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
    /// Interaction logic for IngredientModifier.xaml
    /// </summary>
    public partial class IngredientModifier : UserControl
    {
        public CustomizePizza custom;
        private Ingredient _ingredient;
        public Ingredient ingredient
        {
            set
            {
                ingImg.Source = value.getImage();
                ingName.Content = value.name;
                Color color = (Color)ColorConverter.ConvertFromString("#FFEFEDCC");
                ingName.Foreground = new System.Windows.Media.SolidColorBrush(color);
                _ingredient = value;
            }
            get
            {
                return _ingredient;
            }

        }
        public IngredientModifier()
        {
            InitializeComponent();
        }

        private void resize(object sender, SizeChangedEventArgs e)
        {
            double thirdWidth = ActualWidth / 3;
            Stack1.Width = thirdWidth;
            Stack2.Width = thirdWidth;
            Stack3.Width = thirdWidth;
        }
        public void resize()
        {
            double thirdWidth = ActualWidth / 3;
            Stack1.Width = thirdWidth;
            Stack2.Width = thirdWidth;
            Stack3.Width = thirdWidth;
            if (Stack2.Height > ActualHeight)
            {
                Stack2.Height = ActualHeight;
            }
        }
        private void Stack3_Click(object sender, RoutedEventArgs e)
        {
            custom.removeIng(this);
        }
        private string _quantity = "Regular";
        public string quantity {
            set
            {
                _quantity = value;
                Uri uri = new Uri("Images/"+_quantity+"Button.png", UriKind.Relative);
                BitmapImage image = new BitmapImage(uri);
                quantityButton.Source = image;
                custom.setQuantity(ingredient, quantity);
            }
            get
            {
                return _quantity;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) // +
        {
            if (quantity == "Less")
            {
                quantity = "Regular";
            }
            else if (quantity == "Regular")
            {
                quantity = "More";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // -
        {
            if (quantity == "More")
            {
                quantity = "Regular";
            }
            else if (quantity == "Regular")
            {
                quantity = "Less";
            }
        }
    }
}
