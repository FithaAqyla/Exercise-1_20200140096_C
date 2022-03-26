using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exee
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Exe();
        }
        public void Exe()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-AS5OAOK;database=Exe1; Integrated Security = TRUE");
                con.Open();

                SqlCommand Pm = new SqlCommand("Create table Pemilik (NIK_Pemilik char(10) not null primary key, Nama_Pemilik varchar (30), Alamat_Pemilik varchar(50), No_Hp varchar(10))", con);
                Pm.ExecuteNonQuery();
                SqlCommand Tk = new SqlCommand("Create table Toko_Kue (Id_Toko char(6) not null primary key,NIK_Pemilik char(10) references Pemilik(NIK_Pemilik) ,Nama_Toko varchar(20), Alamat_Toko varchar(13))", con);
                Tk.ExecuteNonQuery();
                SqlCommand Js = new SqlCommand("Create table Jenis_Kue (Kode_Kue char (7) not null primary key, Nama_Kue varchar(30), Harga_Kue char(10))", con);
                Js.ExecuteNonQuery();
                SqlCommand Pl = new SqlCommand("Create table Pembeli(Id_Pembeli char (10) not null primary key, Nama_Pembeli varchar(30), Alamat_Pembeli varchar (30),No_Hp varchar(12), Email_Pembeli varchar(30))", con);
                Pl.ExecuteNonQuery();
                SqlCommand Ts = new SqlCommand("Create table Transaksi (Id_Transaksi char(6) not null primary key, Id_Toko char(6) references Toko_Kue(Id_Toko), Id_Pembeli char(10) references Pembeli(Id_Pembeli), Kode_Kue char(7) references Jenis_Kue(Kode_Kue),Qty int,  Total varchar(10))", con);
                Ts.ExecuteNonQuery();





                Console.WriteLine("Tabel sukses dibuat!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, sepertinya ada yang salah. ", e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
            }
        }
    }
}
