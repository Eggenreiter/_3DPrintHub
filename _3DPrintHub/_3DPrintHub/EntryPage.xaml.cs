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

            // initialize printer status
            update_printer_status();
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
            actual_temp.Text = actual.ToString();
            offset_temp.Text = offset.ToString();
            target_temp.Text = target.ToString();

        }
    }
}