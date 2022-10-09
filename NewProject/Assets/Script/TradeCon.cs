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
        //������ ������ġ �� ������ �Ǹ��ϴ� ����� ������ �ִ� ��ũ��Ʈ

        //���� ���� StartGame�̸�
        if (SceneManager.GetActiveScene().name == "StartGame")
        {
            //����â �ؽ�Ʈ ǥ��
            Money.GetComponent<TextMeshProUGUI>().text = "Money : " + price;
        }
        //���� ���� Clear���̸�
        else if (SceneManager.GetActiveScene().name == "Clear")
        {
            //����â �ؽ�Ʈ ǥ��
            Money.GetComponent<TextMeshProUGUI>().text = "���� ���� : " + price;
        }
        //Ÿ��Ʋ�� ���ư��� ��ư�� ������
        if (button.GetComponent<BtnCon>().istitle == true)
        {
            //���� �ʱ�ȭ
            price = 0;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�ڽ��� triggerEnter�Ǵ� �ֵ��� ���� ���ϴ� �ֵ����� �˾ƾ� �ϱ⿡ ���� �޾ƿ�
        //��ġ�� ����������, �ߺ����� �ǸŰ���, ���,����,������ ��� 1������ �Ǹ��ϰ� �;��µ�
        //���,���,��� �� �ȾƵ� �ǸŰ��ǰ� ���ϴ� ���ϸ���� ���ΰ�ħ��
        //�׷��� ���Ž¸��� �ϱ������, ������ ������� ��ǥ�� �ϴ� �����̰�
        //���ϸ��� ������ �� �ٸ��� �����Ÿ� ��� �ȾƵ� �ǰԲ�
        //�ƹ�ư �׷��� ���ϴ� �ֵ��� tag���̸�?
        num = checkfruit.GetComponent<checkfruit>().wantFruitNum;
        num1 = checkfruit.GetComponent<checkfruit>().wantFruitNum1;
        num2 = checkfruit.GetComponent<checkfruit>().wantFruitNum2;
        if (collision.transform.tag == checkfruit.GetComponent<checkfruit>().fruitName[num]
            || collision.transform.tag == checkfruit.GetComponent<checkfruit>().fruitName[num1]
            || collision.transform.tag == checkfruit.GetComponent<checkfruit>().fruitName[num2])
        {
            //price�� trigger�� ���� ������Ʈ�� price���� �����ָ鼭
            price += collision.gameObject.GetComponent<FruitManager>().price;
            //������Ʈ�� �ı���
            //�̹��� �˾Ҵµ� ���� �ٲ�� �׳� ���� �ٽ� �ʱ�ȭ�� ��
            //������Ʈ�� 10���� ���������� �ı��ϸ� ���� �پ �Ǹ��� ������ �������� �ϴ°��� �����̰�����
            //������ ������ ����ȯ�� ���� �޽Ľð��� �����Ե�
            //�׷��� �ٽ� ���������� ���ƿ����� �ı��� �ֵ��� �ٽ� �����Ǿ����� ���� ���� ������
            //�׷��� ������ ���������� public�����ص� �ʱ�ȭ�Ǵ����� �׹�������
            //�װ��� �ذ��ϱ����ؼ� static������ ����ؾ��� �׷��� static�� ����ϸ� public�� �����ؼ� �ٸ� Ŭ��������
            //���������, �ᱹ ���� ���������� ������Ű�� ���� �����ִٸ� �� ��ũ��Ʈ���� �ؾߵȴٴ� ����������
            
            Destroy(collision.gameObject);
            //sellcount�� �÷��� �ֳĸ� �츮�� 3���� ���ϴ� ���ϼմ��� �־��� 3���� �Ȱ��̱⿡
            sellcount++;
            Debug.Log(sellcount);

            //�ǸŰ� �Ǿ��ٴ� �ִϸ��̼� ����
            animator.SetTrigger("isdrop");
            //3���� �ȾҾ�?
            if (sellcount == 3)
            {
                //isSell true�� ��ȯ����
                isSell = true;
                //true�޾Ҿ�?
                if (isSell == true)
                {
                    //sellcount�� 0���� ��ȯ����
                    sellcount = 0;
                }

            }
            //���⵵ �ϰ�������� ����. 3���� �Ⱦ����� ���ϴ� ������ �ٲ����ϴµ� �ʹ����� sellcount�� 0���� �ٲ�� ������ �ȵǴ�
            //������ �־���. �׷��� ���� ���� �ǲ�� �ذ��ߴ�..
        }

        else
        {
            price -= collision.gameObject.GetComponent<FruitManager>().price;
        }


    }


}
