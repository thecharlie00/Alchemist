
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class DBManager : MonoBehaviour
{
    IDbConnection dbConnection;
    public static DBManager _DB_MANAGER;
    private List<Ingredient> ingredients = new List<Ingredient>();
    private void Awake()
    {
        if (_DB_MANAGER != null && _DB_MANAGER != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _DB_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }
    void Start()
    {
        OpenDatabase();
        PotionTypes();
        Potion();
    }


    void OpenDatabase()
    {
        string dbUri = "URI=file:alchemist.db";
        dbConnection = new SqliteConnection(dbUri);
        dbConnection.Open();
       
    }

    void PotionTypes()
    {
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

    void Potion()
    {
        string query = "SELECT * FROM potions";

        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();


        while (dataReader.Read())
        {
            string potion = dataReader.GetString(1);
            Debug.Log(potion);
        }
    }

    void Ingredients()
    {
        string query = "SELECT * FROM ingredients";

        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();


        while (dataReader.Read())
        {
            string potion = dataReader.GetString(1);
            Debug.Log(potion);
        }
    }

}
