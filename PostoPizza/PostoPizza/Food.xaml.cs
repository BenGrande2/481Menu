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
    /// Interaction logic for Food.xaml
    /// </summary>
    public class MenuCategory
    {
        public string Name;
        public MenuItem[] MenuItems;
    }
    public class MenuList
    {
        public MenuCategory[] Menu;
    }
    public partial class Food : Page
    {

        MenuList menu;
        string jsonArray = "{'Menu':[{'Name':'Small Bites','MenuItems':[{Title:'bonterra bread', Price: 3, 'imgRef':'BonterraBread.png'},{Title:'sicillian olives', 'imgRef':'SicilianOlives.jpg', Price: 6},{Title:'tuscan hummus', 'imgRef':'TuscanHummus.jpg', Price: 6},{Title:'brussel sprouts', 'imgRef':'BrusselsSprouts.jpg', Price: 6},{Title:'joes nuts', 'imgRef':'JoesNuts.jpg', Price: 6}]},{'Name':'Salads','MenuItems':[{Title:'spinach', 'imgRef':'SpinachSalad.jpg', Price: 11},{Title:'black kale', 'imgRef':'BlackKaleSalad2.jpg', Price: 13},{Title:'romaine', 'imgRef':'RomaineSalad.jpg', Price: 11}]},{'Name':'Cured Meats & Cheeses','MenuItems':[{Title:'ropelle', 'imgRef':'Riopelle.jpg', Price: 8},{Title:'tiger blue', 'imgRef':'TigerBlue.jpg', Price: 8},{Title:'cheddar', 'imgRef':'Cheddar.jpg', Price: 8},{Title:'pork lonza', 'imgRef':'PorkLonza.png', Price: 8},{Title:'duck prosciutto', 'imgRef':'DuckProsciutto.jpg', Price: 8},{Title:'swordfish bresaola', 'imgRef':'SwordfishBresaola.jpg', Price: 8}]},{'Name':'Small Plates','MenuItems':[{Title:'meatballs', 'imgRef':'LambMeatballs.jpg', Price: 10},{Title:'mussels', 'imgRef':'Mussels.jpg', Price: 13},{Title:'humble squid', 'imgRef':'HumbleSquid.jpg', Price: 10},{Title:'beef tar tar', 'imgRef':'BeefTarTar.jpg', Price: 14},{Title:'perogies', 'imgRef':'Perogies.jpg', Price: 12}]},{'Name':'Pizza','MenuItems':[{Title:'1.',Ingredients:'fior di latte, tomato, basil',Price:19.00,'imgRef':'Pizza1.jpg',},{Title:'2.',Ingredients:'potato, creme fraiche, leek, smoked pancetta',Price:21.00,'imgRef':'Pizza2.jpg',},{Title:'3.',Ingredients:'spinach, shallot, garlic, wild mushroom, grana padano',Price:21.00,'imgRef':'Pizza3.jpg',},{Title:'4.',Ingredients:'sausage, salami, smoked pancetta, calabrese',Price:22.00,'imgRef':'Pizza4.JPG',},{Title:'5.',Ingredients:'chicken, almond pesto, goat cheese, red peppers',Price:21.00,'imgRef':'Pizza5.png',},{Title:'6.',Ingredients:'sausage, apple, frisee, tomato',Price:21.00,'imgRef':'Pizza6.PNG',},{Title:'7.',Ingredients:'smoked salmon, leek, caper, creme fraiche, lemon',Price:24.00,'imgRef':'Pizza7.png',},{Title:'8.',Ingredients:'pineapple, gorgonzola, pancetta, fresno chilies',Price:21.00,'imgRef':'Pizza8.jpg',},{Title:'9.',Ingredients:'gorgonzola, fig, potato, radichio, rosemary',Price:23.00,'imgRef':'Pizza9.jpg',},{Title:'10.',Ingredients:'prosciutto, fior di latte, arugula, grana padano',Price:24.00,'imgRef':'Pizza10-2.jpg',}]},{'Name':'Taste of Posto',MenuItems:[{'Title':'WEEKLY TASTING MENU', Price: 49}]}]}";
        
        public Food()
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
                    if (menu.Menu[i].Name == "Pizza")
                    {
                        mf.MouseDoubleClick += Mf_MouseDoubleClick;
                   
                    }
                    mf.MouseRightButtonDown += Mf_MouseDown;
                    //mf.MouseDown += Mf_MouseDown;
                    menuList1.Children.Add(mf);
                    
                }
                
            }
  
        }

        private void Mf_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle fadeout = new Rectangle();
            fadeout.Width = ActualWidth;
            fadeout.Height = ActualHeight;
            fadeout.HorizontalAlignment = HorizontalAlignment.Left;
            fadeout.VerticalAlignment = VerticalAlignment.Top;
            Color color = (Color)ColorConverter.ConvertFromString("#7F323232");
            fadeout.Fill = new System.Windows.Media.SolidColorBrush(color);
            Page.Children.Add(fadeout);

            addToOrderPopup addMenu = new addToOrderPopup();
            addMenu.HorizontalAlignment = HorizontalAlignment.Center;
            addMenu.VerticalAlignment = VerticalAlignment.Center;
            addMenu.Width = 400;
            addMenu.Height = 100;
            Page.Children.Add(addMenu);
        }

        private void Mf_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            MenuFoodItem item = sender as MenuFoodItem;
            if (item != null)
            {
                Console.WriteLine("Double clicked1");
                Frame parent = Parent as Frame;
                CustomizePizza customize = new CustomizePizza();
                customize.pizza = item.menuItem;
                NavigationService.Navigate(customize);
                if (parent != null)
                {
                    Console.WriteLine("Double clicked2");
                    parent.Source = new Uri("CustomizePizza.xaml", UriKind.Relative);
                }
                
                //item.menuItem
            }
        }


        private void resizeFood(object sender, SizeChangedEventArgs e)
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


            menuList2.Margin = new Thickness(this.ActualHeight * 0.05, this.ActualHeight * 0.06, 0, 0);
            
        }
    }
}
