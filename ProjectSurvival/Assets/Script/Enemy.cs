using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //방향 전환을위한 bool값
    public bool isDirLeft = true;
    public EmemyMove movement;
    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponent<EmemyMove>();
    }


    //실질적으로 방향 전환을 하는 메서드
    public void EnemyFlip()
    {
        isDirLeft = !isDirLeft;
        Vector3 thisScale = transform.localScale;
        //isDirLeft가 false이면
        if (isDirLeft)
        {
            
            thisScale.x = 1;
                
        }
        else
        {

            thisScale.x = -1;
                

        }
        //localscale이 1 이면 기본적인 이미지 방향을 바라보고 -1이면 반대쪽을 바라봄
        transform.localScale = thisScale;
    }
}
