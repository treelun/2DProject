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
        //isDirLeft�� false�̸�
        if (isDirLeft)
        {
            
            thisScale.x = 1;
                
        }
        else
        {

            thisScale.x = -1;
                

        }
        //localscale�� 1 �̸� �⺻���� �̹��� ������ �ٶ󺸰� -1�̸� �ݴ����� �ٶ�
        transform.localScale = thisScale;
    }
}
