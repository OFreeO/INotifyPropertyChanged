using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private BindingSource StudentBindingSource = new BindingSource();

        string Table = "Student";

        const string MYDB = "Server=localhost; Port=3306; Database=Student; userid  = root; Pwd = 0729;";

        MySqlConnection MyConn = new MySqlConnection(MYDB);

        List<Student> students = new List<Student>();


        public Form1()
        {
            InitializeComponent();

        }

        public void ConnectDB()
        {         
            try
            {
                MyConn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("실패");
                Console.WriteLine(e.ToString());
                MyConn.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindingList<Student> studentList =
              this.StudentBindingSource.DataSource as BindingList<Student>;

            dataGridView1.Rows.Clear();

            studentList.Clear();

            ConnectDB();

            string sql = $"select * from {Table}";
            MySqlDataAdapter sda = new MySqlDataAdapter();
            sda.SelectCommand = new MySqlCommand();
            sda.SelectCommand.Connection = MyConn;
            sda.SelectCommand.CommandText = sql;

            DataSet ds = new DataSet();
            ds.Clear();
            
            sda.Fill(ds, Table);



            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Student student = new Student();

                student.Grade = item["Grade"].ToString();
                student.Cclass = item["Cclass"].ToString();
                student.No = item["No"].ToString();
                student.Name = item["Name"].ToString();
                student.Score = item["Score"].ToString();
                

                //students.Add(student);
                studentList.Add(new Student(student.Grade, student.Cclass, student.No,student.Name, student.Score));
                
            }
            dataGridView1.DataSource = studentList;
            MyConn.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            BindingList<Student> studentList =
                this.StudentBindingSource.DataSource as BindingList<Student>;

            ConnectDB();

            if (this.dataGridView1.RowCount == 0)
                return;


            int rowIndex = dataGridView1.CurrentRow.Index;
            Student s = studentList[rowIndex];

            string G = s.Grade;
            string Cc = s.Cclass;
            string No = s.No;
            string Na = s.Name;
            string S = s.Score;

            string sql = $"insert into {Table} values ('{G}','{Cc}','{No}','{Na}','{S}')";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = MyConn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            MyConn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindingList<Student> studentList =
                this.StudentBindingSource.DataSource as BindingList<Student>;

            ConnectDB();

            if (this.dataGridView1.RowCount == 0)
                return;


            int rowIndex = dataGridView1.CurrentRow.Index;

            Student s = studentList[rowIndex];

            string G = s.Grade;
            string Cc = s.Cclass;
            string No = s.No;
            string Na = s.Name;
            string S = s.Score;

            string sql = $"update {Table} set Grade = '{G}', Cclass = '{Cc}', No = '{No}', Score = '{S}' where Name='{Na}'";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = MyConn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            MyConn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BindingList<Student> studentList =
                this.StudentBindingSource.DataSource as BindingList<Student>;

            ConnectDB();
            int rowIndex = dataGridView1.CurrentRow.Index;

            Student s = studentList[rowIndex];

            studentList.Remove(studentList[rowIndex]);

            string Na = s.Name;

            Console.WriteLine(Na);


            //studentList.Remove(studentList[rowIndex]);

            string sql = $"delete from {Table} where name = '{Na}'";


            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = MyConn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            MyConn.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindingList<Student> studentList = new BindingList<Student>();
            this.StudentBindingSource.DataSource = studentList;
            this.dataGridView1.DataSource = this.StudentBindingSource;
            button1_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BindingList<Student> studentList =
             this.StudentBindingSource.DataSource as BindingList<Student>;

            foreach(var item in studentList)
            {
                Console.WriteLine(item.Grade);
                Console.WriteLine(item.Cclass);
                Console.WriteLine(item.No);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Score);
            }
        }
    }
}
