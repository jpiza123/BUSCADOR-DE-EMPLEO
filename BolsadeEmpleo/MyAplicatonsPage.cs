using System;
using Xamarin.Forms;

namespace BolsadeEmpleo
{
    internal class MyAplicatonsPage : ContentPage
    {
        private int idSession;
        private ControladorDB db;
        ListView listView;
        public MyAplicatonsPage(int idSession)
        {
            this.idSession = idSession;
            this.db = new ControladorDB();
            this.listView = new ListView();
            listView.VerticalOptions = LayoutOptions.FillAndExpand;
            if (db.GetOfertasByIdCandidato(this.idSession) != null)
            {
                listView.ItemsSource = db.GetOfertasByIdCandidato(idSession);
                var cell = new DataTemplate(typeof(ImageCell));
                //cell.SetBinding(ImageCell.ImageSourceProperty, "Image");

                cell.SetBinding(TextCell.TextProperty, "NombreCargo");
                cell.SetBinding(TextCell.DetailProperty, "Salario");

                listView.ItemTemplate = cell;
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Children = { listView }
                };

            }

            else
                DisplayAlert("Error", "No ha aplicado a ninguna oferta! ", "OK");

        }

    }
}