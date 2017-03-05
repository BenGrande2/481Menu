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
        string jsonArray = "{'Menu':[{'Name':'Small Bites','MenuItems':[{Title:'bonterra bread'},{Title:'sicillian olives'},{Title:'tuscan hummus'},{Title:'brussel sprouts'},{Title:'joes nuts'}]},{'Name':'Salads','MenuItems':[{Title:'spinach'},{Title:'black kale'},{Title:'romaine'}]},{'Name':'Cured Meats & Cheeses','MenuItems':[{Title:'ropelle'},{Title:'tiger blue'},{Title:'cheddar'},{Title:'pork lonza'},{Title:'duck prosciutto'},{Title:'swordfish bresaola'}]},{'Name':'Small Plates','MenuItems':[{Title:'meatballs'},{Title:'braised rabbit ravioli'},{Title:'mussels'},{Title:'humble squid'},{Title:'beef tar tar'},{Title:'perogies'}]},{'Name':'Pizza','MenuItems':[{Title:'1.',Ingredients:'fior di latte, tomato, basil',Price:19.00},{Title:'2.',Ingredients:'potato, creme fraiche, leek, smoked pancetta',Price:21.00},{Title:'3.',Ingredients:'spinach, shallot, garlic, wild mushroom, grana padano',Price:21.00},{Title:'4.',Ingredients:'sausage, salami, smoked pancetta, calabrese',Price:22.00},{Title:'5.',Ingredients:'usage, apple, frisee, tomato',Price:21.00},{Title:'6.',Ingredients:'smoked salmon, leek, caper, creme fraiche, lemon',Price:24.00},{Title:'7.',Ingredients:'pineapple, gorgonzola, pancetta, fresno chilies',Price:21.00},{Title:'8.',Ingredients:'gorgonzola, fig, potato, radichio, rosemary',Price:23.00},{Title:'9.',Ingredients:'prosciutto, fior di latte, arugula, grana padano',Price:24.00}]}, {'Name': 'Taste of Posto', MenuItems: [{'Title': 'WEEKLY TASTING MENU 49 PER PERSON'}]}]}";
        
        public Food()
        {
            
            InitializeComponent();
            menu = JsonConvert.DeserializeObject<MenuList>(jsonArray);
           
            for (int i = 0; i < menu.Menu.Length-2; i++)
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
            for (int i = menu.Menu.Length-2; i < menu.Menu.Length; i++)
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
                    if (menu.Menu[i].Name == "Pizza")
                    {
                        mf.MouseDoubleClick += Mf_MouseDoubleClick;
                       
                    }
                }
            }
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
                }
                
                i++;
            }


            menuList2.Margin = new Thickness(this.ActualHeight * 0.05, this.ActualHeight * 0.06, 0, 0);
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
            }
        }
    }
}
