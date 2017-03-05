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
    public partial class Drink : Page
    {
        string[][] drinkMenuItems = new string[][]
        {
            new string[] {"Bubbles 6oz G/B",
                "zonin\n\n" +
                "medici concerto lambrusco\n\n"},
            new string[] {"Rosé 5oz G/B\n\n",
                "saint sidoine\n\n"},
            new string[] {"White 5oz G/B\n\n",
                "donnafugaga, anthilia\n\n" +
                "stuhlmuller, chardonnay\n\n" +
                "quenard, chigin classique\n\n" +
                "la spinetta, vermentino\n\n" +
                "four graces, pinot blanc\n\n" +
                "bokisch, garnacha blanca\n\n" +
                "back 10 cellars, big reach riesling\n\n" +
                "kendall jackson, sauv blanc\n\n" +
                "pascal jolivet, sancere\n\n" +
                "colterenzio, pinot grigio\n\n"},
            new string[] {"Red 5oz G/B\n\n",
                "donna olimpia, tageto rosso\n\n" +
                "lagrimas de graciano rioja\n\n" +
                "bonanno, cabernet sauvignon\n\n" +
                "villa arceno, chianti classico\n\n" +
                "cuvaison, pinot noir\n\n" +
                "tolaini, al passo\n\n" +
                "sueno, tempranillo\n\n" +
                "c.g di arie zinfandel\n\n" +
                "les cassagnes de la nerthe\n\n" +
                "g.d vajra langhe rosso\n\n" +
                "2010 tolani, picconero\n\n"},
            new string[] {"Riserva\n\n",
                "2010 longview \"the piece\" shiraz\n\n" +
                "2010 zenato amarone, doc\n\n" +
                "2010 ultra violet cabernet sauv\n\n"},
            new string[] {"Cocktails 2oz\n\n",
                "prosecco, muddled orange, prickly pear equineox\n\n" +
                "eau claire gin, mint, elderflower water, lemon, lime juice, ginger, bitters\n\n" +
                "averna, oranges, lemons, ginger ale, ginger beer\n\n" +
                "buffalo trace bourbon, chambord, pineapple, cranberry, bitters\n\n" +
                "aperol, hanger one vodka, mint, oranges, lemons and limes\n\n" +
                "amaretto, bourbon, lemon juice, egg white\n\n" +
                "pimms, lemon & lime juice, aranciata, ginger beer\n\n" +
                "bourbon, aperol, amaro nonino, lemon juice\n\n" +
                "posto's negroni\n\n" +
                "leave it to the bartender\n\n"},
            new string[] {"Bottled Beer\n\n",
                "deschutes, fresh squeezed ipa\n\n" +
                "phillips, electric unicorn\n\n" +
                "pommies, dry apple cider\n\n" +
                "parallel 49, wobblypop\n\n" +
                "harviestoun, old engine oil\n\n" +
                "yukon, red amber ale\n\n" +
                "lighthouse, shipwreck ipa\n\n" +
                "village, squeeze, lemon berry helles\n\n" +
                "dandy brewing company,, underworld oyster stout\n\n" +
                "wild rose brewery, velvet fog\n\n"},
            new string[] {"Can of the Moment\n\n",
                "goat locker, pale session ale\n\n"},
            new string[] {"Draft 20oz\n\n",
                "local flavour of the month\n\n" +
                "phillips brewery, pilsner\n\n" +
                "phillips brewery, blue buck\n\n" +
                "driftwood, fat tug ipa\n\n" }
        };

        public Drink()
        {
            InitializeComponent();
            for (int i = 0; i < drinkMenuItems.Length-4; i++)
            {
                MenuFoodItem mf = new MenuFoodItem();
                mf.Title.Content = drinkMenuItems[i][0];
                mf.Description.Text = drinkMenuItems[i][1]; 
                menuList1.Children.Add(mf);
            }
            for (int i = drinkMenuItems.Length-4; i < drinkMenuItems.Length; i++)
            {
                MenuFoodItem mf = new MenuFoodItem();
                mf.Title.Content = drinkMenuItems[i][0];
                mf.Description.Text = drinkMenuItems[i][1];
                menuList2.Children.Add(mf);
            }
            


        }

        private void resizeFood(object sender, SizeChangedEventArgs e)
        {
            menuList1.Margin = new Thickness(0, this.ActualHeight * 0.06, 0, 0);
            for (int i = 0; i < drinkMenuItems.Length-4; i++)
            {
                MenuFoodItem mf = menuList1.Children[i] as MenuFoodItem;
                mf.Title.Padding = new Thickness(this.ActualHeight * 0.01);
                mf.Title.FontSize = this.ActualHeight * 0.04;
                mf.Description.FontSize = this.ActualHeight * 0.03;
                mf.Description.Padding = new Thickness(this.ActualHeight * 0.01);
            }

            menuList2.Margin = new Thickness(0, this.ActualHeight * 0.06, 0, 0);
            for (int i = 0; i < drinkMenuItems.Length-drinkMenuItems.Length-4; i++)
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
