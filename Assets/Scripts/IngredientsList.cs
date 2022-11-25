using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientsList : MonoBehaviour
{
    [SerializeField]

    private GameObject ingredients;
    public Text name;
    public Text description;
    public Text cost;


    private void Awake()
    {
        
    }
    void Start()
    {
        GenerateIngredients();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void GenerateIngredients()
    {
        for(int i = 0; i < DBManager._DB_MANAGER.ingredientsAmount-1; i++)
        {

            Instantiate(ingredients, this.transform);
            name = ingredients.transform.GetChild(0).GetComponent<Text>();
            description = ingredients.transform.GetChild(1).GetComponent<Text>();
            cost = ingredients.transform.GetChild(2).GetComponent<Text>();

            name.text = DBManager._DB_MANAGER.ingredients[i].ingredients;
            description.text = DBManager._DB_MANAGER.ingredients[i].description;
            cost.text = DBManager._DB_MANAGER.ingredients[i].cost.ToString();
            Debug.Log(name);
        }
    }
}
