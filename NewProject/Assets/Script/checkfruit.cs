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
        //����Ʈ�� tag�� ���� �ܾ���� �����
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
        //���ο� ���ϴ� ������ ������� Tradecon�� �ִ� isSell�� Ʈ�簡 �Ǹ�
        if (FoodTable.GetComponent<TradeCon>().isSell == true)
        {
            //false�� ��ȯ
            isGetwantfruit = false;
            
        }
        //isGetwantfruit�� false��
        if (isGetwantfruit == false)
        {
            //namemaker�ڷ�ƾ ����
            StartCoroutine(namemaker());
            Text.GetComponent<TMP_Text>().text = fruitName[wantFruitNum] + "," + fruitName[wantFruitNum1] + "," + fruitName[wantFruitNum2] + " �ּ���";
            //������� ��� ���߱����� isStopGet�� true�� ��ȯ
            isStopGet = true;
                
            
            if (isStopGet == true)
            {
                //�ڷ�ƾ����
                StopCoroutine(namemaker());
                //startcoroutine�� ���߱����� isGetwantfruit�� true�� ��ȯ
                isGetwantfruit = true;
            }

            
        }
       
    }

    IEnumerator namemaker()
    {
        //9������ ������ ����ϱ⿡ ������ ���� 0~8������ ����
        wantFruitNum = Random.Range(0, 9);
        wantFruitNum1 = Random.Range(0, 9);
        wantFruitNum2 = Random.Range(0, 9);
        //���� ����(���� ��������)�� �������ʵ��� ���ǹ��� �־����� ���� ������ ���ö�������...;
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

        yield return null;
    }
   


}
