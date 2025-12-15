using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAI.Project3_RapidApi.ViewModels
{
    public class ApiSeriesViewModel
    {
        public int rank { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string big_image { get; set; }
        public string[] genre { get; set; }
        public float rating { get; set; }
        public string year { get; set; }
        public string imdbid { get; set; }
    }
}