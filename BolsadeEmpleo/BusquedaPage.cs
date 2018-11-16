using System;
using System.Linq;
using BolsadeEmpleo.Entidades;
using Xamarin.Forms;

namespace BolsadeEmpleo
{
    public class BusquedaPage: ContentPage
    {

        private ControladorDB db;
        private int idSession;
        public BusquedaPage(string cargo, string ciudad, int idSession)
        {
            this.idSession = idSession;
            this.db = new ControladorDB();
            if (!String.IsNullOrEmpty(ciudad))
                this.Title = ciudad;
            else
                this.Title = "Todas las ciudades";

            var listView = new ListView();
            listView.VerticalOptions = LayoutOptions.FillAndExpand;

            listView.ItemsSource = db.GetOfertaByCargoOCity(cargo, ciudad);

            var cell = new DataTemplate(typeof(ImageCell));
            //cell.SetBinding(ImageCell.ImageSourceProperty, "Image");

            cell.SetBinding(TextCell.TextProperty, "NombreCargo");
            cell.SetBinding(TextCell.DetailProperty, "Salario");

            listView.ItemTemplate = cell;
            listView.ItemTapped+= ListView_ItemTapped;
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { listView }
            };


        }


        void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var o = e.Item as Oferta;
            o.idCandidato = this.idSession;
            if (db.SaveOferta(o) > 0)
                db.SaveOferta(o);
                DisplayAlert("Éxito", "Ha aplicado a la oferta! "+ o.nombreCargo + " salaro " + o.salario, "OK");

        }

    }
}
