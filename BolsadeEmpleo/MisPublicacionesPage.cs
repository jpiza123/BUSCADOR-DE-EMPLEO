using Xamarin.Forms;

namespace BolsadeEmpleo
{
    internal class MisPublicacionesPage : ContentPage
    {
        private int idSession;
        private ControladorDB db;
        private ListView listView;
        public MisPublicacionesPage(int idSession)
        {
            this.idSession = idSession;
            db = new ControladorDB();
            this.listView = new ListView();
            listView.VerticalOptions = LayoutOptions.FillAndExpand;
            if (db.GetOfertasByIdPublicador(this.idSession) != null)
            {
                listView.ItemsSource = db.GetOfertasByIdPublicador(idSession);
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
                DisplayAlert("Error", "No ha publicado ninguna oferta! ", "OK");

        }

    }
}