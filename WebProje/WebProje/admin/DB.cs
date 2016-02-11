using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace WebProje.admin
{
    public class DB
    {

        // bağlantı değişkenleri
        String dbName = "webProje";
        String userName = "sa";
        String userPass = "123456";
        String dataSource = "HI-SECTION-2-PC";

        // sqlconnetion nesnesi
        public SqlConnection conn = null;


        public DB()
        {
            try
            {
                // sql bağlantısı yapılıyor
                conn = new SqlConnection("Data Source=" + dataSource + ";Initial Catalog =" + dbName + ";User Id=" + userName+";integrated security=true");
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Bağlantı Hatası : " + ex);
            }
        }


        // kapatma fonksiyonu
        public void kapat()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                //MessageBox.Show("DB Kapatma Sorunu " + ex);
            }
        }


        // DB bağlantı açma
        public void ac()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {

                //MessageBox.Show("DB Kapatma Sorunu " + ex);
            }
        }


        // data getir fnc
        public SqlDataReader dataGetir(String tableName)
        {
            SqlDataReader rd = null;
            try
            {
                SqlCommand cm = new SqlCommand("select *from " + tableName, conn);
                rd = cm.ExecuteReader();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Data Getir Hatası : " + ex);
            }

            return rd;
        }


        // dataTable doldur
        public DataTable dataGrid(String query)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cm = new SqlCommand(query, conn);
                SqlDataReader rd = cm.ExecuteReader();
                dt.Load(rd);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Datatable Doldurma Hatası : " + ex);
            }
            return dt;

        }


        public static string MD5Sifrele(string metin)
        {
            // MD5CryptoServiceProvider nesnenin yeni bir instance'sını oluşturalım.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            //Girilen veriyi bir byte dizisine dönüştürelim ve hash hesaplamasını yapalım.
            byte[] btr = Encoding.UTF8.GetBytes(metin);
            btr = md5.ComputeHash(btr);

            //byte'ları biriktirmek için yeni bir StringBuilder ve string oluşturalım.
            StringBuilder sb = new StringBuilder();


            //hash yapılmış her bir byte'ı dizi içinden alalım ve her birini hexadecimal string olarak formatlayalım.
            foreach (byte ba in btr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            //hexadecimal(onaltılık) stringi geri döndürelim.
            return sb.ToString();
        }



    }
}
