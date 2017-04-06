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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class AltLabel : UserControl
    {
        public AltLabel()
        {
            InitializeComponent();
        }

        public string imgRef;

        public BitmapImage getImage()
        {
            if (imgRef != null)
            {
                Uri uri = new Uri("Images/Menu/" + this.imgRef, UriKind.Relative);
                return new BitmapImage(uri);
            }
            return null;

        }
    }
}
