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
using Newtonsoft.Json;

namespace PostoPizza
{
    /// <summary>
    /// Interaction logic for Drink.xaml
    /// </summary>
    
    public partial class Drink : Page
    {
        MenuList menu;
        string jsonArray = "{ 'Menu':[{'Name':'Bubbles 6 oz G/B','MenuItems':[{Title:'zonin', 'imgRef':'Zonin.jpg', Price:12.00}]},{'Name':'Rosé 5 oz G/B','MenuItems':[{Title:'saint sidoine', 'imgRef':'SaintSidoine.jpg', Price:10.00}]},{'Name':'White 5 oz G/B','MenuItems':[{Title:'donnafugata, anthilia', 'imgRef':'DonnafugataAnthilia2.jpg', Price:10.00},{Title:'stuhlmuller, chardonnay','imgRef':'StuhlmullerChardonnay.jpg', Price:16.00},{Title:'quenard, chigin classique','imgRef':'QuenardChigin.jpg', Price:13.00},{Title:'la spinetta, vermentino','imgRef':'LaSpinettaVermentino.jpg', Price:13.00},{Title:'four graces, pinot blanc','imgRef':'FourGracesPinotBlanc.jpg', Price:16.00},{Title:'bokisch, garnacha blanca','imgRef':'BokischGarnachaBlanca.jpg', Price:13.00},{Title:'kendall jackson, sauv blanc','imgRef':'KendallJacksonSauvBlanc.jpg', Price:11.00},{Title:'pascal jolivet, sancere','imgRef':'PascalJolivetSancere.jpeg', Price:16.00},{Title:'colterenzio, pinot grigio','imgRef':'ColterenzioPinotGrigio.jpg', Price:13.00}]},{'Name':'Red 5 oz G/B','MenuItems':[{Title:'donna olimpia, tageto rosso', 'imgRef':'DonnaOlimpiaTagetoRosso.PNG', Price:9.00},{Title:'lagrimas de graciano rioja','imgRef':'LagrimasDeGracianoRioja.jpg', Price:13.00},{Title:'bonanno, cabernet sauvignon','imgRef':'BonannoCabernetSauvignon.jpg', Price:14.00},{Title:'villa arceno, chianti classico','imgRef':'VillaArcenoChiantiClassico.PNG', Price:14.00},{Title:'cuvaison, pinot noir','imgRef':'CuvaisonPinotNoir.jpg', Price:19.00},{Title:'tolaini, al passo','imgRef':'TolainiAlPasso.jpg', Price:13.00},{Title:'sueno, tempranillo','imgRef':'SuenoTempranillo.jpg', Price:12.00},{Title:'c.g di arie zinfandel','imgRef':'C.gDiArieZinfandel.PNG', Price:16.00},{Title:'les cassagnes de la nerthe','imgRef':'LesCassagnesDeLaNerthe.png', Price:15.00},{Title:'g.d vajra langhe rosso','imgRef':'G.dVajraLangheRosso.jpg', Price:14.00},{Title:'2010 tolani, picconero','imgRef':'2010TolaniPicconeroIgt.PNG', Price:220.00}]},{'Name':'Riserva','MenuItems':[{Title:'2010 longview \"the piece\" shiraz', 'imgRef':'2010LongviewThePieceShiraz.jpg', Price:150.00},{Title:'2010 zenato amarone, doc','imgRef':'2010ZenatoAmaroneDoc.png', Price:114.00},{Title:'2010 ultra violet cabernet sauv','imgRef':'2010UltraVioletCabernetSauv.PNG', Price:102.00}]},{'Name':'Cocktails 2 oz','MenuItems':[{Title:'1.', Ingredients:'prosecco, muddled orange, prickly pear equineox', 'imgRef':'Cocktail.jpg', Price:12.00},{Title:'2.',Ingredients:'eau claire gin, mint, elderflower water, lemon, lime juice, ginger, bitters','imgRef':'Cocktail.jpg', Price:12.00},{Title:'3.',Ingredients:'averna, oranges, lemons, ginger ale, ginger beer','imgRef':'Cocktail.jpg', Price:12.00},{Title:'4.',Ingredients:'buffalo trace bourbon, chambord, pineapple, cranberry, bitters','imgRef':'Cocktail.jpg', Price:12.00},{Title:'5.',Ingredients:'aperol, hanger one vodka, mint, oranges, lemons and limes','imgRef':'Cocktail.jpg', Price:12.00},{Title:'6.',Ingredients:'amaretto, bourbon, lemon juice, egg white','imgRef':'Cocktail.jpg', Price:12.00},{Title:'7.',Ingredients:'pimms, lemon & lime juice, aranciata, ginger beer','imgRef':'Cocktail.jpg', Price:12.00},{Title:'8.',Ingredients:'bourbon, aperol, amaro nonino, lemon juice','imgRef':'Cocktail.jpg', Price:12.00},{Title:'9.',Ingredients:'postos negroni','imgRef':'Cocktail.jpg', Price:12.00},{Title:'10.',Ingredients:'leave it to the bartender','imgRef':'Cocktail.jpg', Price:12.00}]},{'Name':'Bottled Beer','MenuItems':[{Title:'deschutes, fresh squeezed ipa', 'imgRef':'DeschutesFreshSqueezedIpa.jpg', Price:10.00},{Title:'phillips, electric unicorn','imgRef':'PhillipsElectricUnicorn.jpg', Price:8.00},{Title:'pommies,dry apple cider','imgRef':'PommiesDryAppleCider.jpg', Price:13.00},{Title:'parallel 49, wobbly pop','imgRef':'Parallel49Wobblypop.jpg', Price:8.00},{Title:'harviestoun,old engine oil','imgRef':'HarviestounOldEngineOil.jpg', Price:10.00},{Title:'yukon,red amber ale','imgRef':'YukonRedAmberAle.png', Price:6.00},{Title:'lighthouse,shipwreck ipa','imgRef':'LighthouseShipwreckIpa.jpg', Price:9.00},{Title:'village,squeeze,lemon berry helles','imgRef':'VillageSqueezeLemonBerryHelles.PNG', Price:9.00},{Title:'Dandy Brewing company, Underworld oyster stout','imgRef':'DandyBrewingCompanyUnderworldOysterStout.jpg', Price:12.00},{Title:'Wild Rose Brewery,Velvet Fog','imgRef':'WildRoseBreweryVelvetFog.png', Price:9.00}]},{'Name':'Can of the Moment','MenuItems':[{Title:'goatlocker pale session ale', 'imgRef':'GoatLockerPaleSessionAle.jpg', Price:10.00}]},{'Name':'Draft 20 oz','MenuItems':[{Title:'local flavour of the month', 'imgRef':'LocalFlavourOfTheMonth.jpg', Price:8.50},{Title:'phillips brewery,bluebuck','imgRef':'PhillipsBreweryBlueBuck.jpg', Price:8.50}]}]}";

        public Drink()
        {
            InitializeComponent();
            menu = JsonConvert.DeserializeObject<MenuList>(jsonArray);

            for (int i = 0; i < menu.Menu.Length; i++)
            {
                Label header = new Label();
                header.Content = menu.Menu[i].Name;
                Color color = (Color)ColorConverter.ConvertFromString("#FFEFEDCC");
                header.Foreground = new System.Windows.Media.SolidColorBrush(color);


                menuList1.Children.Add(header);

                MenuItem[] category = menu.Menu[i].MenuItems;
                for (int j = 0; j < category.Length; j++)
                {
                    MenuFoodItem mf = new MenuFoodItem();

                    mf.menuItem = category[j];

                    menuList1.Children.Add(mf);
                }

            }
            /*for (int i = menu.Menu.Length - 4; i < menu.Menu.Length; i++)
            {
                Label header = new Label();
                header.Content = menu.Menu[i].Name;
                menuList2.Children.Add(header);
                Color color = (Color)ColorConverter.ConvertFromString("#FFEFEDCC");
                header.Foreground = new System.Windows.Media.SolidColorBrush(color);

                MenuItem[] category = menu.Menu[i].MenuItems;
                for (int j = 0; j < category.Length; j++)
                {
                    MenuFoodItem mf = new MenuFoodItem();
                    mf.menuItem = category[j];
                    menuList2.Children.Add(mf);
                }
            }*/
        }

        private void resizeDrink(object sender, SizeChangedEventArgs e)
        {
            menuList1.Margin = new Thickness(0, this.ActualHeight * 0.06, 0, 0);
            int i = 0;
            while (i < menuList1.Children.Count)
            {
                Label header = menuList1.Children[i] as Label;
                if (header != null)
                {
                    header.Padding = new Thickness(this.ActualHeight * 0.01);
                    header.FontSize = this.ActualHeight * 0.04;
                }


                MenuFoodItem mf2 = menuList1.Children[i] as MenuFoodItem;
                if (mf2 != null)
                {
                    mf2.Description.FontSize = this.ActualHeight * 0.03;
                    mf2.Description.Padding = new Thickness(this.ActualHeight * 0.01);
                    mf2.Image.Width = this.ActualWidth * 0.12;
                }

                i++;
            }


            /* menuList2.Margin = new Thickness(this.ActualHeight * 0.05, this.ActualHeight * 0.06, 0, 0);
            i = 0;
            while (i < menuList2.Children.Count)
            {
                Label header = menuList2.Children[i] as Label;
                if (header != null)
                {
                    header.Padding = new Thickness(this.ActualHeight * 0.01);
                    header.FontSize = this.ActualHeight * 0.04;
                }


                MenuFoodItem mf2 = menuList2.Children[i] as MenuFoodItem;
                if (mf2 != null)
                {
                    mf2.Description.FontSize = this.ActualHeight * 0.03;
                    mf2.Description.Padding = new Thickness(this.ActualHeight * 0.01);
                }

                i++;
            }*/
        }
    }
}
