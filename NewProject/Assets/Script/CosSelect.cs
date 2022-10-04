using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class CosSelect : MonoBehaviour
{
    public bool isCompleteBtn = false;

    public List<GameObject> Costomer;
    private void Awake()
    {

        
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CallCostomer();


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
