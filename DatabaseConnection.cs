using System;
using System.Windows;
using System.Windows.Input;
using System.Data.SqlClient;

public class DatabaseConnection
{
    //Connection string gebruikt door het gehele programma.
    private string Connectionstring = "Data Source=LAPTOP-JGAVQDES\\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True";

    public DatabaseConnection()
	{

	}

    //Login connectie & Queries
    public void LoginAuthentication()
    {
        connection = new SqlConnection(Connectionstring);
    }
}
