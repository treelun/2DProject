using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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



    Animator animator;
    private void Start()
    {
        Money = GameObject.Find("Money");
        button = GameObject.Find("Button");
        checkfruit = GameObject.Find("Box");
        animator = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        //과일을 놓는위치 즉 과일을 판매하는 기능을 가지고 있는 스크립트

        //현재 씬이 StartGame이면
        if (SceneManager.GetActiveScene().name == "StartGame")
        {
            //점수창 텍스트 표시
            Money.GetComponent<TextMeshProUGUI>().text = "Money : " + price;
        }
        //현재 씬이 Clear씬이면
        else if (SceneManager.GetActiveScene().name == "Clear")
        {
            //점수창 텍스트 표시
            Money.GetComponent<TextMeshProUGUI>().text = "최종 점수 : " + price;
        }
        //타이틀로 돌아가는 버튼을 누르면
        if (button.GetComponent<BtnCon>().istitle == true)
        {
            //점수 초기화
            price = 0;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //박스에 triggerEnter되는 애들이 고객이 원하는 애들인지 알아야 하기에 값을 받아옴
        //그치만 문제가있음, 중복으로 판매가됨, 사과,레몬,복숭아 라면 1개씩만 판매하고 싶었는데
        //사과,사과,사과 를 팔아도 판매가되고 원하는 과일목록이 새로고침됨
        //그래서 정신승리를 하기로했음, 어차피 고득점을 목표로 하는 게임이고
        //과일마다 점수가 다 다르니 높은거만 골라서 팔아도 되게끔
        //아무튼 그래서 원하는 애들의 tag값이면?
        num = checkfruit.GetComponent<checkfruit>().wantFruitNum;
        num1 = checkfruit.GetComponent<checkfruit>().wantFruitNum1;
        num2 = checkfruit.GetComponent<checkfruit>().wantFruitNum2;
        if (collision.transform.tag == checkfruit.GetComponent<checkfruit>().fruitName[num]
            || collision.transform.tag == checkfruit.GetComponent<checkfruit>().fruitName[num1]
            || collision.transform.tag == checkfruit.GetComponent<checkfruit>().fruitName[num2])
        {
            //price에 trigger로 들어온 오브젝트의 price값을 더해주면서
            price += collision.gameObject.GetComponent<FruitManager>().price;
            //오브젝트를 파괴함
            //이번에 알았는데 씬이 바뀌면 그냥 값이 다시 초기화가 됨
            //오브젝트를 10개만 생성했으니 파괴하면 점점 줄어서 판매할 과일이 없어져야 하는것이 정상이겠으나
            //구현한 게임은 씬전환을 통해 휴식시간을 가지게됨
            //그러고 다시 본게임으로 돌아왔을때 파괴된 애들이 다시 생성되어있음 씬과 씬은 별개임
            //그래서 변수를 선언했을때 public으로해도 초기화되던것이 그문제였음
            //그것을 해결하기위해선 static같은걸 사용해야함 그런데 static을 사용하면 public을 사용못해서 다른 클래스에서
            //사용을못함, 결국 내가 고정적으로 증가시키고 싶은 값이있다면 한 스크립트에서 해야된다는 단점이있음
            
            Destroy(collision.gameObject);
            //sellcount를 올려줌 왜냐면 우리는 3개의 원하는 과일손님이 있었고 3개만 팔것이기에
            sellcount++;
            Debug.Log(sellcount);

            //판매가 되었다는 애니메이션 실행
            animator.SetTrigger("isdrop");
            //3개를 팔았어?
            if (sellcount == 3)
            {
                //isSell true로 반환해줘
                isSell = true;
                //true받았어?
                if (isSell == true)
                {
                    //sellcount를 0으로 반환해줘
                    sellcount = 0;
                }

            }
            //여기도 하고싶은말이 많다. 3개를 팔았을때 원하는 과일이 바뀌어야하는데 너무빨리 sellcount가 0으로 바뀌어 실행이 안되는
            //문제가 있었다. 그래서 꺽고 꺽고 또꺽어서 해결했다..
        }

        else
        {
            price -= collision.gameObject.GetComponent<FruitManager>().price;
        }


    }


}
