using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SemaDincer_GalleryManagement.admin
{
    public class classResim
    {
        int resimID;
        int rgaleriID;
        String resimAdi;
        String resim;
        DateTime tarih;

        public int ResimID
        {
            get
            {
                return resimID;
            }

            set
            {
                resimID = value;
            }
        }

        public int RgaleriID
        {
            get
            {
                return rgaleriID;
            }

            set
            {
                rgaleriID = value;
            }
        }

        public string ResimAdi
        {
            get
            {
                return resimAdi;
            }

            set
            {
                resimAdi = value;
            }
        }

        public string Resim
        {
            get
            {
                return resim;
            }

            set
            {
                resim = value;
            }
        }

        public DateTime Tarih
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