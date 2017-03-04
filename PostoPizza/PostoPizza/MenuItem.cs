using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PostoPizza
{
    
    public class MenuItem
    {
        public String category;
        public String title;
        public double price;
        public Ingredient[] ingredients;
        public string imgRef;
        public BitmapImage getImage()
        {
            if (imgRef != null)
            {
                Uri uri = new Uri("Images/MenuItems/" + this.imgRef, UriKind.Relative);
                return new BitmapImage(uri);
            }
            return null;
            
        }
        
        public MenuItem(string category, string title, double price, Ingredient[] ingredients, string img)
        {
            this.category = category;
            this.title = title;
            this.price = price;
            this.ingredients = ingredients;
            this.imgRef = img;
        }
        public MenuItem(string title, double price)
        {
            this.title = title;
            this.price = price;
            this.category = "";
            this.imgRef = "";
        }
    }
}
