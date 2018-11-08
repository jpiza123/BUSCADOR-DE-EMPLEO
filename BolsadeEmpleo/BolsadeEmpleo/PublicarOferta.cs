using System;
using System.Collections.Generic;
using Xamarin.Forms;
namespace BolsadeEmpleo
{
    public partial class PublicarOferta : ContentPage
    {
        private Entry entryCargo;
        private Entry entryCiudad;
        private Picker picker;
        private Button botton;
        private Oferta oferta;

        public PublicarOferta()
        {

            var layout = new StackLayout
            {
                Padding = 10
            };

            entryCargo = new Entry
            {
                Placeholder = "Ingrese nombre del cargo"
            };

            List<Ciudad> ciudades = new Ciudad().getCiudades();
            picker = new Picker
            {
                Title = "Seleccione su lugar de la oferta",
                ItemsSource = ciudades
            };




            botton = new Button
            {
                Text = "Publicar Oferta"
            };
            botton.Clicked += Boton_Clicked;
            layout.Children.Add(entryCargo);
            layout.Children.Add(picker);
            layout.Children.Add(botton);

            Content = layout;

        }

        async void Boton_Clicked(object sender, EventArgs e)
        {

            entryCiudad = new Entry();
            entryCiudad.Text = picker.SelectedItem.ToString();

            oferta = new Oferta(entryCargo.Text, DateTime.Now.ToString(), entryCiudad.Text);

            await Navigation.PushAsync(new publicarOfertaPage());

        }

    }
}
