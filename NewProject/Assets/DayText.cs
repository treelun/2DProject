using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DayText : MonoBehaviour
{
    //O���� �� ������ ����
    GameObject Timer;
    static int day = 1;
    // Start is called before the first frame update
    void Start()
    {
        Timer = GameObject.Find("Timer");
        
    }

    // Update is called once per frame
    void Update()
    {
        PrintText(ref day);
    }
    void PrintText(ref int day)
    {
        //Ÿ�̸��� �ð��� �ٵǸ� isNextday�� true�� ��ȯ����
        if (Timer.GetComponent<Timer>().isNextday == true)
        {
            //�׷��� day�� ���� ����
            Debug.Log("Day ����");
            day++;
            //�޽� �� �ҷ���
            SceneManager.LoadScene("Rest");
        }
        //�ؽ�Ʈâ�� ǥ��
        gameObject.GetComponent<TextMeshProUGUI>().text = day + "��°";
        //10������ �Ѿ�� ��������
        if (day > 10)
        {
            SceneManager.LoadScene("Clear");
            //0������ �ʱ�ȭ����
            day = 0;
        }
    }

}
