using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //���� ��ȯ������ bool��
    public bool isDirLeft = true;
    public EmemyMove movement;
    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponent<EmemyMove>();
    }


    //���������� ���� ��ȯ�� �ϴ� �޼���
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
