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
    int index = -1;
    public bool isInstantiated;
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

        for(int i = 0; i < DBManager._DB_MANAGER.ingredients.Count; i++)
        {
            Instantiate(ingredients, this.transform);
            
            
            name.text = DBManager._DB_MANAGER.ingredients[i].ingredients;
            description.text = DBManager._DB_MANAGER.ingredients[i].description;
            cost.text = DBManager._DB_MANAGER.ingredients[i].cost.ToString();
            name = ingredients.transform.GetChild(0).GetComponent<Text>();
            description = ingredients.transform.GetChild(1).GetComponent<Text>();
            cost = ingredients.transform.GetChild(2).GetComponent<Text>();

        }




    }
}
