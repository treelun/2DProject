using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    //BGM이 씬을 넘어가도 계속 재생되도록 하는 스크립트
    GameObject bgm;
    AudioSource backMusic;

    private void Awake()
    {
        bgm = GameObject.Find("bgm");
        backMusic = bgm.GetComponent<AudioSource>();
        //BGM이 재생중이면 리턴
        if (backMusic.isPlaying)
        {
            return;
        }
        //아니면 재생
        else
        {
            backMusic.Play();
            //다른씬으로 넘어가도 계속 재생
            DontDestroyOnLoad(bgm);
        }
    }
}
