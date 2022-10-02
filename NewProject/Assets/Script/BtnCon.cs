using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnCon : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("StartGame");
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
}
