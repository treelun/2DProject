using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    GameObject bgm;
    AudioSource backMusic;

    private void Awake()
    {
        bgm = GameObject.Find("bgm");
        backMusic = bgm.GetComponent<AudioSource>();
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
            DontDestroyOnLoad(bgm);
        }
    }
}
