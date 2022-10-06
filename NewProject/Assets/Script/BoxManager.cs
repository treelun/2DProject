using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    //������ ��� �ڽ� ����

    //������ �ν����� â���� ������Ʈ���� �־� ��������
    public GameObject prefabFruit;
    public GameObject Box;
    public List<GameObject> Fruit;

    
    //������ �ִ밹��
    int fruitMaxStack = 10;

    private void Awake()
    {
        //����Ʈ�� ��������� ����Ʈ ����
        if (Fruit == null)
        {
            Fruit = new List<GameObject>();
        }
    }
    void Update()
    {
        
        MakeFruit();

    }

    void MakeFruit()
    {
        //����Ʈ�� ũ�Ⱑ ������ �ִ밹���� �����ʴٸ�
        if (Fruit.Count != fruitMaxStack)
        {
            for (int i = 0; i < fruitMaxStack; i++)
            {
                //����Ʈ�� ��������� �־���

                GameObject fruitObject = Instantiate(prefabFruit);
                
                Fruit.Add(fruitObject);
                //���ϵ��� �����Ǵ� ��ġ�� �ڽ��� ��ġ��
                fruitObject.transform.position = Box.transform.position;
                
            }
        }
    }
}
