using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAL dal = new DAL();
            DataTable dt = dal.GetAllStudents();
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            DAL dal = new DAL();

            foreach(DataRow row in dt.Rows)
            {
                if(row.RowState == DataRowState.Added)
                {
                    StudentDTO stu = new StudentDTO();
                    stu.Name = (String)row["Name"];
                    stu.DOB = (DateTime)row["DOB"];
                    dal.Save(stu);
                }
                else if (row.RowState == DataRowState.Modified)
                {
                    StudentDTO stu = new StudentDTO();
                    stu.Name = (String)row["Name"];
                    stu.DOB = (DateTime)row["DOB"];
                    dal.Update(stu);
                }
                else if (row.RowState == DataRowState.Deleted)
                {
                    var sid = (int)row["StudentId", DataRowVersion.Original];
                    dal.delete(sid);
                }
            }
            dt.AcceptChanges();
        }
    }
}
