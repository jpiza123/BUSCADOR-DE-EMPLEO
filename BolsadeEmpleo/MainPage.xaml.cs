using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BolsadeEmpleo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {

        public List<MasterPageItem> menuList { get; set; }
        private int idSession;



        public MainPage(int idSession)
        {

            Title = "Emplear ";
            this.idSession = idSession;
            InitializeComponent();

            menuList = new List<MasterPageItem>();


            var page1 = new MasterPageItem() { Title = "Buscar Oferta", Icon = "BuscarIcon.png", content = new MyContentPage(idSession) };
            var page2 = new MasterPageItem() { Title = "Ver Ofertas Aplicadas", Icon = "BuscarIcon.png", content = new MyAplicatonsPage(idSession) };
            var page3 = new MasterPageItem() { Title = "Publicar Oferta", Icon = "PostularIcon.png", content = new PublicarOferta(idSession) };
            var page4 = new MasterPageItem() { Title = "Ver Ofertas Publicadas", Icon = "PostularIcon.png", content = new MisPublicacionesPage(idSession) };
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            navigationDrawerList.ItemsSource = menuList;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MyContentPage), idSession));
             this.BindingContext = new
            {
                header= "EMPLEAR",
                Footer = "Bienvenido a Emplear"
            };

        }
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            ContentPage page = item.content;
            if (page is MyAplicatonsPage)
                Detail = new NavigationPage(new MyAplicatonsPage(this.idSession));
            else
                if(page is MisPublicacionesPage)
                    Detail = new NavigationPage(new MisPublicacionesPage(this.idSession));
                else
                    Detail = new NavigationPage(page);
            NavigationPage.SetHasNavigationBar(this, false);
            IsPresented = false;
        }
    }
}
