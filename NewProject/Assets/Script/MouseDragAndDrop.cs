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
        //����� ��ġ�� Ʋ���� ó�� ���ڸ��� ���ư�
        LoadedPos = this.transform.position;
        checkfruit = GameObject.Find("Box");
        
    }

    // Update is called once per frame
    void Update()
    {
        //���콺 ���� ��ư�� ������ ����
        if (isBeingheld)
        {
            Vector2 mousePos;
            //Vector2�� ī�޶� ȭ���� ���콺��ġ�� ���� ����Ʈ�� ������
            //ScreenToWorldPoint�� ī�޶�(Camera)�� ���߰� �ִ� ȭ��(Screen)���� ��ǥ���� ����� �� �ְ� ���ش�.

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //������Ʈ�� �����ǰ��� ���콺��ġ�� x,y���� ó�� ���콺�� ���������� ���콺 ��ġ�� ������Ʈ�� ��ġ�� ������
            //������ �ȴ�.
            //�� ��ũ��Ʈ�� ���⿣ ���콺��ġ�� �� ������Ʈ�� �ٿ������μ� �̵��ϴ°� ó�� ���̰��һ�
            this.gameObject.transform.position = new Vector2(mousePos.x - startPosx, mousePos.y - startPosY);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //���⿡�� startPosx�� �����ش�. ���콺�� ������ġ���� ��ũ��Ʈ�� �������ִ� ������Ʈ�� position.x���� ���� ���̴�.
            
            startPosx = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

            isBeingheld = true;
        }
    }

    private void OnMouseUp()
    {
        //���콺�� ���� isBeingheld�� false���Ǿ� update���� ����
        isBeingheld = false;

        //isPoint�� ���� ����� ��ġ�� �´��� Ȯ���ϱ����� bool��
        if (isPoint)
        {
            //����� ��ġ�� �´ٸ� ������Ʈ�� �������� ���� ��ġ�� y���� �������� ����
            this.gameObject.transform.position = new Vector3(DroptablePosX, DroptablePosY, -1f);
        }
        else
        {
            //�ƴϸ� �����ڸ��� ���ư�
            this.gameObject.transform.position = LoadedPos;
        }
    }
    //��ũ��Ʈ�� ¥�ٺ��� ���Ⱑ �ʿ䰡����...
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���ϴ� ������ �´��� üũ�ϱ����� �ҷ���
        num = checkfruit.GetComponent<checkfruit>().wantFruitNum;
        num1 = checkfruit.GetComponent<checkfruit>().wantFruitNum1;
        num2 = checkfruit.GetComponent<checkfruit>().wantFruitNum2;
        //�±װ� table�̰� ���� ���ϵ����̸��� ����?
        if (collision.transform.tag == "Table" 
            && transform.tag == checkfruit.GetComponent<checkfruit>().fruitName[num] 
            && transform.tag == checkfruit.GetComponent<checkfruit>().fruitName[num1]
            && transform.tag == checkfruit.GetComponent<checkfruit>().fruitName[num2])
        {
            //������ isPoint�� true�� ��ȯ
            isPoint = true;
            //���� ��ġ�� Y���� ��ȯ
            DroptablePosX = collision.transform.position.x;
            DroptablePosY = collision.transform.position.y;
            

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Table")
        {
           //Ʈ���Ÿ� ���������� tag�� table�̸� isPoint false�� ��ȯ
            isPoint = false;
        }
       

    }
}
