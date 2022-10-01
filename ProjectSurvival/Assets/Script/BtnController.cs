using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BtnController : MonoBehaviour
{

    private void Start()
    {

    }
    public void StartButton()
    {
        SceneManager.LoadScene("StartGame");
    }

    public void QuitButton()
    {
        Application.Quit();
    }




}
