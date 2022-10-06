using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnCon : MonoBehaviour
{
    GameObject PuaseText;
    GameObject info;
    GameObject MainBtn;
    bool isPuase = true;
    public bool istitle = false;
    private void Start()
    {
        PuaseText = GameObject.Find("PuaseText");
        PuaseText.SetActive(false);

        info = GameObject.Find("info");
        info.SetActive(false);

        MainBtn = GameObject.Find("MainBtn");

    }
    public void StartBtn()
    {
        SceneManager.LoadScene("StartGame");
        istitle = false;
    }
    public void QuitBtn()
    {
        Application.Quit();
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

    public void CompleteBuy()
    {
        SceneManager.LoadScene("StartGame");
        
    }
    public void infoBtn()
    {
        info.SetActive(true);
        MainBtn.SetActive(false);
    }
    public void backBtn()
    {
        info.SetActive(false);
        MainBtn.SetActive(true);
    }

    public void mainBtn()
    {
        SceneManager.LoadScene("MainMenu");
        istitle = true;
    }
}
