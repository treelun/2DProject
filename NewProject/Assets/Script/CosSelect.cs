using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class CosSelect : MonoBehaviour
{
    GameObject FoodTable;
    public bool isCompleteBtn = false;

    public List<GameObject> Costomer;
    private void Start()
    {
        FoodTable = GameObject.Find("FoodTable");
    }
    // Update is called once per frame
    void Update()
    {
        
        if (FoodTable.GetComponent<TradeCon>().isSell == true)
        {
            isCompleteBtn = true;
            CallCostomer();
            FoodTable.GetComponent<TradeCon>().isSell = false;
        }

    }

    void CallCostomer()
    {
        if (isCompleteBtn == true)
        {
            int rannum = Random.Range(0, 4);
            gameObject.GetComponent<SpriteRenderer>().sprite = Costomer[rannum].GetComponent<SpriteRenderer>().sprite;
            isCompleteBtn = false;
        }
       
    }
}
