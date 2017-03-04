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
            new string[] {"Tuesday", "Comfort food. Think Sunday dinner on a Tuesday night.\n Bottles of Lambrusco for $25!"},
            new string[] {"Wednesday", "Date Night: Join us for a tasting menu for $35 per person. Feature $30 bottle of wine."},
            new string[] {"Thursday", "1/2 price cocktails. $6 for two ounce cocktails."},
            new string[] {"Friday", "Glasses of Sam's house-made Sangria for $8! Jugs for $35."},
            new string[] {"Saturday", "15% off tasting menus"},
            new string[] {"Sunday", "1/2 price pizza"}
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
        }
        private void resize(object sender, SizeChangedEventArgs e)
        {
            leftScroller.Width = this.ActualWidth / 2;
            rightScroller.Width = this.ActualWidth / 2;
            if (this.ActualHeight > 500)
            {
                for (int i = 0; i < specials.Length; i++)
                {
                    SpecialItem it = specialsList.Children[i] as SpecialItem;
                    //it.Height = this.ActualHeight / specials.Length;
                    it.Title.FontSize = this.ActualHeight * 0.04;
                    it.Title.Padding = new Thickness(this.ActualHeight * 0.01);
                    it.Description.FontSize = this.ActualHeight * 0.03;
                    it.Description.Padding = new Thickness(this.ActualHeight * 0.01);

                }
            }
            
        }
    }
}
