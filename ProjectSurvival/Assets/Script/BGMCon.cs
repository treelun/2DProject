using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMCon : MonoBehaviour
{
    GameObject BGM;
    AudioSource backMusic;

    private void Awake()
    {
        BGM = GameObject.Find("BGM");
        backMusic = BGM.GetComponent<AudioSource>();
        //BGM�� ������̸� ����
        if (backMusic.isPlaying)
        {
            return;
        }
        //�ƴϸ� ���
        else
        {
            backMusic.Play();
            //�ٸ������� �Ѿ�� ��� ���
            DontDestroyOnLoad(BGM);
        }
    }

}
