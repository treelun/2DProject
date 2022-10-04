using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public GameObject prefabFruit;
    public GameObject Box;
    public List<GameObject> Fruit;

    
    
    int fruitMaxStack = 10;//나중에 플레이어가 구입하는 횟수로 변경

    private void Awake()
    {
        if (Fruit == null)
        {
            Fruit = new List<GameObject>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        MakeFruit();

    }

    void MakeFruit()
    {
        if (Fruit.Count != fruitMaxStack)
        {
            for (int i = 0; i < fruitMaxStack; i++)
            {
                GameObject fruitObject = Instantiate(prefabFruit);
                Fruit.Add(fruitObject);
                fruitObject.transform.position = Box.transform.position;
            }
        }
    }
}
