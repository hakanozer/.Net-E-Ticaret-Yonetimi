using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProje.admin
{
    public class pHaberler
    {
        int hbrID;
        int hbrKatId;
        string hbrAciklama;
        string hbrBaslik;
        string hbrIcerik;
        string hbrResim;
        int hbrDurum;
        DateTime hbrTarih;

        public int HbrID
        {
            get
            {
                return hbrID;
            }

            set
            {
                hbrID = value;
            }
        }

        public int HbrKatId
        {
            get
            {
                return hbrKatId;
            }

            set
            {
                hbrKatId = value;
            }
        }

        public string HbrAciklama
        {
            get
            {
                return hbrAciklama;
            }

            set
            {
                hbrAciklama = value;
            }
        }

        public string HbrBaslik
        {
            get
            {
                return hbrBaslik;
            }

            set
            {
                hbrBaslik = value;
            }
        }

        public string HbrIcerik
        {
            get
            {
                return hbrIcerik;
            }

            set
            {
                hbrIcerik = value;
            }
        }

        public string HbrResim
        {
            get
            {
                return hbrResim;
            }

            set
            {
                hbrResim = value;
            }
        }

        public int HbrDurum
        {
            get
            {
                return hbrDurum;
            }

            set
            {
                hbrDurum = value;
            }
        }

        public DateTime HbrTarih
        {
            get
            {
                return hbrTarih;
            }

            set
            {
                hbrTarih = value;
            }
        }
    }
}