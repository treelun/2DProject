using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{

    void Update()
    {
        //ĳ���Ͱ� ������ �������� �� �ٽ� �ҷ���
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("RunningMap");
        }
    }
}
