using System;

using BolsadeEmpleo.Entidades;
using Xamarin.Forms;

namespace BolsadeEmpleo
{
    
    public class LoginPage : ContentPage
    {
        private ControladorDB db;
        private Entry entryUsuario;
        private Entry entryPass;
        private int idSession = 0;
        public LoginPage()
        {
            db = new ControladorDB();
            Title = "Emplear";
            Button registrarBoton = new Button
            {
                Text = "Registrar"
            };
            registrarBoton.Clicked += RegistrarBoton_Clicked;
            Button logearBoton = new Button
            {
                Text = "Logear"
            };
            logearBoton.Clicked += LogearBoton_ClickedAsync;
            
            
            entryUsuario = new Entry { Placeholder = "Usuario" };
            entryPass = new Entry { IsPassword = true, Placeholder = "Contraseña" };

            var stack = new StackLayout
            {
                Padding = 20,
                Children = {
                    new Image { Source = "web_hi_res_512.jpg" },
                    new Label {Text = "Bienvenido a Emplear"}, 
                    entryUsuario,
                    entryPass,
                    logearBoton,
                    registrarBoton
                    
                    
                }
            };
            Content = new ScrollView { Content = stack };
        }

       


        void RegistrarBoton_Clicked(object sender, EventArgs e)
        {
            Usuario u = new Usuario
            {
                contraseña = entryPass.Text,
                username = entryUsuario.Text
            };
            this.idSession  = this.db.SaveUser(u);
            if(this.idSession !=0)
            DisplayAlert("Éxito", "Registrado Correctamente con datos " , "OK");
            else{
                DisplayAlert("Error", "Nombre de Usuario ya existente " , "OK");
                this.idSession = 0;
            }


        }


        async void LogearBoton_ClickedAsync(object sender, EventArgs e)
        {
            this.idSession = this.db.GetUserbyUserPass(entryUsuario.Text, entryPass.Text);
                if (idSession > 0){
                await Navigation.PushAsync(new MainPage(idSession));
            }
            else{
                await DisplayAlert("Error", "Nombre de Usuario o Contraseña incorreto ", "OK");
            }
        }


    }
}

