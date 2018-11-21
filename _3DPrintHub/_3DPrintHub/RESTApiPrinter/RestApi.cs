using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3DPrintHub.RESTApiPrinter
{
    public class RestApi
    {
        // Properties for Rest-Client
        private RestClient client = new RestClient("http://10.0.0.3/api/printer");
        private RestRequest request = new RestRequest(Method.GET);
        private RootObject rootobject;
        private Temperature temperature;
        private Tool0 tool0;
        private State state;
        private bool isApiOnline;

        public RestApi()
        {
            // Constructor init GET Request
            request.AddHeader("Postman-Token", "221f5c17-e10a-4ddc-9b82-44034b43e5b5");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("x-api-key", "60F33BE1DB34464789BF6D16F2EA1769");
            IRestResponse response = client.Execute(request);

            // deserialize RootObject
            IRestResponse<RootObject> response2 = client.Execute<RootObject>(request);
            rootobject = response2.Data;

            if (rootobject == null)
            {
                // if API is offline
                isApiOnline = false;
            } else
            {
                
                //asign objects
                temperature = rootobject.temperature;
                state = rootobject.state;
                tool0 = temperature.Tool0;

            }

            
            
        }

        public string ReturnOpState()
        {
            if(isApiOnline)
            {
                if (state.flags.operational == true)
                    return "Operational";
                else return "Offline";

            } else
            {
                // if API is offline return "Offline"
                return "Offline";
            }
            
        }

        public float ReturnActual()
        {
            if (isApiOnline)
                return tool0.actual;
            else return 0;
        }

        public int ReturnOffset()
        {
            if (isApiOnline)
                return tool0.offset;
            else return 0;
        }

        public int ReturnTarget()
        {
            if (isApiOnline)
                return tool0.target;
            return 0;
        }

    }
}
