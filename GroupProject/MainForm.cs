using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GroupProject
{
    public partial class MainForm : Form
    {
        DataTable dt;
        public MainForm()
        {
            InitializeComponent();
            LoadComboBox();
        }

        public void LoadComboBox()
        {
            try
            {
                List<int> cbxList = SinhVienManager.Instance.GetMaSV();
                foreach(int value in cbxList){
                    cbxMaSV.Items.Add(value);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void LoadTextBox(int MaSV)
        {
            SinhVien sinhVien = SinhVienManager.Instance.FindSinhVienByMaSV(MaSV);
            txtHoSV.Text = sinhVien.HoSV.Trim();
            txtTenSV.Text = sinhVien.TenSV.Trim();
            txtNgaySinh.Text = sinhVien.NgaySinh.ToString().Trim();
            if (sinhVien.GioiTinh)
                txtGioiTinh.Text = "Nam";
            else
                txtGioiTinh.Text = "Nữ";
            txtMaKhoa.Text = sinhVien.MaKhoa.Trim();
            txtDiemTB.Text = "0";
        }
        public void LoadDataGridView(int MaSV)
        {
            dt = SinhVienManager.Instance.FindKetQuaByMaSV(MaSV);
            dgvKetQua.DataSource = dt;
            txtDiemTB.Text = "" + dt.Compute("AVG([DIEM TRUNG BINH])", string.Empty);
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            int MaSV = (int) cbxMaSV.SelectedItem;
            LoadTextBox(MaSV);
            LoadDataGridView(MaSV);
        }
    }
}
