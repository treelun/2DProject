using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TradeCon : MonoBehaviour
{
    GameObject Money;
    GameObject button;
    GameObject checkfruit;
    static int price;

    int num;
    int num1;
    int num2;
    public bool isSell = false;
    public int sellcount;
    private void Start()
    {
        Money = GameObject.Find("Money");
        button = GameObject.Find("Button");
        checkfruit = GameObject.Find("Box");
    }
    private void Update()
    {
        Money.GetComponent<TextMeshProUGUI>().text = "Money : " + price;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        num = checkfruit.GetComponent<checkfruit>().wantFruitNum;
        num1 = checkfruit.GetComponent<checkfruit>().wantFruitNum1;
        num2 = checkfruit.GetComponent<checkfruit>().wantFruitNum2;
        if (collision.transform.tag == checkfruit.GetComponent<checkfruit>().fruitName[num]
            || collision.transform.tag == checkfruit.GetComponent<checkfruit>().fruitName[num1]
            || collision.transform.tag == checkfruit.GetComponent<checkfruit>().fruitName[num2])
        {
            price += collision.gameObject.GetComponent<FruitManager>().price;
            Destroy(collision.gameObject);
            sellcount++;
            Debug.Log(sellcount);
            if (sellcount == 3)
            {
                isSell = true;
                if (isSell == true)
                {
                    sellcount = 0;
                }
                
            }
        }
        else
        {
            price -= collision.gameObject.GetComponent<FruitManager>().price;

        }


    }
    

}
