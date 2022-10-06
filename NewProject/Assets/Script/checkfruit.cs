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
        //리스트에 tag를 비교할 단어들을 담아줌
        fruitName = new List<string>();
        fruitName.Add("사과");
        fruitName.Add("아보카도");
        fruitName.Add("치즈");
        fruitName.Add("체리");
        fruitName.Add("레몬");
        fruitName.Add("수박");
        fruitName.Add("복숭아");
        fruitName.Add("딸기");
        fruitName.Add("토마토");
    }
    void Start()
    {
        Text = GameObject.Find("Text");
        FoodTable = GameObject.Find("FoodTable");
        

    }

    // Update is called once per frame
    void Update()
    {
        //새로운 원하는 과일을 얻기위해 Tradecon에 있는 isSell이 트루가 되면
        if (FoodTable.GetComponent<TradeCon>().isSell == true)
        {
            //false를 반환
            isGetwantfruit = false;
            
        }
        //isGetwantfruit가 false면
        if (isGetwantfruit == false)
        {
            //namemaker코루틴 실행
            StartCoroutine(namemaker());
            Text.GetComponent<TMP_Text>().text = fruitName[wantFruitNum] + "," + fruitName[wantFruitNum1] + "," + fruitName[wantFruitNum2] + " 주세요";
            //결과값을 얻고 멈추기위해 isStopGet을 true로 반환
            isStopGet = true;
                
            
            if (isStopGet == true)
            {
                //코루틴멈춤
                StopCoroutine(namemaker());
                //startcoroutine을 멈추기위해 isGetwantfruit를 true로 반환
                isGetwantfruit = true;
            }

            
        }
       
    }

    IEnumerator namemaker()
    {
        //9가지의 과일을 사용하기에 랜덤한 숫자 0~8까지를 받음
        wantFruitNum = Random.Range(0, 9);
        wantFruitNum1 = Random.Range(0, 9);
        wantFruitNum2 = Random.Range(0, 9);
        //같은 숫자(같은 과일종류)가 나오지않도록 조건문을 넣었으나 같은 종류가 나올때가있음...;
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
