using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final040090206
{
    class Data
    {

        public string brand;
        public string storeNumber;
        public string storeName;
        public string ownershipType;
        public string streetAdress;
        public string city;
        public string state;
        public string country;
        public string postCode;
        public string phone;
        public string timezone;
        public double longitude;
        public double latitude;


        //constructor
        public Data(string xbrand="", string xstoreNumber= "", string xstoreName= "", string xownership = "", string xstreet = "", string xcity = "", string xstate = "", string xcountry = "", string xpostcode = "", string xphone = "", string xtimezone = "", double xlongitude = 0, double xlatitude = 0)
        {
            brand = xbrand;
            storeNumber = xstoreNumber;
            storeName = xstoreName;
            ownershipType = xownership;
            streetAdress = xstreet;
            city = xcity;
            state = xstate;
            country = xcountry;
            postCode = xpostcode;
            phone = xphone;
            timezone = xtimezone;
            longitude = xlongitude;
            latitude = xlatitude;
        }
    }
}
