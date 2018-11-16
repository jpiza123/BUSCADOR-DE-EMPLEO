using System;
using System.Collections.Generic;
using BolsadeEmpleo.Entidades;
using Xamarin.Forms;
namespace BolsadeEmpleo
{
    public partial class PublicarOferta : ContentPage
    {
        private Entry entryCargo;
        private Entry entryCiudad;
        private Entry entrySalario;
        private Picker picker;
        private Button botton;
        private ControladorDB db;
        private int idSession;

        public PublicarOferta(int idSession)
        {
            this.idSession = idSession;
            db = new ControladorDB();
            var layout = new StackLayout
            {
                Padding = 10
            };

            entryCargo = new Entry
            {
                Placeholder = "Ingrese nombre del cargo"
            };

            entrySalario = new Entry
            {
                Placeholder = "Ingrese el salario de la oferta"
            };

            List<Ciudad> ciudades = new Ciudad().getCiudades();
            picker = new Picker
            {
                Title = "Seleccione el lugar de la oferta",
                ItemsSource = ciudades
            };




            botton = new Button
            {
                Text = "Publicar Oferta"
            };
            botton.Clicked += Boton_Clicked;
            layout.Children.Add(entryCargo);
            layout.Children.Add(entrySalario);
            layout.Children.Add(picker);
            layout.Children.Add(botton);

            Content = layout;

        }



        public void Boton_Clicked(object sender, EventArgs e)
        {

            entryCiudad = new Entry
            {
                Text = picker.SelectedItem.ToString()
            };
            Oferta o = new Oferta
            {
                idPublicador = this.idSession,
                idCandidato = 0,
                ciudad = entryCiudad.Text,
                fecha = DateTime.Now.ToString("G"),
                nombreCargo = entryCargo.Text,
                salario = entrySalario.Text
            };
           
            int exito = this.db.SaveOferta(o);
            if (exito > 0)
                DisplayAlert("Éxito", "Oferta Publicada Correctamente! " , "OK");
            else
                DisplayAlert("Error", "Oferta NO Publicada Correctamente!", "OK");

        }

    }
}
