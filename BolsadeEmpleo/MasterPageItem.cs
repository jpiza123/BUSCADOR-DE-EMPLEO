using System;
using Xamarin.Forms;

namespace BolsadeEmpleo
{
    public class MasterPageItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public ContentPage content { get; set; }
        public int idSession { get; set; }
    }
}
