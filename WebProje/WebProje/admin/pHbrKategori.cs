using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProje.admin
{
    public class pHbrKategori
    {
        int katId;
        string katAd;

        public int KatId
        {
            get
            {
                return katId;
            }

            set
            {
                katId = value;
            }
        }

        public string KatAd
        {
            get
            {
                return katAd;
            }

            set
            {
                katAd = value;
            }
        }
    }
}