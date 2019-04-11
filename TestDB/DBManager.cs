using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestDB
{
    public class DBManager
    {
        private SQLiteConnection db;
        public DBManager(string path)
        {
            db = new SQLiteConnection(path);
            db.CreateTable<Trida>();
            db.CreateTable<Polozka>();
        }
        public void VytvoritTridu(Trida trida)
        {
            db.Insert(trida);
        }
        public void VytvoritPolozku(Polozka polozka)
        {
            db.Insert(polozka);
        }
        public TableQuery<Trida> NacistTridy()
        {
            var Tridy = db.Table<Trida>();
            return Tridy;
        }
        public TableQuery<Polozka> NacistPolozky()
        {
            var Polozky = db.Table<Polozka>();
            return Polozky;
        }
        public Trida NacistTridu(int IDTridy)
        {
            Trida trida = db.Get<Trida>(IDTridy);
            return trida;
        }
        public void SmazatTridu(int IDTridy)
        {
            db.Delete(NacistTridu(IDTridy));
        }
        public Polozka NacistPolozku(int IDPolozky)
        {
            Polozka polozka = db.Get<Polozka>(IDPolozky);
            return polozka;
        }
        public void SmazatPolozku(int IDPolozky)
        {
            db.Delete(NacistPolozku(IDPolozky));
        }

        public ListViewItem VytvoritItemTridy(Trida trida)
        {
            ListViewItem Item = new ListViewItem { Height = 50 };
            Button button = new Button { Width = 440, Height = 46, Content = trida.Nazev, Name = "ID" + trida.ID.ToString() };
            Button button2 = new Button { Width = 46, Height = 46, Content = "Smazat", Name = "ID" + trida.ID.ToString() };
            StackPanel stackPanel = new StackPanel { Orientation = Orientation.Horizontal };
            stackPanel.Children.Add(button);
            stackPanel.Children.Add(button2);
            Item.Content = stackPanel;
            return Item;
        }
        public ListViewItem VytvoritItemPolozky(Polozka polozka)
        {
            ListViewItem Item = new ListViewItem { Height = 50, Content = polozka.Nazev + " - " + polozka.Cena };
            Label label = new Label { Width = 440, Height = 46, Content = polozka.Nazev, Name = "ID" + polozka.ID.ToString() };
            Button button2 = new Button { Width = 46, Height = 46, Content = "Smazat", Name = "ID" + polozka.ID.ToString() };
            StackPanel stackPanel = new StackPanel { Orientation = Orientation.Horizontal };
            stackPanel.Children.Add(label);
            stackPanel.Children.Add(button2);
            Item.Content = stackPanel;
            return Item;
        }
    }
}
