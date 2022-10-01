using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{

    void Update()
    {
        //캐릭터가 밑으로 떨어지면 씬 다시 불러옴
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("RunningMap");
        }
    }
}
