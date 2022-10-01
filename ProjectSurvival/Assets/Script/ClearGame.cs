using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어가 닿으면
        if (collision.transform.tag == "Player")
        {
            //게임클리어 씬 부름
            SceneManager.LoadScene("GameClear");


        }

    }
}
