using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3DPrintHub.RESTApiPrinter
{
    public class RestApi
    {
        // Properties for Rest-Client
        private RestClient client = new RestClient("http://10.0.0.3/api/printer/");
        private RestRequest request = new RestRequest(Method.GET);
        private RootObject rootobject;

        public RestApi()
        {
            // Constructor init GET Request
            request.AddHeader("Postman-Token", "221f5c17-e10a-4ddc-9b82-44034b43e5b5");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("x-api-key", "60F33BE1DB34464789BF6D16F2EA1769");
            IRestResponse response = client.Execute(request);
            IRestResponse<RootObject> response2 = client.Execute<RootObject>(request);
            rootobject = response2.Data;
        }


        public float ReturnActual()
        {
            return rootobject.temperature.Tool0.actual;
        }

        public int ReturnOffset()
        {
            return rootobject.temperature.Tool0.offset;
        }

        public int ReturnTarget()
        {
            return rootobject.temperature.Tool0.target;
        }

    }
}
