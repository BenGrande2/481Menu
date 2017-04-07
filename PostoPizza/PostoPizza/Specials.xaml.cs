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
    /// Interaction logic for Specials.xaml
    /// </summary>
    public partial class Specials : Page
    {
        string[][] specials = new string[][] {
            new string[] {"Monday", "Industry Night"},
            new string[] {"Tuesday", "Comfort food. Think Sunday dinner on a Tuesday night.\nBottles of Lambrusco for $25!"},
            new string[] {"Wednesday", "Date Night: Join us for a tasting menu for $35 per person. Feature $30 bottle of wine."},
            new string[] {"Thursday", "1/2 price cocktails. $6 for two ounce cocktails."},
            new string[] {"Friday", "Glasses of Sam's house-made Sangria for $8! Jugs for $35."},
            new string[] {"Saturday", "15% off tasting menus"},
            new string[] {"Sunday", "1/2 price pizza"}
        };

        string[][] happyHour = new string[][]
        {
            new string[] {"To Drink", "pints of beer 5\nbottles of wine half price"},
            new string[] {"To Eat", "sicilian olives 6\njoe's nuts 6\ntuscan hummus 6\nbrussels sprouts 6"},
            new string[] {"Served Per Piece", "meatball 2.50 /each\narancini 2.50 /each\nbeef crudo 2.50 /each\nravioli 2.50 /each\nperogie 2.50 / each"},
            new string[] {"Benny Apertivo", "antipasti plate 9"}
        };

        public Specials()
        {
            InitializeComponent();
            for (int i = 0; i < specials.Length; i++)
            {
                SpecialItem it = new SpecialItem();
                it.Title.Content = specials[i][0];
                it.Description.Text = specials[i][1];
                specialsList.Children.Add(it);
            }
            for (int i = 0; i < happyHour.Length; i++)
            {
                SpecialItem it_2 = new SpecialItem();
                it_2.Title.Content = happyHour[i][0];
                it_2.Description.Text = happyHour[i][1];
                happyHourList.Children.Add(it_2);
            }
        }
        public Navigation nav;
        private void goDrinks(object sender, TouchEventArgs e)
        {
            nav.tabControl.SelectedIndex = 1;
        }
        private void goDrinks(object sender, MouseButtonEventArgs e)
        {
            nav.tabControl.SelectedIndex = 1;
        }
        private void goFood(object sender, TouchEventArgs e)
        {
            nav.tabControl.SelectedIndex = 0;
        }
        private void goFood(object sender, MouseButtonEventArgs e)
        {
            nav.tabControl.SelectedIndex = 0;
        }
        private void resize(object sender, SizeChangedEventArgs e)
        {
            leftScroller.Width = this.ActualWidth / 2;
            rightScroller.Width = this.ActualWidth / 2;
            happyHourList.Margin = new Thickness(0, this.ActualHeight * 0.06, 0, 0);
            if (this.ActualHeight > 500)
            {
                for (int i = 0; i < specials.Length; i++)
                {
                    SpecialItem it = specialsList.Children[i] as SpecialItem;
                    it.Title.FontSize = this.ActualHeight * 0.04;
                    it.Title.Padding = new Thickness(this.ActualHeight * 0.01);
                    it.Description.FontSize = this.ActualHeight * 0.03;
                    it.Description.Padding = new Thickness(this.ActualHeight * 0.01);

                    if (i < 5)
                    {
                        it.TouchDown += goDrinks;
                        it.MouseLeftButtonUp += goDrinks;
                        it.MouseDown += goDrinks;
                        it.MouseLeftButtonDown += goDrinks;
                    }
                    else
                    {
                        it.TouchDown += goFood;
                        it.MouseLeftButtonUp += goFood;
                        it.MouseDown += goFood;
                        it.MouseLeftButtonDown += goFood;
                    }
                }
                for (int i = 0; i < happyHour.Length; i++)
                {
                    SpecialItem it_2 = happyHourList.Children[i] as SpecialItem;
                    it_2.Title.FontSize = this.ActualHeight * 0.04;
                    it_2.Title.Padding = new Thickness(this.ActualHeight * 0.01);
                    it_2.Description.FontSize = this.ActualHeight * 0.03;
                    it_2.Description.Padding = new Thickness(this.ActualHeight * 0.01);

                    if (i == 0)
                    {
                        it_2.TouchDown += goDrinks;
                        it_2.MouseLeftButtonUp += goDrinks;
                        it_2.MouseDown += goDrinks;
                        it_2.MouseLeftButtonDown += goDrinks;
                    }
                    else
                    {
                        it_2.TouchDown += goFood;
                        it_2.MouseLeftButtonUp += goFood;
                        it_2.MouseDown += goFood;
                        it_2.MouseLeftButtonDown += goFood;
                    }
                }
            }   
        }
    }
}
