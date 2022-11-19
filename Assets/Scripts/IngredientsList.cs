using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsList : MonoBehaviour
{
    [SerializeField]

    private GameObject ingredients;
    

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
        for(int i = 0; i < DBManager._DB_MANAGER.ingredientsAmount; i++)
        {
            
            
        }
    }
}
