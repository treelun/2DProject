using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnCon : MonoBehaviour
{
    GameObject PuaseText;
    GameObject Day;
    bool isPuase = true;
    private void Start()
    {
        PuaseText = GameObject.Find("PuaseText");
        PuaseText.SetActive(false);
        Day = GameObject.Find("Day");
    }
    public void StartBtn()
    {
        SceneManager.LoadScene("StartGame");
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
    public void TradeBtn()
    {

    }

    public void PuaseBtn()
    {
        if (isPuase == true)
        {
            Time.timeScale = 0;
            isPuase = false;
            PuaseText.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            isPuase = true;
            PuaseText.SetActive(false);
        }
        
    }
    public void NextdayBtn()
    {
        SceneManager.LoadScene("BuyFruit");
        Day.GetComponent<DayText>().day++;
    }
    public void CompleteBuy()
    {
        SceneManager.LoadScene("StartGame");
    }
}
