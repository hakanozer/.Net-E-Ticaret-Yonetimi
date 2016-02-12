using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProje.admin
{
    public  class pUreticiler
    {

          int  ureticiID;
         string ureticiAdi;
         string logoAdi;
         DateTime tarih;

        public  int UreticiID
        {
            get
            {
                return ureticiID;
            }

            set
            {
                ureticiID = value;
            }
        }

        public  string UreticiAdi
        {
            get
            {
                return ureticiAdi;
            }

            set
            {
                ureticiAdi = value;
            }
        }

        public   string LogoAdi
        {
            get
            {
                return logoAdi;
            }

            set
            {
                logoAdi = value;
            }
        }

        public  DateTime Tarih
        {
            get
            {
                return tarih;
            }

            set
            {
                tarih = value;
            }
        }

    }
}