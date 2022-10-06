using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class CosSelect : MonoBehaviour
{
    GameObject FoodTable;
    public bool isCompleteBtn = false;

    //에디터창에서 리스트를 만들어 고객의 이미지가 되는 프리펩을 넣음
    public List<GameObject> Costomer;
    private void Start()
    {
        FoodTable = GameObject.Find("FoodTable");
    }
    // Update is called once per frame
    void Update()
    {
        //손님의 모습을 바꿔주기위한 스크립트
        //과일3종류만 팔것이기에 isSell은 판매 카운트가 3번이 되면 true를 반환하게 되어있음
        if (FoodTable.GetComponent<TradeCon>().isSell == true)
        {
            //메서드가 계속 돌지않기위한 bool값
            isCompleteBtn = true;
            //메서드 실행
            CallCostomer();
            FoodTable.GetComponent<TradeCon>().isSell = false;
        }

    }

    void CallCostomer()
    {
        //isCompleteBtn이 true가 되면
        if (isCompleteBtn == true)
        {
            //고객의 종류는 4종류이기에 0~3까지의 숫자를 랜덤으로 받음
            int rannum = Random.Range(0, 4);
            //SpriteRenderer가 결국 화면에 보이는 이미지임, 에디터 인스펙터창에서 만든 리스트에서 랜덤한 녀석의 sprite를 가져옴
            gameObject.GetComponent<SpriteRenderer>().sprite = Costomer[rannum].GetComponent<SpriteRenderer>().sprite;
            //1번만 실행할수있도록 false로 반환
            isCompleteBtn = false;
        }
       
    }
}
