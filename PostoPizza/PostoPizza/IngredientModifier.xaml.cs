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
        private Ingredient _ingredient;
        public Ingredient ingredient
        {
            set
            {
                ingImg.Source = value.getImage();
                ingName.Content = value.name;
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
    }
}
