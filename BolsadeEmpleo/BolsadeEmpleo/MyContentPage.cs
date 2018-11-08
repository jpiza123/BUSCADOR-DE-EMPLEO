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
        public MyContentPage()
        {

            List<Ciudad> ciudades = new Ciudad().getCiudades();

            entryCargo = new Entry
            {
                Placeholder = "Cargo"
            };
            var layout = new StackLayout();
            picker = new Picker
            {
                Title = "Seleccione su lugar de residencia",
                ItemsSource = ciudades
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
                Keyboard = Keyboard.Text,
                Placeholder = "ciudad seleccionada:  "
            };
            //layout.Children.Add(entryCiudad);
            layout.Padding = 10;
            Content = layout;

        }

        async void Boton_Clicked(object sender, EventArgs e)
        {
            entryCiudad.Text = picker.SelectedItem.ToString();
            await Navigation.PushAsync(new BusquedaPage(entryCargo.Text,entryCiudad.Text ));
        }

    }
}
