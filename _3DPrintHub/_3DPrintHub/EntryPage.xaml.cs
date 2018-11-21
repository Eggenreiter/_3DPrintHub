using _3DPrintHub.RESTApiPrinter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _3DPrintHub
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EntryPage : ContentPage
	{

		public EntryPage ()
		{
			InitializeComponent ();


            //load operational & temperature logos
            /*
             * <div>Icons made by <a href="https://www.flaticon.com/authors/iconixar" title="iconixar">iconixar</a> from <a href="https://www.flaticon.com/" 			    title="Flaticon">www.flaticon.com</a> is licensed by <a href="http://creativecommons.org/licenses/by/3.0/" 			    title="Creative Commons BY 3.0" target="_blank">CC 3.0 BY</a></div>
             * 
             * <div>Icons made by <a href="https://www.freepik.com/" title="Freepik">Freepik</a> from <a href="https://www.flaticon.com/" 			    title="Flaticon">www.flaticon.com</a> is licensed by <a href="http://creativecommons.org/licenses/by/3.0/" 			    title="Creative Commons BY 3.0" target="_blank">CC 3.0 BY</a></div>
             * 
             */
            state_icon.Source = ImageSource.FromResource("_3DPrintHub.Images.state.png");
            temperature.Source = ImageSource.FromResource("_3DPrintHub.Images.temperature.png");
            temperature1.Source = ImageSource.FromResource("_3DPrintHub.Images.temperature1.png");
            temperature2.Source = ImageSource.FromResource("_3DPrintHub.Images.temperature2.png");
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            update_printer_status();

        }

        private void update_printer_status()
        {
            RestApi restapi = new RestApi();
            float actual = restapi.ReturnActual();
            float offset = restapi.ReturnOffset();
            float target = restapi.ReturnTarget();
            string state = restapi.ReturnOpState();

            operational_state.Text = state;
            actual_temp.Text = actual.ToString();
            offset_temp.Text = offset.ToString();
            target_temp.Text = target.ToString();


        }
    }
}