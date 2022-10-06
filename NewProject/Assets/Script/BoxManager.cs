using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    //과일을 담는 박스 생성

    //에디터 인스펙터 창에서 오브젝트들을 넣어 생성해줌
    public GameObject prefabFruit;
    public GameObject Box;
    public List<GameObject> Fruit;

    
    //과일의 최대갯수
    int fruitMaxStack = 10;

    private void Awake()
    {
        //리스트가 비어있으면 리스트 생성
        if (Fruit == null)
        {
            Fruit = new List<GameObject>();
        }
    }
    void Update()
    {
        
        MakeFruit();

    }

    void MakeFruit()
    {
        //리스트의 크기가 과일의 최대갯수와 같지않다면
        if (Fruit.Count != fruitMaxStack)
        {
            for (int i = 0; i < fruitMaxStack; i++)
            {
                //리스트에 프리펩들을 넣어줌

                GameObject fruitObject = Instantiate(prefabFruit);
                
                Fruit.Add(fruitObject);
                //과일들이 생성되는 위치는 박스의 위치임
                fruitObject.transform.position = Box.transform.position;
                
            }
        }
    }
}
