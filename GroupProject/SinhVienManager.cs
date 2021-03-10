using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GroupProject
{
    public class SinhVienManager
    {
        private static SqlConnection Conn;
        private static SinhVienManager _Instance;
        public static SinhVienManager Instance
        {
            get
            {
                if (_Instance == null) _Instance = new SinhVienManager();
                return _Instance;
            }
            private set
            {
                _Instance = value;
            }
        }
        private SinhVienManager()
        {
            String ConnStr = "server=.;database=QLSVien;uid=sa;pwd=123456";
            Conn = new SqlConnection(ConnStr);
        }
        public SinhVien FindSinhVienByMaSV (int MaSV)
        {
            SinhVien sinhVien = null;
            String Sql = "SELECT * FROM dbo.SVIEN WHERE MASV = @MaSV";
            SqlCommand Cmd = new SqlCommand(Sql, Conn);
            Cmd.Parameters.AddWithValue("@MaSV", MaSV);
            try
            {
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                SqlDataReader DataReader = Cmd.ExecuteReader();
                if (DataReader.HasRows)
                {
                    while (DataReader.Read())
                    {
                        String HoSV = DataReader.GetString(1);
                        String TenSV = DataReader.GetString(2);
                        DateTime NgaySinh = DataReader.GetDateTime(3);
                        bool GioiTinh = DataReader.GetBoolean(4);
                        String MaKhoa = DataReader.GetString(5);

                        sinhVien = new SinhVien(MaSV, HoSV, TenSV, NgaySinh, GioiTinh, MaKhoa);
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                Conn.Close();
            }
            return sinhVien;
        }
        public DataTable FindKetQuaByMaSV (int MaSV)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "FindKetQuaByMaSV";
            Cmd.Parameters.Add("@MaSV", SqlDbType.Int).Value = MaSV;
            SqlDataAdapter DataAdapter= new SqlDataAdapter(Cmd);
            DataTable dtKetQua = new DataTable();
            try
            {
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                DataAdapter.Fill(dtKetQua);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                Conn.Close();
            }
            return dtKetQua;
        }
        public List<int> GetMaSV()
        {
            String Sql = "SELECT MASV FROM dbo.SVIEN";
            SqlCommand Cmd = new SqlCommand(Sql, Conn);
            List<int> Result = new List<int>();
            try
            {
                if(Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                SqlDataReader DataReader = Cmd.ExecuteReader();
                if (DataReader.HasRows)
                {
                    while (DataReader.Read())
                    {
                        Result.Add(DataReader.GetInt32(0));
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                Conn.Close();
            }
            return Result;
        }
    }
}
