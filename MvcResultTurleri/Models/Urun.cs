using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcResultTurleri.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public decimal Fiyati { get; set; }
        public string Aciklama { get; set; }

    }
}