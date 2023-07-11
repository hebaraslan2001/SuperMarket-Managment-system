using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace SuperMarket_Managment
{
    
    public partial class Form2 : Form
    {
        
        OracleDataAdapter adapter;
        DataSet ds;
        OracleCommandBuilder builder;
        
        Form1 form1 = new Form1();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            string constr = "User Id=scott;Password=tiger;Data Source=orcl;";
            string cmdstr2 = "select product_name,id_product,price from PRODUCT";
            OracleDataAdapter adapter = new OracleDataAdapter(cmdstr2, constr);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            adapter.Fill(ds);
            adapter.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "product_name";
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string constr = "User Id=scott;Password=tiger;Data Source=orcl;";
            string cmdstr = "select ID_PRODUCT, PRICE,product_name FROM PRODUCT WHERE product_name=:n";
            OracleDataAdapter adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("n", comboBox1.Text);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            string constr = "User Id=scott;Password=tiger;Data Source=orcl;";
            string cmdstr = @"INSERT INTO Customer (customer_id, customer_name, phone, address) 
                              VALUES (:id, :Name, :phone, :Address)";

            OracleDataAdapter adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("id", comboBox2.Text);
            adapter.SelectCommand.Parameters.Add("Name", textBox1.Text);
            adapter.SelectCommand.Parameters.Add("phone", textBox3.Text);
            adapter.SelectCommand.Parameters.Add("Address", textBox2.Text);

            //string constr2 = "User Id=scott;Password=tiger;Data Source=orcl;";
            //string cmdstr2 = @"INSERT INTO Orders 
            //                  VALUES (:id2, :next)";

            //OracleDataAdapter adapter2 = new OracleDataAdapter(cmdstr2, constr2);
            //adapter2.SelectCommand.Parameters.Add("id2", comboBox2.Text);
            //adapter2.SelectCommand.Parameters.Add("next", NEXT_ORDER_ID);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=orcl;User Id=scott;Password=tiger";
            string cmdstr = "select * from customer where CUSTOMER_ID=:id";
            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("id", comboBox2.Text);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);

        }

        private void Button5_Click(object sender, EventArgs e)
        {
           // int NEXT_ORDER_ID = int.Parse(comboBox1.Text);
            //form1 = new Form1();
            form1.Show();
            this.Hide();
            string constr = "Data Source=orcl;User Id=scott;Password=tiger";
            string cmdstr = @"INSERT INTO Orders 
                              VALUES (:id2, NEXT_ORDER_ID.NEXTVAL)";
            OracleDataAdapter adapter2 = new OracleDataAdapter(cmdstr, constr);
            adapter2.SelectCommand.Parameters.Add("id2", comboBox2.Text);
           // adapter2.SelectCommand.Parameters.Add("next", NEXT_ORDER_ID+1000);
            DataSet ds = new DataSet();
            adapter2.Fill(ds);
        }
    }
}
