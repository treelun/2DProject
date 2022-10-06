using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragAndDrop : MonoBehaviour
{
    public Vector3 LoadedPos;

    float startPosx;
    float startPosY;
    bool isBeingheld = false;

    public bool isPoint = false;
    float DroptablePosY;
    float DroptablePosX;

    GameObject checkfruit;
    

    int num;
    int num1;
    int num2;
    // Start is called before the first frame update
    void Start()
    {
        //드롭할 위치가 틀리면 처음 제자리로 돌아감
        LoadedPos = this.transform.position;
        checkfruit = GameObject.Find("Box");
        
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 왼쪽 버튼을 누르면 실행
        if (isBeingheld)
        {
            Vector2 mousePos;
            //Vector2로 카메라 화면의 마우스위치를 월드 포인트로 가져옴
            //ScreenToWorldPoint는 카메라(Camera)가 비추고 있는 화면(Screen)내의 좌표값을 사용할 수 있게 해준다.

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //오브젝트의 포지션값은 마우스위치의 x,y값에 처음 마우스를 눌렀을때의 마우스 위치와 오브젝트의 위치를 뺀값을
            //뺀값이 된다.
            //이 스크립트를 보기엔 마우스위치에 그 오브젝트를 붙여줌으로서 이동하는거 처럼 보이게할뿐
            this.gameObject.transform.position = new Vector2(mousePos.x - startPosx, mousePos.y - startPosY);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //여기에서 startPosx를 구해준다. 마우스의 현재위치값에 스크립트를 가지고있는 오브젝트의 position.x값을 빼준 값이다.
            
            startPosx = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

            isBeingheld = true;
        }
    }

    private void OnMouseUp()
    {
        //마우스를 떼면 isBeingheld가 false가되어 update문이 멈춤
        isBeingheld = false;

        //isPoint는 내가 드롭할 위치가 맞는지 확인하기위한 bool형
        if (isPoint)
        {
            //드롭할 위치가 맞다면 오브젝트의 포지션은 놓을 위치의 y값을 기준으로 설정
            this.gameObject.transform.position = new Vector3(DroptablePosX, DroptablePosY, -1f);
        }
        else
        {
            //아니면 원래자리로 돌아감
            this.gameObject.transform.position = LoadedPos;
        }
    }
    //스크립트를 짜다보니 여기가 필요가없음...
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //원하는 과일이 맞는지 체크하기위해 불러옴
        num = checkfruit.GetComponent<checkfruit>().wantFruitNum;
        num1 = checkfruit.GetComponent<checkfruit>().wantFruitNum1;
        num2 = checkfruit.GetComponent<checkfruit>().wantFruitNum2;
        //태그가 table이고 들어올 과일들의이름이 맞음?
        if (collision.transform.tag == "Table" 
            && transform.tag == checkfruit.GetComponent<checkfruit>().fruitName[num] 
            && transform.tag == checkfruit.GetComponent<checkfruit>().fruitName[num1]
            && transform.tag == checkfruit.GetComponent<checkfruit>().fruitName[num2])
        {
            //맞으면 isPoint를 true로 반환
            isPoint = true;
            //놓을 위치의 Y값도 반환
            DroptablePosX = collision.transform.position.x;
            DroptablePosY = collision.transform.position.y;
            

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Table")
        {
           //트리거를 빠져나갈때 tag가 table이면 isPoint false로 반환
            isPoint = false;
        }
       

    }
}
