using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    private string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    private string _department;

    public string Department
    {
        get { return _department; }
        set { _department = value; }
    }
    private string _tel;

    public string Tel
    {
        get { return _tel; }
        set { _tel = value; }
    }
    private string _cel;

    public string Cel
    {
        get { return _cel; }
        set { _cel = value; }
    }
    private string _email;

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    public User List(string login)
    {
        ///Metodo para Listar todos no banco
        ///
        string sql;
        sql = "";
        sql += "SELECT ";
        sql += "  DISPLAY_NAME, DEPARTMENT,  PHONE_MOBILE,  OTHER_MOBILE,  EMAIL ";
        sql += "FROM DOMAIN_USERS_PIVOT ";
        sql += "WHERE UPPER(USER_ID) = UPPER(TRIM('" + login + "')) ";


        OleDbConnection con = new OleDbConnection(Process.StringDeConexao);
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.CommandType = CommandType.Text;
        User user = new User();
        using (con)
        {
            con.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                user.Name = Convert.ToString(reader["DISPLAY_NAME"]);
                user.Department = Convert.ToString(reader["DEPARTMENT"]);
                user.Tel =Convert.ToString(reader["PHONE_MOBILE"]);
                user.Cel = Convert.ToString(reader["OTHER_MOBILE"]);
                user.Email = Convert.ToString(reader["EMAIL"]);
            }           
            con.Close();
            return user;
        }
    }
    public void Update(string login, string name, string departament, string tel, string cel)
    {
        ///Metodo para Listar todos no banco
        ///
        string sql;
        sql = "";
        sql += "UPDATE DOMAIN_USERS_PIVOT SET ";
        sql += " DISPLAY_NAME = ?, ";
        sql += " DEPARTMENT = ?, ";
        sql += " PHONE_MOBILE = ?, ";
        sql += " OTHER_MOBILE = ? ";
        sql += "WHERE UPPER(USER_ID) = UPPER(TRIM('" + login + "')) ";
        OleDbConnection con = new OleDbConnection(Process.StringDeConexao);
        try
        {
            OleDbCommand comando = new OleDbCommand(sql, con);
            comando.Parameters.Add("@DISPLAY_NAME", OleDbType.VarChar).Value = name;
            comando.Parameters.Add("@DEPARTMENT", OleDbType.VarChar).Value = departament;
            comando.Parameters.Add("@PHONE_MOBILE", OleDbType.VarChar).Value = tel;
            comando.Parameters.Add("@OTHER_MOBILE", OleDbType.VarChar).Value = cel;
            con.Open();
            int count = comando.ExecuteNonQuery();
            con.Close();
        }
        catch { }
    }
}