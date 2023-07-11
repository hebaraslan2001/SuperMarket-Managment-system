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
    public partial class Form1 : Form
    {
        String ordb = "Data Source=ORCL; User Id =scott;password=tiger;";
        OracleConnection connection;

       
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new OracleConnection(ordb);
            connection.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connection;
            cmd.CommandText = "select CUSTOMER_ID from CUSTOMER";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = connection;
            cmd2.CommandText = "select product_name from PRODUCT";
            cmd2.CommandType = CommandType.Text;
            OracleDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox3.Items.Add(dr2[0]);
            }
            dr2.Close();

            comboBox4.Items.Add("Visa");
            comboBox4.Items.Add("Cash");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            OracleCommand cm = new OracleCommand();
            cm.Connection = connection;
            cm.CommandText = "Delete from customer where CUSTOMER_ID=:id";
            cm.CommandType = CommandType.Text;
            cm.Parameters.Add("id", comboBox1.Text);

            int read = cm.ExecuteNonQuery();
            if (read != -1)
            {

                MessageBox.Show("successfully");
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connection;
            cmd.CommandText = "select customer_name,PHONE,ADDRESS from customer where CUSTOMER_ID=:id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", comboBox1.SelectedItem.ToString());

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
            }
            dr.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = connection;
            //cmd.CommandText = "insert into CUSTOMER values (:id,:name,:phone,:address)";
            //cmd.CommandType = CommandType.Text;
            //cmd.Parameters.Add("id", comboBox1.Text);
            //cmd.Parameters.Add("name", textBox1.Text);
            //cmd.Parameters.Add("phone", textBox2.Text);
            //cmd.Parameters.Add("address", textBox3.Text);
            //int r = cmd.ExecuteNonQuery();
            //if (r != -1)
            //{
            //    comboBox1.Items.Add(comboBox1.Text);
            //    MessageBox.Show("successfully");
            //}

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connection;
            cmd.CommandText = "GetCopyID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id", comboBox1.Text);
            cmd.Parameters.Add("order_id", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0]);
            }


            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = connection;
            cmd2.CommandText = "SELECT product.product_name,product.price FROM order_product, product, orders WHERE order_product.order_id = orders.order_id AND order_product.id_product = product.id_product AND orders.customer_id = :id2";
            cmd.CommandType = CommandType.Text;
            cmd2.Parameters.Add("id2", comboBox1.Text);


            OracleDataAdapter adapter = new OracleDataAdapter(cmd2);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

          
            dr.Close();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            string select_name_product = comboBox3.SelectedItem.ToString();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connection;
            cmd.Parameters.Add("selected", select_name_product);
          
            cmd.CommandText = "insert into order_product(ID_product) select ID_product from product where PRODUCT_NAME = :selected " ;
            cmd.CommandType = CommandType.Text;
            
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = connection;
         
            cmd2.Parameters.Add("id", comboBox1.Text);
            cmd2.CommandText = @"UPDATE order_product
                               SET order_id = (SELECT order_id FROM orders WHERE customer_id = :id)
                               WHERE order_id IS NULL";
            cmd2.CommandType = CommandType.Text;
            int r = cmd.ExecuteNonQuery();
            int r2 = cmd2.ExecuteNonQuery();
            if (r != -1 && r2 !=-1)
            {
                //comboBox1.Items.Add(comboBox1.Text);
                MessageBox.Show("successfully");
            }

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connection;
            cmd.CommandText = "getPrice";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("cid", comboBox1.Text);
            cmd.Parameters.Add("price", OracleDbType.Int32, ParameterDirection.Output);
            int r = cmd.ExecuteNonQuery();
            if (r == -1)
            {
                textBox4.Text = cmd.Parameters["price"].Value.ToString();
            }

        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
           

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connection;
            
            cmd.CommandText = @"insert into payment (payment_type,card_number) values (:typeCard,:numberCard)";

            
            cmd.Parameters.Add("typeCard", comboBox4.Text);
            cmd.Parameters.Add("numberCard", textBox5.Text);
            cmd.CommandType = CommandType.Text;


            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = connection;

            cmd2.Parameters.Add("id2", comboBox1.Text);
            cmd2.CommandText = @"UPDATE payment
                               SET order_id = (SELECT order_id FROM orders WHERE customer_id = :id2)
                               WHERE order_id IS NULL";

            cmd2.CommandType = CommandType.Text;

            int r = cmd.ExecuteNonQuery();
            int r2 = cmd2.ExecuteNonQuery();

            if (r != -1 && r2 !=-1)
            {
                
                MessageBox.Show("successfully");
            }
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
