using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DayText : MonoBehaviour
{
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
        
        if (Timer.GetComponent<Timer>().isNextday == true)
        {
            Debug.Log("Day ����");
            day++;
            SceneManager.LoadScene("Rest");
        }

        gameObject.GetComponent<TextMeshProUGUI>().text = day + "��°";
        if (day > 10)
        {
            SceneManager.LoadScene("Clear");
            day = 0;
        }
    }
/*    IEnumerator PrintText(ref int day)
    {
        if (Timer.GetComponent<Timer>().time > 0.9)
        {
            Debug.Log("Day ����");
            day++;

        }

        gameObject.GetComponent<TextMeshProUGUI>().text = day + "��°";

        yield return null;
    }*/
}
