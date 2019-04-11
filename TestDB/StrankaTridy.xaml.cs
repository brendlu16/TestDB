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

namespace TestDB
{
    /// <summary>
    /// Interakční logika pro StrankaTridy.xaml
    /// </summary>
    public partial class StrankaTridy : Page
    {
        public int IDTridy;
        public string path;
        public StrankaTridy(int ID, string Path)
        {
            InitializeComponent();
            IDTridy = ID;
            path = Path;
            VypsatPolozky();
        }
        public void VypsatPolozky()
        {
            ListVeci.Items.Clear();
            DBManager dbManager = new DBManager(path);
            var Polozky = dbManager.NacistPolozky().ToList();
            foreach (var item in Polozky)
            {
                if (item.TridaID == IDTridy)
                {
                    ListViewItem Item = dbManager.VytvoritItemPolozky(item);
                    StackPanel stackPanel = (StackPanel)Item.Content;
                    Button button2 = (Button)stackPanel.Children[1];
                    button2.Click += new RoutedEventHandler(Button_Click2);
                    ListVeci.Items.Add(Item);
                }
            }
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int ID = int.Parse(button.Name.Remove(0, 2));
            DBManager dbManager = new DBManager(path);
            dbManager.SmazatPolozku(ID);
            VypsatPolozky();
        }
    }
}
