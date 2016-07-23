using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_Server
{
    class Login
    {
        public enum LoginResult
        {
            LOGIN_SUCCEED,
            LOGINDATA_ERR,
            SERVER_ERR,
            INPUTDATA_ERR
        }
        private const int LOGIN_SUCCEED = 0;
        private const int LOGINDATA_ERR = 1;
        private const int SERVER_ERR = 2;
        private const int INPUTDATA_ERR = 3;

        public static LoginResult tryLogin(string id, string pw)
        {
            string encpw = Encoding.UTF8.GetString(System.Convert.FromBase64String("and0MzE0MTU5Mg"));
            string strConn = "Server=localhost;Database=sprint;Uid=xeno;Pwd=" + encpw;
            MySqlConnection conn = new MySqlConnection(strConn);
            DataSet ds = new DataSet();
            conn.Open();

            string sql = "select * from userdata where userid=\"" + id + "\"";
            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            adpt.Fill(ds);
            if(ds.Tables[0].Rows[0]["passwd"].ToString() == encryptMD5(pw))
                    return LoginResult.LOGIN_SUCCEED;
            return LoginResult.LOGINDATA_ERR;
        }

        private static string encryptMD5(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.UTF8.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
