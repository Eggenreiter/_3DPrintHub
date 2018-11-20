using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace _3DPrintHub
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //load splashscreen logo
            splashscreen.Source = ImageSource.FromResource("_3DPrintHub.Images.splash_logo.png");

        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EntryPage());

        }
    }
}
