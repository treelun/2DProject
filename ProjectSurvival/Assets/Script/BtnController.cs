using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BtnController : MonoBehaviour
{
    EagleEnemy eagle;
    bool isRetry;
    private void Start()
    {
        eagle = GetComponent<EagleEnemy>();
        isRetry = eagle.retry;
    }
    public void StartButton()
    {
        SceneManager.LoadScene("StartGame");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void retrybtn()
    {
        
            SceneManager.LoadScene("StartGame");
        
            Time.timeScale = 1;
        
    }


}
