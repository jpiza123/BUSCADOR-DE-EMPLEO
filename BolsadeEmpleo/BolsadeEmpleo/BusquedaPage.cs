using System;
using Xamarin.Forms;

namespace BolsadeEmpleo
{
    public class BusquedaPage: ContentPage
    {

        public BusquedaPage(string cargo, string ciudad)
        {

            var layout = new StackLayout
            {
                Padding = 10
            };
            var label = new Label { Text = "Ha seleccionado los datos "+ ciudad + " "+ cargo , TextColor = Color.FromHex("#77d065"), FontSize = 20 };


            layout.Children.Add(label);
            Content = layout;

            
        }


    }
}
