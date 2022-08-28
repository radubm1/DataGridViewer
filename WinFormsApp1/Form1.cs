using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = "select * from Students;";
            string constr = "Server=localhost\\SQLEXPRESS;Database=test;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);
            bindingSource1.DataSource = table;
            dataGridView1.DataSource = bindingSource1;
        }

    }
}