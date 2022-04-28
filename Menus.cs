using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// 导入引用
/// </summary>

namespace ComputerDB001
{
    class Menus
    {
        public void Menuss()
        {
            Console.WriteLine("-=-=-=-=-欢迎使用计算机配置管理系统-=-=-=-=-");
            Console.WriteLine("             1. 计算机信息录入");
            Console.WriteLine("             2. 计算机信息查询");
            Console.WriteLine("             0. 退出");
            Console.WriteLine("-=-=-=-=-欢迎使用计算机配置管理系统-=-=-=-=-");
            Console.Write("请选择功能选项:");
            int opt = Convert.ToInt32(Console.ReadLine());//接收选择 用switch结构进行功能实现
            switch (opt)//选择结构
            {
                case 1:
                    ComputerAdd();//添加新计算机方法
                    break;
                case 2:
                    SelectComputer();//查询计算机信息方法
                    break;
                case 0:
                    Console.WriteLine("Thank For Use!");//退出功能
                    Console.WriteLine("Bye Bye!");
                    return;
                default:
                    Console.WriteLine("请输入菜单中的选项!");//若输入其他数字,返回菜单页面并提示
                    Menuss();
                    break;
            }
        }
            /// <summary>
            /// 增加新电脑信息方法
            /// </summary>
        private void ComputerAdd()
        {
             Console.WriteLine("-=-=-=--=-=-=-=-新增计算机-=-=-=-=--=-=-=-");
                Console.WriteLine("请按照要求完成以下数据的输入:");
                Console.Write("请输入计算机编号:");
                string CPID = Console.ReadLine();//接收计算机编号输入
                Console.Write("请输入计算机品牌:");
                string CPBRD = Console.ReadLine();//接收品牌输入
                Console.Write("请输入CPU型号:");
                string CPU = Console.ReadLine();//接收CPU型号输入
                Console.Write("请输入运存大小(GB):");
                int MemoryGB = Convert.ToInt32(Console.ReadLine());//接收运存大小输入,数据类型转换int
                Console.Write("请输入存储大小(GB)");
                int SaveDisk = Convert.ToInt32(Console.ReadLine());//接收储存大小输入,数据类型转换int
                Console.Write("请输入显卡型号:");
                string VCARD = Console.ReadLine();//接收显卡型号输入
                Console.Write("请输入要使用此电脑的员工编号:");
                string EperId = Console.ReadLine();//接收员工编号输入
                                                   //首先判断要添加的电脑编号是否已经存在
                string CheckCPID = string.Format("SELECT ComputerID FROM ComputerInfo WHERE ComputerID='{0}'", CPID);
                int checkreturn = Convert.ToInt32(DBHelper.ExecuteScalar(CheckCPID));
                if (checkreturn == 0)//电脑编号不存在,可以新增
                {
                    string AddCpSql = string.Format(@"INSERT INTO ComputerInfo(ComputerID, Brand, CPU, Memory, HandDisk, Videocard, Employee)
                                            VALUES('{0}', '{1}', '{2}', {3}, {4}, '{5}', '{6}')", CPID, CPBRD, CPU, MemoryGB, SaveDisk, VCARD, EperId);
                    //接收以上数据并组合为SQL语句
                    bool res = DBHelper.ExecuteNonQuery(AddCpSql);
                    if (res)
                    {
                        Console.WriteLine("电脑编号{0},输入成功!", CPID);
                    }
                    else
                    {
                        Console.WriteLine("出了点小问题.....");
                    }
                }
                else
                {
                    Console.WriteLine("已经存在相同的编号了,请重新输入");
                    ComputerAdd();
                }
        }
        /// <summary>
        /// 查询电脑信息方法
        /// </summary>
        public void SelectComputer()
        {
            Console.WriteLine("请输入查询的计算机编号,如果要全部查询请敲击回车:");
            string SHCPID = Console.ReadLine();
          
                //string SelectSql = string.Format(@"SELECT * FROM ComputerInfo WHERE ComputerID like'%{0}%'", SHCPID);//ComputerID LIKE'%100%'
                //SqlDataReader SelectAll = DBHelper.ExecuteReader(SelectSql);//通过数据库连接工具使用查询方法
                //while (SelectAll != null && SelectAll.HasRows && SelectAll.Read())//循环读取
                //{
                //    Console.WriteLine(" * **********************************************************************************");
                //    Console.WriteLine("编号\t品牌\tCPU\t内寸大小\t硬盘大小\t显卡\t使用员工");                                
                //    Console.WriteLine("***********************************************************************************");
                //    string BH = SelectAll["ComputerID"].ToString();
                //    string PP= SelectAll["Brand"].ToString();
                //    string CPUU = SelectAll["CPU"].ToString();
                //    string NC = SelectAll["Memory"].ToString();
                //    string YP = SelectAll["HandDisk"].ToString();
                //    string XK = SelectAll["Videocard"].ToString();
                //    string YGID = SelectAll["Employee"].ToString();
                //    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",BH,PP,CPUU,NC,YP,XK,YGID);
                //    Console.WriteLine("***********************************************************************************");
                //}

                string SqlMHSelect = string.Format(@"SELECT COUNT(0) FROM ComputerInfo WHERE ComputerID LIKE '%{0}%'", SHCPID);
                int intres = Convert.ToInt32(DBHelper.ExecuteScalar(SqlMHSelect));
            if (intres > 0)//可以查找到数据
                {

                Console.WriteLine("***********************************************************************************");
                Console.WriteLine("编号\t品牌\tCPU\t内寸大小\t硬盘大小\t显卡\t使用员工");
                Console.WriteLine("***********************************************************************************");
                string SelectSqlS = string.Format(@"SELECT * FROM ComputerInfo WHERE ComputerID LIKE '%{0}%'",SHCPID);
                SqlDataReader SelectAllMH = DBHelper.ExecuteReader(SelectSqlS);//通过数据库连接工具使用查询方法
              
                while (SelectAllMH != null && SelectAllMH.HasRows && SelectAllMH.Read())//循环读取
                    {
                        string BHMH = SelectAllMH["ComputerID"].ToString();
                        string PPMH = SelectAllMH["Brand"].ToString();
                        string CPUUMH = SelectAllMH["CPU"].ToString();
                        string NCMH = SelectAllMH["Memory"].ToString();
                        string YPMH = SelectAllMH["HandDisk"].ToString();
                        string XKMH = SelectAllMH["Videocard"].ToString();
                        string YGIDMH = SelectAllMH["Employee"].ToString();
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", BHMH, PPMH, CPUUMH, NCMH, YPMH, XKMH, YGIDMH);
                    }
                }
                else
                {
                    Console.WriteLine("未查找到数据,请核对后重试!");
                    SelectComputer();
                }
            
            
        }
    }
}

