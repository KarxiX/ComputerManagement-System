using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ComputerDB001
{
    class DBHelper
    {
        /// <summary>
        ///连接字符串 
        /// </summary>
        private static string constr = @"server=.;database=ComputerDB001;user=sa;pwd=114514";

        /// <summary>
        /// 查询单个值
        /// </summary>
        /// <param name="sql">sql命令</param>
        /// <returns><returns>
        public static object ExecuteScalar(string sql)
        {
            /// <summary>
            ///创建链接对象
            /// </summary>
            SqlConnection con = new SqlConnection(constr);
            SqlCommand sqlCommand = new SqlCommand(sql, con);///创建命令对象
            try///存放可能错误的程序
            {
                con.Open();///打开数据库链接
                return sqlCommand.ExecuteScalar();///单查询方法
            }
            catch (Exception ex)///接收异常
            {
                Console.WriteLine("查询失败 错误发生在:{0}", ex.Message);
            }
            finally///最终代码块 关闭数据库链接
            {
                con.Close();
            }
            return null;
        }
        /// <summary>
        /// 增 删 改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>true:成功 false:失败</returns>
        public static bool ExecuteNonQuery(string sql)
        {
            SqlConnection con = new SqlConnection(constr);///连接对象
            SqlCommand sqlCommand = new SqlCommand(sql, con);///命令对象
            try
            {
                con.Open();///打开数据库连接
                return sqlCommand.ExecuteNonQuery() > 0;///ExecuteNonQuery 指令 返回值
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询失败 错误发生在:{0}", ex.Message);
                ///错误信息
            }
            finally
            {
                con.Close();///关闭连接
            }
            return false;
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql)
        {
            SqlConnection con = new SqlConnection(constr);///连接对象
            SqlCommand sqlCommand = new SqlCommand(sql, con);///命令对象
            try
            {
                con.Open();///打开数据库连接
                return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);///关闭数据库连接
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询失败 错误发生在:{0}", ex.Message);///错误信息
            }
            return null;///查询失败返回空值
        }
    }
}
