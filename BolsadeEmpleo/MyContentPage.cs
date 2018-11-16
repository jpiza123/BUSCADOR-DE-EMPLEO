using System;
using System.Collections.Generic;
using Xamarin.Forms;
namespace BolsadeEmpleo
{
	public class MyContentPage: ContentPage
    {
        public Entry entryCargo;
        public Entry entryCiudad;
        public Picker picker;
        public Button boton;
        public int idSession { get; set; }

        public MyContentPage(int idSession)
        {

            this.idSession = idSession;
            List<Ciudad> ciudades = new Ciudad().getCiudades();

            entryCargo = new Entry
            {
                Placeholder = "Cargo "
            };
            var layout = new StackLayout();
            picker = new Picker
            {
                //Title = "Seleccione su lugar de residencia",
                ItemsSource = ciudades,
                SelectedIndex = ciudades.Count
            };

            boton = new Button
            {
                Text = "Bucar empleo"
            };
            boton.Clicked += Boton_Clicked;
            layout.Children.Add(entryCargo);
            layout.Children.Add(picker);
            layout.Children.Add(boton);

            entryCiudad = new Entry
            {
                Keyboard = Keyboard.Text
            };

            layout.Padding = 10;
            Content = layout;

        }

        async void Boton_Clicked(object sender, EventArgs e)
        {
            entryCiudad.Text = picker.SelectedItem.ToString();
            if (String.IsNullOrWhiteSpace(entryCargo.Text) || String.IsNullOrWhiteSpace(entryCiudad.Text))
                await this.DisplayAlert("Advertencia", "Los campos son obligatorios.", "OK");
            else{
                await Navigation.PushAsync(new BusquedaPage(entryCargo.Text, entryCiudad.Text, this.idSession));
            }
                


        }

    }
}
