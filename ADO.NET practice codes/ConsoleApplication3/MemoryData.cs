using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class MemoryData
    {
        public DataTable CreateDataTable()
        {
            DataTable dt = new DataTable("Students");
            DataColumn dc = new DataColumn("Name", typeof(System.String));
            dt.Columns.Add(dc);

            dc = new DataColumn("Age", typeof(System.Int32));
            dt.Columns.Add(dc);

            DataRow dr = dt.NewRow();
            dr["Name"] = "shahbaz";
            dr["Age"] = 21;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Name"] = "arslan";
            dr["Age"] = 22;
            dt.Rows.Add(dr);
            return dt;
        }

        public void PrintDataTable(DataTable dt)
        {
            foreach(DataColumn dc in dt.Columns)
            {
                Console.WriteLine("ColumnName:{0}", dc.ColumnName);
                Console.WriteLine("Data Type:{0}", dc.DataType);

                foreach(DataRow row in dt.Rows)
                {
                    if(row.RowState == DataRowState.Unchanged)
                    {
                        Console.WriteLine("Name:{0}", row["Name"]);
                        Console.WriteLine("Age:{0}", row["Age"]);
                        Console.WriteLine("State:{0}", row.RowState);

                    }
                    else if(row.RowState == DataRowState.Added)
                    {
                        Console.WriteLine("Name:{0}", row["Name"]);
                        Console.WriteLine("Age:{0}", row["Age"]);
                        Console.WriteLine("State:{0}", row.RowState);
                    }
                    else if(row.RowState == DataRowState.Modified)
                    {
                        Console.WriteLine("Name:{0}", row["Name"]);
                        Console.WriteLine("Age:{0}", row["Age"]);
                        Console.WriteLine("State:{0}", row.RowState);
                    }
                    
                    else if(row.RowState == DataRowState.Deleted)
                    {
                        Console.WriteLine("Name:{0}", row["Name"]);
                        Console.WriteLine("Age:{0}", row["Age"]);
                        Console.WriteLine("State:{0}", row.RowState);
                    }
                }
            }
        }
    }
}
