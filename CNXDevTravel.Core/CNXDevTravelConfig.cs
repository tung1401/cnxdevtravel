using System;
using System.Collections.Generic;
using System.Text;

namespace CNXDevTravel.Core
{
    public static class CNXDevTravelWebUIConfig
    {
        public static string APIEndPoint { get; set; }
        public static string AuthenEndPoint() { return $"{APIEndPoint}/Login"; }
    }

    public static class CNXDevTravelWebAPIConfig
    {
        public static string ConnectionString { get; set; }
        public static string TokenKey { get; set; }
    }
}
