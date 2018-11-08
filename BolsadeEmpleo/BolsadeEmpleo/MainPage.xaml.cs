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
        public MainPage()
        {
            InitializeComponent();

            menuList = new List<MasterPageItem>();
            var page1 = new MasterPageItem() { Title = "Buscar Oferta", Icon = "mainIcono.png", content = new MyContentPage() };
            var page2 = new MasterPageItem() { Title = "Publicar Oferta", Icon = "mainIcono.png", content = new PublicarOferta() };
            menuList.Add(page1);
            menuList.Add(page2);
            navigationDrawerList.ItemsSource = menuList;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MyContentPage)));
             this.BindingContext = new
            {
                Header = "",
                Image = "https://visualpharm.com/assets/971/Find%20Matching%20Job-595b40b75ba036ed117d7d93.svg",
                //Footer = "         -------- Welcome To HotelPlaza --------           "
                Footer = "Bienvenido a Emplear"
            };

        }
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            ContentPage page = item.content;
            Detail = new NavigationPage(page);
            IsPresented = false;
        }
    }
}
