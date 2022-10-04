using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class checkfruit : MonoBehaviour
{
    public int wantFruitNum;
    public int wantFruitNum1;
    public int wantFruitNum2;

    GameObject Text;
    public List<string> fruitName;
    bool isGetwantfruit = false;
    // Start is called before the first frame update
    private void Awake()
    {
        fruitName = new List<string>();
        fruitName.Add("Apple");
        fruitName.Add("Avocado");
        fruitName.Add("Cheese");
        fruitName.Add("Cherry");
        fruitName.Add("Lemon");
        fruitName.Add("MelonWater");
        fruitName.Add("Peach");
        fruitName.Add("Strawberry");
        fruitName.Add("Tomato");
    }
    void Start()
    {
        Text = GameObject.Find("Text");
        
    }

    // Update is called once per frame
    void Update()
    {


        //테스트용
        if (isGetwantfruit == false)
        {
            StartCoroutine(namemaker());
            Text.GetComponent<TMP_Text>().text = fruitName[wantFruitNum] + "," + fruitName[wantFruitNum1] + "," + fruitName[wantFruitNum2] + " Please";
            isGetwantfruit = true;
        }
        else
        {
            StopCoroutine(namemaker());
        }
    }
    
    IEnumerator namemaker()//테스트용
    {

        wantFruitNum = Random.Range(0, 9);
        wantFruitNum1 = Random.Range(0, 9);
        wantFruitNum2 = Random.Range(0, 9);
        if (wantFruitNum == wantFruitNum1)
        {
            wantFruitNum1 = Random.Range(0, 9);
        }
        else if (wantFruitNum1 == wantFruitNum2)
        {
            wantFruitNum2 = Random.Range(0, 9);
        }
        else if (wantFruitNum == wantFruitNum2)
        {
            wantFruitNum2 = Random.Range(0, 9);
        }
        else
        {
            yield return null;
        }
        yield return new WaitForSecondsRealtime(5f);
    }
   


}
