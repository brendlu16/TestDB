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
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string path;
        public MainWindow()
        {
            InitializeComponent();
            path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = System.IO.Path.Combine(path, "database.db");

            VypsatTridy();
            //Test();
        }
        public void Test()
        {
            DBManager dbManager = new DBManager(path);
            Trida trida1 = new Trida { Nazev = "trida1" };
            Trida trida2 = new Trida { Nazev = "trida2" };
            dbManager.VytvoritTridu(trida1);
            dbManager.VytvoritTridu(trida2);
            Polozka polozka1 = new Polozka { Nazev = "polozka1", Cena = 100, TridaID = 1 };
            Polozka polozka2 = new Polozka { Nazev = "polozka2", Cena = 200, TridaID = 1 };
            Polozka polozka3 = new Polozka { Nazev = "polozka3", Cena = 300, TridaID = 2 };
            Polozka polozka4 = new Polozka { Nazev = "polozka4", Cena = 400, TridaID = 2 };
            dbManager.VytvoritPolozku(polozka1);
            dbManager.VytvoritPolozku(polozka2);
            dbManager.VytvoritPolozku(polozka3);
            dbManager.VytvoritPolozku(polozka4);
        }

        public void VypsatTridy()
        {
            ListVeci.Items.Clear();
            DBManager dbManager = new DBManager(path);
            var Tridy = dbManager.NacistTridy().ToList();
            foreach (var item in Tridy)
            {
                ListViewItem Item = dbManager.VytvoritItemTridy(item);
                StackPanel stackPanel = (StackPanel)Item.Content;
                Button button = (Button)stackPanel.Children[0];
                button.Click += new RoutedEventHandler(Button_Click);
                Button button2 = (Button)stackPanel.Children[1];
                button2.Click += new RoutedEventHandler(Button_Click2);
                ListVeci.Items.Add(Item);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int ID = int.Parse(button.Name.Remove(0, 2));
            Frame1.NavigationService.Navigate(new StrankaTridy(ID, path));
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int ID = int.Parse(button.Name.Remove(0, 2));
            DBManager dbManager = new DBManager(path);
            dbManager.SmazatTridu(ID);
            VypsatTridy();
        }
    }
}
