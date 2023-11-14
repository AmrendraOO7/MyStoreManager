using Devart.Data.PostgreSql;
using MSMControl.Class;
using MSMControl.Connection;
using MSMControl.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreManager.Print
{
    public partial class frm_Print_Data : Form
    {
        private readonly IMainMaster mainMaster = new ClsMainMaster();
        public frm_Print_Data()
        {
            InitializeComponent();
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            var ds = new DataSet();

            dt.Columns.Add("PID", typeof(string));
            dt.Columns.Add("PName", typeof(string));
            dt.Columns.Add("PCode", typeof(string));
            dt.Columns.Add("PBarcode", typeof(string));
            dt.Columns.Add("UnitID", typeof(string));
            dt.Columns.Add("UnitQnty", typeof(string));
            dt.Columns.Add("AltUnitId", typeof(string));
            dt.Columns.Add("AltUnitQnty", typeof(string));
            dt.Columns.Add("PurchasePrice", typeof(string));
            dt.Columns.Add("MRP", typeof(string));
            dt.Columns.Add("Offer", typeof(string));
            dt.Columns.Add("PNote", typeof(string));
            dt.Columns.Add("ActiveStatus", typeof(string));
            dt.Columns.Add("UserID", typeof(string));
            dt.Columns.Add("DateCreated", typeof(string));
            dt.Columns.Add("MUserID", typeof(string));
            dt.Columns.Add("ModifiedDate", typeof(string));

            foreach (DataGridViewRow dgv in dataGridView.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value, dgv.Cells[9].Value, dgv.Cells[10].Value, dgv.Cells[11].Value, dgv.Cells[12].Value, dgv.Cells[13].Value, dgv.Cells[14].Value, dgv.Cells[15].Value, dgv.Cells[16].Value);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("application.xml");
        }

        private void frm_Print_Data_Load(object sender, EventArgs e)
        {
            //string cs = "User Id=sa;Host=localhost;Port=5433;Database=db;Initial Schema=kb;Password=321";
            string cs = $"data source = {Global.ServerName}; Database = {Global.InitialCatalogMain}; integrated security = False; user id = {Global.UserId}; password ={Global.Password}";
            PgSqlConnection conn = new PgSqlConnection(cs);
            PgSqlCommand cmd = new PgSqlCommand();
            PgSqlDataAdapter adptr = new PgSqlDataAdapter();

            string Query = "SELECT [POID],[POVNUM],[Order_Date],[Order_Miti],[ReceiverID],[SenderID],[TransectionOn],[Total],[Vat],[VatAmt],[TotalAmount],[Discount],[DiscAmount],[BillTotal],[InWords],[PO_Bill_Status],[UserID],[DateCreated],[MUserID],[ModifiedDate]FROM [MSM].[PurchaseOrderMaster]";

            //DataTable dt = new DataTable();
            //cmd.Connection = conn;
            //cmd.CommandText = Query;
            //conn.Open();
            //adptr.SelectCommand = cmd;
            //adptr.Fill(dt);
            //dataGridView.DataSource = dt;
            //dataGridView.Refresh();

            var dt = ClsMainMaster.GetProduct();
            dataGridView.DataSource = dt;
            dataGridView.Refresh();
        }
    }
}
