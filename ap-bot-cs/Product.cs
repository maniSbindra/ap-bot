using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiDialogsBot
{
    public class Product
    {
       
        public string id { get; set; }
        public List<string> productCategory { get; set; }
        public string productCode { get; set; }
        public string productName { get; set; }
        public List<string> fastFacts { get; set; }
        public List<string> applications { get; set; }
        public List<string> features { get; set; }
        public List<string> benefits { get; set; }
    
    }
}