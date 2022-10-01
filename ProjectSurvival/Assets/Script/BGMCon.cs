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
            DontDestroyOnLoad(BGM);
        }
    }

}
