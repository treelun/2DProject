using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoVector : MonoBehaviour
{
    //destination�� ���� ��ġ, duration�� ������ġ���� destination���� �ɸ��� �ð�

    public  IEnumerator FlyAmmo(Vector3 destination, float duration)
    {
        Vector3 startPosition = transform.position;

        float percentComplete = 0.0f;
        while (percentComplete < 1.0f)
        {
            //�Ѿ��� �Ų����� �����̰� �; ���
            //�Ѿ��� �� �����Ӹ��� �̵��� �Ÿ��� �޶�����.
            //���� ���������ķ� �帥�ð�(Time.deltaTime)�� �Ѿ��� �����̷��� �ð�(duration)���� ������
            //���� �����ӿ����� �������� ���Ҽ� �ִٰ� �Ѵ�.
            //percentComplete�� ������ ��������� ������������ ������� ���� �� �������� �ȴ�.
            //������� time.deltaTime�� 1�̰� duration�� 10�̶�� 1/10�̵ȴ� �������� ����ɼ��� deltatime��
            //���� �þ ���̰� 2/10 , 3/10 ��� �׷��ϱ� 0.1,0.2,0.3 �̷������� ��� ���ϴ°�
            //percentComplete�� �ȴ�.
            percentComplete += Time.deltaTime / duration;

            //object�� �Ų����� �����̴°�ó�� ���̰� �ϱ����ؼ�
            //Lerp �������� �̶�°� ����Ѵٰ� �Ѵ�.
            //Lerp()�� ����ϱ����ؼ� Lerp(��������, ��������,0~1 ������ �����)�̷��� ����ؾ��Ѵ�.
            //Lerp()�޼��忡�� �� ������� ����Ѵٴ� ���� Object�� ȭ���� ���� �߻��ϵ��� �����ϴ� �ð���
            //���ٰ� �Ѵ�.(���������̳� ������ ��� ������ ���� �ʴ´ٴ� ���ε�?)
            //Lerp()�� �� ������� �������� ���������� �������������� ��ġ�� ��ȯ �Ѵٰ� �Ѵ�.
            //�� ��ġ�� Object�� transform.position�� �־��־���.
            transform.position = Vector3.Lerp(startPosition, destination, percentComplete);
            //���� �����ӱ��� �ڷ�ƾ�� ����
            yield return null;
        }
        //�������� �����ߴٸ� Object�� ��Ȱ��ȭ ����
        gameObject.SetActive(false);
    }
}
