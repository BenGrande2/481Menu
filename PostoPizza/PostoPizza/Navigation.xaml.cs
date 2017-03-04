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
    /// Interaction logic for Navigation.xaml
    /// </summary>
    public partial class Navigation : Page
    {
        public Navigation()
        {
            InitializeComponent();
            tabControl.SelectedIndex = 2;
            
        }

        private void resizeTabs(object sender, SizeChangedEventArgs e)
        {
            var quarterWidth = (tabControl.ActualWidth / 4)-1.5;
            var tenthHeight = (tabControl.ActualHeight / 20);
            foodTab.Width = quarterWidth;
            foodTab.Height = tenthHeight;
            foodE.Width = quarterWidth*2;
            foodE.Height = 3 * tenthHeight;
            foodE.Margin = new Thickness(-quarterWidth, -tenthHeight*1.6 , 0, 0);

           

            drinkTab.Width = tabControl.ActualWidth / 4;
            drinkE.Width = quarterWidth+4;
            drinkE.Height = 3 * tenthHeight;
            drinkE.Margin = new Thickness(quarterWidth-2, -tenthHeight * 1.6, 0, 0);

            specTab.Width = quarterWidth;
            specE.Width = quarterWidth+4;
            specE.Height = 3 * tenthHeight;
            specE.Margin = new Thickness(2*quarterWidth - 2, -tenthHeight * 1.6, 0, 0);

            orderTab.Width = quarterWidth;
            orderE.Width = quarterWidth * 2;
            orderE.Height = 3 * tenthHeight;
            orderE.Margin = new Thickness(quarterWidth*3, -tenthHeight * 1.6, 0, 0);



        }
    }
}
