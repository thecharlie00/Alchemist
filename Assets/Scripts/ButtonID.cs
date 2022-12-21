using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonID : MonoBehaviour
{
    public static int id;
    public int myID;
    public bool isPressed;

    void Awake()
    {
      
            
            //myID = id++;
        
    }
    private void Update()
    {
        
    }

    public void ingredient()
    {
        for (int i = 0; i < DBManager._DB_MANAGER.ingredients.Count; i++)
        {
            if (DBManager._DB_MANAGER.ingredients[i].id_ingredients == this.myID)
            {
                Debug.Log(DBManager._DB_MANAGER.ingredients[i].id_ingredients);
            }
        }
    }
}
