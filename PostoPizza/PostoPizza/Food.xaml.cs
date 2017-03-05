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
    /// Interaction logic for Food.xaml
    /// </summary>
    public partial class Food : Page
    {
        string[][] foodMenuItems = new string[][]
        {
            new string[] {"Small Bites",
            "bonterra bread\n\n" +
            "sicillian olives\n\n" +
            "tuscan hummus\n\n" +
            "brussel sprouts\n\n" +
            "joe's nuts\n\n"},
            new string[] {"Salads",
            "spinach\n\n" +
            "black kale\n\n" +
            "romaine\n\n" },
            new string[] {"Cured Meats & Cheeses",
            "ropelle\n\n" +
            "tiger blue\n\n" +
            "cheddar\n\n" +
            "pork lonza\n\n" +
            "duck prosciutto\n\n" +
            "swordfish bresaola\n\n" },
            new string[] {"Small Plates",
            "meatballs\n\n" +
            "braised rabbit ravioli\n\n" +
            "mussels\n\n" +
            "humble squid\n\n" +
            "beef tar tar\n\n" +
            "perogies\n\n"},
            new string[] {"Pizza",
            "fior di latte, tomato, basil\n\n" +
            "potato, creme fraiche, leek, smoked pancetta\n\n" +
            "spinach, shallot, garlic, wild mushroom, grana padano\n\n" +
            "sausage, salami, smoked pancetta, calabrese\n\n" +
            "chicken, almond pesto, goat cheese, red peppers\n\n" +
            "sausage, apple, frisee, tomato\n\n" +
            "smoked salmon, leek, caper, creme fraiche, lemon\n\n" +
            "pineapple, gorgonzola, pancetta, fresno chilies\n\n" +
            "gorgonzola, fig, potato, radichio, rosemary\n\n" +
            "prosciutto, fior di latte, arugula, grana padano\n\n" },
            new String[] {"Taste of Posto", "weekly tasting menu"}
        };

        public Food()
        {
            InitializeComponent();
            for (int i = 0; i < foodMenuItems.Length-2; i++)
            {
                MenuFoodItem mf = new MenuFoodItem();
                mf.Title.Content = foodMenuItems[i][0];
                mf.Description.Text = foodMenuItems[i][1]; 
                menuList1.Children.Add(mf);
            }
            for (int i = foodMenuItems.Length-2; i < foodMenuItems.Length; i++)
            {
                MenuFoodItem mf = new MenuFoodItem();
                mf.Title.Content = foodMenuItems[i][0];
                mf.Description.Text = foodMenuItems[i][1];
                menuList2.Children.Add(mf);
            }
            


        }

        private void resizeFood(object sender, SizeChangedEventArgs e)
        {
            menuList1.Margin = new Thickness(0, this.ActualHeight * 0.06, 0, 0);
            for (int i = 0; i < foodMenuItems.Length-2; i++)
            {
                MenuFoodItem mf = menuList1.Children[i] as MenuFoodItem;
                mf.Title.Padding = new Thickness(this.ActualHeight * 0.01);
                mf.Title.FontSize = this.ActualHeight * 0.04;
                mf.Description.FontSize = this.ActualHeight * 0.03;
                mf.Description.Padding = new Thickness(this.ActualHeight * 0.01);
            }

            menuList2.Margin = new Thickness(0, this.ActualHeight * 0.06, 0, 0);
            for (int i = 0; i < foodMenuItems.Length-foodMenuItems.Length-2; i++)
            {
                MenuFoodItem mf2 = menuList2.Children[i] as MenuFoodItem;
                mf2.Title.Padding = new Thickness(this.ActualHeight * 0.01);
                mf2.Title.FontSize = this.ActualHeight * 0.04;
                mf2.Description.FontSize = this.ActualHeight * 0.03;
                mf2.Description.Padding = new Thickness(this.ActualHeight * 0.01);
            }
        }
    }
}
