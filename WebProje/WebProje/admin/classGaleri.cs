using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SemaDincer_GalleryManagement.admin
{
    public class classGaleri
    {
        int galeriID;
        String galeriAdi;
        String galeriAciklama;
        DateTime olusturmaTarihi;
       

        public int GaleriID
        {
            get
            {
                return galeriID;
            }

            set
            {
                galeriID = value;
            }
        }

        public string GaleriAdi
        {
            get
            {
                return galeriAdi;
            }

            set
            {
                galeriAdi = value;
            }
        }

        public string GaleriAciklama
        {
            get
            {
                return galeriAciklama;
            }

            set
            {
                galeriAciklama = value;
            }
        }

        public DateTime OlusturmaTarihi
        {
            get
            {
                return olusturmaTarihi;
            }

            set
            {
                olusturmaTarihi = value;
            }
        }

        
    }
}