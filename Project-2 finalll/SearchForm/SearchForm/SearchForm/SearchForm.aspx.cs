using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Project_2;
namespace SearchForm
{
    public partial class SearchForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            load_data();
        }
        public void load_data()
        {
            string sdt = txt_sdt.Text;
            int m = int.Parse(lst_thang.Text);
            Array select;
            lb_tongtien.Text = "0";
            select = QuanLyNguoiDung_QuanLy_DAO.Load_data(sdt, m);
            // t = int.Parse(select[0,{ "Tien_cuoc"}]);
            GridView1.DataSource = select;
            GridView1.DataBind();
            foreach (GridViewRow row in GridView1.Rows)
            {
                lb_tongtien.Text = (float.Parse(lb_tongtien.Text.ToString()) + float.Parse(row.Cells[3].Text.ToString())).ToString();
            }

            lb_tongtien.Visible = false;
        }
        int stt = 1;
        public string get_stt()
        {
            return Convert.ToString(stt++);
        }
        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sdt = txt_sdt.Text;
             int m =int.Parse( lst_thang.Text);
            Array select;
            lb_tongtien.Text = "0";
            select = QuanLyNguoiDung_QuanLy_DAO.Load_data(sdt,m);
           // t = int.Parse(select[0,{ "Tien_cuoc"}]);
            GridView1.DataSource = select;
            GridView1.DataBind();
            GridView temp = new GridView();
            temp.DataSource = select;
            temp.DataBind();
            foreach (GridViewRow row in temp.Rows)
            {
                lb_tongtien.Text = (float.Parse(lb_tongtien.Text.ToString()) + float.Parse(row.Cells[3].Text.ToString())).ToString();
            }

            //if(txt_sdt.Text == "")
            //{
            //    load_data();
            //}
            lb_tongtien.Visible = true;
        }

        protected void P(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;   //trang hien tai
            int trang_thu = e.NewPageIndex;      //the hien trang thu may
            int so_dong = GridView1.PageSize;       //moi trang co bao nhieu dong
            stt = trang_thu * so_dong + 1;
            load_data();
        }

        protected void txt_sdt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}