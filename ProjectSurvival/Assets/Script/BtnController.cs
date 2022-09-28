using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnController : MonoBehaviour
{
    GameObject titleScreen;
    GameObject optionMenu;
    private void Start()
    {
        //�̰� �ָ������??
        titleScreen = GameObject.Find("TitleScreen");
        optionMenu = GameObject.Find("OptionMenu");
    }
    public void StartButton()
    {
        SceneManager.LoadScene("StartGame");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void ChangeVolume(float value)
    {
        PlayerPrefs.SetFloat("Volume", value);
    }


}
