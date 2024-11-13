using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstallDB
{
    [RunInstaller(true)]
    public partial class InstallDBase : System.Configuration.Install.Installer
    {
        public InstallDBase()
        {
            InitializeComponent();
        }

        //创建数据库  
        private void CreateDataBase(string strSql, string DataName, string strMdf, string strLdf, string path)
        {
            SqlConnection myConn = new SqlConnection(strSql);
            String str = null;
            try
            {
                str = @" EXEC sp_attach_db @dbname='" + DataName + "',@filename1='" + strMdf + "',@filename2='" + strLdf + "'";
                SqlCommand myCommand = new SqlCommand(str, myConn);
                myConn.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("数据库安装成功！点击确定继续");//需Using System.Windows.Forms  
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库安装失败！" + e.Message + "\n\n" + "您可以手动附加数据");
                System.Diagnostics.Process.Start(path);//打开安装目录  
            }
            finally
            {
                myConn.Close();
            }
        }

        private void CreateDataBaseNew(string strSql, string DataName,string path)
        {
            System.Diagnostics.Process sqlProcess = new System.Diagnostics.Process();
            sqlProcess.StartInfo.FileName = "osql.exe";
            sqlProcess.StartInfo.Arguments = @" -U lyc -P 123456 -d master -s . -i " +path;
            sqlProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            sqlProcess.Start();
            sqlProcess.WaitForExit();
            sqlProcess.Close();

        }

        //权限管理  
        private static void SetFullControl(string path)
        {
            FileInfo info = new FileInfo(path);
            FileSecurity fs = info.GetAccessControl();
            fs.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            info.SetAccessControl(fs);
        }

        public override void Install(IDictionary stateSaver)
        {
            string server = this.Context.Parameters["server"];//服务器名称  
            string uid = this.Context.Parameters["userid"];//SQlServer用户名  
            string pwd = this.Context.Parameters["password"];//密码  
            string path = this.Context.Parameters["targetdir"];//安装目录  
            string dbName = this.Context.Parameters["dbName"];
            string ch = path.Substring(path.Length - 1, 1);
            if (ch == @"\")   //对路径进行处理，判断末尾是否有'\'  
                path = path.Substring(0, path.Length - 1);//有则删掉  

            string strSql = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=master";//连接数据库字符串  
            string DataName = dbName;//数据库名  
            //string strMdf = @"d:\" + @"PSIDBase.mdf";//MDF文件路径，这里需注意文件名要与刚添加的数据库文件名一样！  
            //string strLdf = @"d:\"+ @"PSIDBase_log.ldf";//LDF文件路径  
            //SetFullControl(strMdf);
            //SetFullControl(strLdf);
            string sqlPath = path + @"\DBase\PSIDbaseSql.sql";
            SetFullControl(sqlPath);
            base.Install(stateSaver);
            this.CreateDataBaseNew(strSql, DataName,sqlPath);//开始创建数据库  
          // this.CreateDataBase(strSql, DataName, strMdf, strLdf, path);
        }
    }
}
