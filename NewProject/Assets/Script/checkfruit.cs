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
    GameObject FoodTable;
    public List<string> fruitName;
    bool isGetwantfruit = false;
    bool isStopGet = false;
    Coroutine coroutine;
    // Start is called before the first frame update
    private void Awake()
    {
        fruitName = new List<string>();
        fruitName.Add("���");
        fruitName.Add("�ƺ�ī��");
        fruitName.Add("ġ��");
        fruitName.Add("ü��");
        fruitName.Add("����");
        fruitName.Add("����");
        fruitName.Add("������");
        fruitName.Add("����");
        fruitName.Add("�丶��");
    }
    void Start()
    {
        Text = GameObject.Find("Text");
        FoodTable = GameObject.Find("FoodTable");
        

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("checkfruit sellcount" + FoodTable.GetComponent<TradeCon>().sellcount);
        if (FoodTable.GetComponent<TradeCon>().isSell == true)
        {
            isGetwantfruit = false;
            Debug.Log("1" + isGetwantfruit);
        }

        //�׽�Ʈ��
        if (isGetwantfruit == false)
        {
            Debug.Log("2" + isGetwantfruit);
            StartCoroutine(namemaker());
            Text.GetComponent<TMP_Text>().text = fruitName[wantFruitNum] + "," + fruitName[wantFruitNum1] + "," + fruitName[wantFruitNum2] + " �ּ���";
            isStopGet = true;
                
            
            if (isStopGet == true)
            {
                StopCoroutine(namemaker());
                isGetwantfruit = true;
                Debug.Log("3" + isGetwantfruit);
            }

            
        }
       
    }

    IEnumerator namemaker()//�׽�Ʈ��
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
        yield return null;
    }
   


}
