using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAn
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=PhanQuyen;Integrated Security=True");


        private string getID(string username, string pass)
        {
            string id = "";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM NguoiDung WHERE ND_User ='" + tbUser.Text + "' and ND_pass='" + tbPasswork.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr["ND_ID"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            return id;
        }
        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            tbUser.Clear();
            
            panel1.ForeColor = Color.Black;
            tbUser.ForeColor = Color.Black;

            
            panel2.ForeColor = Color.Black;
            tbPasswork.ForeColor = Color.Black;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            tbPasswork.Clear();
            tbPasswork.PasswordChar = '*';
            
            panel2.ForeColor = Color.Black;
            tbPasswork.ForeColor = Color.Black;

            
            panel1.ForeColor = Color.Black;
            tbPasswork.ForeColor = Color.Black;
        }

    
        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }
        public static string ID_USER = "";
        private void button1_Click(object sender, EventArgs e)
        {
            ID_USER = getID(tbUser.Text, tbPasswork.Text);
            if (ID_USER != "")
            {
                
                //HeThongTachFile fmain = new HeThongTachFile();
                
                //fmain.Show();
               
            }
            else
            {
                MessageBox.Show("Tài khoản và mật khẩu không đúng !");
            }
        }
    }
}
