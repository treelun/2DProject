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
        if (isDirLeft)
        {
            thisScale.x = Mathf.Abs(thisScale.x);
        }
        else
        {
            thisScale.x = -Mathf.Abs(thisScale.x);

        }
        transform.localScale = thisScale;
    }
}
