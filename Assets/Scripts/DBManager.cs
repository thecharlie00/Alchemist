
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.Collections.Generic;

public class DBManager : MonoBehaviour
{
    IDbConnection dbConnection;
    public static DBManager _DB_MANAGER;

    [System.Serializable]
    public struct _PotionTypes
    {
        public int potion_type_id;
        public string type;
        public string icon_type;
    }
    [System.Serializable]
    public struct _Ingredients
    {
        public int id_ingredients;
        public string ingredients;
        public float cost;
        public string icon;
        public string description;
    }
    [System.Serializable]
    public struct _Potion
    {
        public int id_potion;
        public string potion;
        public float cost;
        public string icon;
        public string description;
        public int id_potion_type;
    }

    public List<_Ingredients> ingredients = new List<_Ingredients>();
    public List<_PotionTypes> potionTypes = new List<_PotionTypes>();
    public List<_Potion> potions = new List<_Potion>();

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
        Ingredients();
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
            _PotionTypes potionType = new _PotionTypes();
            int potionTypeId = dataReader.GetInt16(0);
            potionType.potion_type_id = potionTypeId;
            Debug.Log(potionTypeId);
            string typePotion = dataReader.GetString(1);
            potionType.type = typePotion;
            Debug.Log(typePotion);
            string icon = dataReader.GetString(2);
            potionType.icon_type = icon;
            Debug.Log(icon);
            potionTypes.Add(potionType);

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
            _Potion potion = new _Potion();
            int idPotion = dataReader.GetInt16(0);
            potion.id_potion = idPotion;
            Debug.Log(idPotion);
            string _potion_ = dataReader.GetString(1);
            potion.potion = _potion_;
            Debug.Log(_potion_);
            float cost = dataReader.GetFloat(2);
            potion.cost = cost;
            Debug.Log(cost);
            string icon = dataReader.GetString(3);
            potion.icon = icon;
            Debug.Log(icon);
            string description = dataReader.GetString(4);
            potion.description = description;
            Debug.Log(description);
            int idPotionTypes = dataReader.GetInt16(5);
            potion.id_potion_type = idPotionTypes;
            Debug.Log(idPotionTypes);
            potions.Add(potion);
            

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
            _Ingredients ingredient = new _Ingredients();

            int id_ingredient = dataReader.GetInt16(0);
            ingredient.id_ingredients = id_ingredient;
            Debug.Log(dataReader.GetInt16(0));
            string _ingredient = dataReader.GetString(1);
            ingredient.ingredients = _ingredient;
            Debug.Log(dataReader.GetString(1));
            float cost = dataReader.GetFloat(2);
            ingredient.cost = cost;
            Debug.Log(dataReader.GetFloat(2));
            string icon = dataReader.GetString(3);
            ingredient.icon = icon;
            Debug.Log(dataReader.GetString(3));
            string description = dataReader.GetString(4);
            ingredient.description = description;
            Debug.Log(dataReader.GetString(4));

            ingredients.Add(ingredient);


        }
    }

}
