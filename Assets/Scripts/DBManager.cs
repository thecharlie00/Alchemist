
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.Collections.Generic;

public class DBManager : MonoBehaviour
{
    #region DBConection
    IDbConnection dbConnection;
    public static DBManager _DB_MANAGER;
    #endregion
    #region Ingredients
    [System.Serializable]
    public struct _Ingredients
    {
        public int id_ingredients;
        public string ingredients;
        public float cost;
        public string icon;
        public string description;
    }
    public List<_Ingredients> ingredients = new List<_Ingredients>();
    public int ingredientsAmount;
    #endregion
    #region Potions
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
    public List<_Potion> potions = new List<_Potion>();
    public int potionAmount;
    #endregion
    #region PotionTypes
    [System.Serializable]
    public struct _PotionTypes
    {
        public int potion_type_id;
        public string type;
        public string icon_type;
    }
    public List<_PotionTypes> potionTypes = new List<_PotionTypes>();
    public int potionTypesAmount;
    #endregion
    #region PotionsIngredients
    [System.Serializable]
    public struct potions_Ingredients
    {
        public int id_potion_ingredient;
        public int quantity;
        public int id_potion;
        public int id_ingredient;
    }
    public List<potions_Ingredients> potionsIngredients = new List<potions_Ingredients>();
    #endregion
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
        PotionsIngredients();
        potionAmount = potions.Count;
        ingredientsAmount = ingredients.Count;
        potionTypesAmount = potionTypes.Count;


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
            
            string typePotion = dataReader.GetString(1);
            potionType.type = typePotion;
           
            string icon = dataReader.GetString(2);
            potionType.icon_type = icon;
          
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
           
            string _potion_ = dataReader.GetString(1);
            potion.potion = _potion_;
            
            float cost = dataReader.GetFloat(2);
            potion.cost = cost;
          
            string icon = dataReader.GetString(3);
            potion.icon = icon;
          
            string description = dataReader.GetString(4);
            potion.description = description;
           
            int idPotionTypes = dataReader.GetInt16(5);
            potion.id_potion_type = idPotionTypes;
           
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
            
            string _ingredient = dataReader.GetString(1);
            ingredient.ingredients = _ingredient;
            
            float cost = dataReader.GetFloat(2);
            ingredient.cost = cost;
           
            string icon = dataReader.GetString(3);
            ingredient.icon = icon;
           
            string description = dataReader.GetString(4);
            ingredient.description = description;
          

            ingredients.Add(ingredient);


        }
    }

    void PotionsIngredients()
    {
        
        string query = "SELECT * FROM potions_ingredients";

        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();

        while (dataReader.Read())
        {
            potions_Ingredients _potionsIngredients = new potions_Ingredients();

            int id_potion_ingredient = dataReader.GetInt16(0);
            _potionsIngredients.id_potion_ingredient = id_potion_ingredient;

            int quantity = dataReader.GetInt16(1);
            _potionsIngredients.quantity = quantity;

            int id_potion = dataReader.GetInt16(2);
            _potionsIngredients.id_potion = id_potion;

            int id_ingredient = dataReader.GetInt16(3);
            _potionsIngredients.id_ingredient = id_ingredient;


            potionsIngredients.Add(_potionsIngredients);

        }
        Debug.Log("done");
    }

}
