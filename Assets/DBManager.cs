
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class DBManager : MonoBehaviour
{
    IDbConnection dbConnection;
    void Start()
    {
        OpenDatabase();
        string query = "SELECT * FROM potion_types";

        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();


        while (dataReader.Read())
        {
            string typePotion = dataReader.GetString(1);
            Debug.Log(typePotion);
        }
    }


    void OpenDatabase()
    {
        string dbUri = "URI=file:alchemist.db";
        dbConnection = new SqliteConnection(dbUri);
        dbConnection.Open();
       
    }
}
