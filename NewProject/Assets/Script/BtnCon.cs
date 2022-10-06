using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnCon : MonoBehaviour
{
   //버튼에 기능을 주기위한 스크립트
    
   
    bool isPuase = true;
    public bool istitle = false;

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
            
        }
        else
        {
            Time.timeScale = 1;
            isPuase = true;
            
        }
        
    }

    public void CompleteBuy()
    {
        SceneManager.LoadScene("StartGame");
            }


    public void mainBtn()
    {
        SceneManager.LoadScene("MainMenu");
        istitle = true;
    }
}
