using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DayText : MonoBehaviour
{
    //O일차 의 개념을 넣음
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
        //타이머의 시간이 다되면 isNextday를 true로 반환해줌
        if (Timer.GetComponent<Timer>().isNextday == true)
        {
            //그러면 day의 숫자 증가
            Debug.Log("Day 증가");
            day++;
            //휴식 씬 불러옴
            SceneManager.LoadScene("Rest");
        }
        //텍스트창에 표현
        gameObject.GetComponent<TextMeshProUGUI>().text = day + "일째";
        //10일차가 넘어가면 게임종료
        if (day > 10)
        {
            SceneManager.LoadScene("Clear");
            //0일차로 초기화해줌
            day = 0;
        }
    }

}
