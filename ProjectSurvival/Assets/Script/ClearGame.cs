using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�÷��̾ ������
        if (collision.transform.tag == "Player")
        {
            //����Ŭ���� �� �θ�
            SceneManager.LoadScene("GameClear");


        }

    }
}
