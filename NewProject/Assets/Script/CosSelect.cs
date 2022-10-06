using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class CosSelect : MonoBehaviour
{
    GameObject FoodTable;
    public bool isCompleteBtn = false;

    //������â���� ����Ʈ�� ����� ���� �̹����� �Ǵ� �������� ����
    public List<GameObject> Costomer;
    private void Start()
    {
        FoodTable = GameObject.Find("FoodTable");
    }
    // Update is called once per frame
    void Update()
    {
        //�մ��� ����� �ٲ��ֱ����� ��ũ��Ʈ
        //����3������ �Ȱ��̱⿡ isSell�� �Ǹ� ī��Ʈ�� 3���� �Ǹ� true�� ��ȯ�ϰ� �Ǿ�����
        if (FoodTable.GetComponent<TradeCon>().isSell == true)
        {
            //�޼��尡 ��� �����ʱ����� bool��
            isCompleteBtn = true;
            //�޼��� ����
            CallCostomer();
            FoodTable.GetComponent<TradeCon>().isSell = false;
        }

    }

    void CallCostomer()
    {
        //isCompleteBtn�� true�� �Ǹ�
        if (isCompleteBtn == true)
        {
            //���� ������ 4�����̱⿡ 0~3������ ���ڸ� �������� ����
            int rannum = Random.Range(0, 4);
            //SpriteRenderer�� �ᱹ ȭ�鿡 ���̴� �̹�����, ������ �ν�����â���� ���� ����Ʈ���� ������ �༮�� sprite�� ������
            gameObject.GetComponent<SpriteRenderer>().sprite = Costomer[rannum].GetComponent<SpriteRenderer>().sprite;
            //1���� �����Ҽ��ֵ��� false�� ��ȯ
            isCompleteBtn = false;
        }
       
    }
}
