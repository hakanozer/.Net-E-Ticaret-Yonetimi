using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProje.admin
{
    public class pIcerikYonetimi
    {

        int icerikID;

        public int IcerikID
        {
            get { return icerikID; }
            set { icerikID = value; }
        }
        string baslik;

        public string Baslik
        {
            get { return baslik; }
            set { baslik = value; }
        }
        string kisaAciklama;

        public string KisaAciklama
        {
            get { return kisaAciklama; }
            set { kisaAciklama = value; }
        }
        string detay;

        public string Detay
        {
            get { return detay; }
            set { detay = value; }
        }
        DateTime eklenmeTarihi;

        public DateTime EklenmeTarihi
        {
            get { return eklenmeTarihi; }
            set { eklenmeTarihi = value; }
        }

    }
}