using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleEnemy : Enemy
{
    //���� ��ȯ�� ���� ���Ͱ�
    public Vector2 direction;
    //�������� ������ȯ ������ üũ�ϱ����ؼ� LayerMask�� ���
    public LayerMask layerMask_wall;
    //��� �������� üũ�Ұ��ΰ� �����Ϳ��� �־���
    public Transform checkWall;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            yield return null;

            //Physics2D.Raycast(checkWall.position�� ray�� �������̶�� �����ؾ��ҵ�,
            //����,ray�� ����, �� ��ũ��Ʈ������ layermask�� ����ϹǷ� �ش��ϴ� layer�Է�)
            if (Physics2D.Raycast(checkWall.position, direction, 0.1f, layerMask_wall))
            {
                //�����ǿ� ������ checkwall==���� �ν��ϱ� ���� ������Ʈ�� direction �� �������� , 0.1f�� ���̸�ŭ
                //ray�� �߻��� �߻��� ray�� leyerMask_wall(�����Ϳ��� ������Ʈ�־���)�� ������
                //������ȯ �޼��� ����
                EnemyFlip();
                //������ direction�� �ݴ밪�� �������� direction�� ������ �״�ζ��
                //������ȯ�� wall�� �������� �ν����� ���Ҽ�����
                direction = new Vector2(-direction.x, direction.y);
            }
            //EnemyŬ������ ��ӹ����Ƿ� EnemyŬ������ ���� movement(EmemyMove�� �������..��Ÿ���ֳ�)�� Move�� ����
            movement.Move(direction);


        }
    }

}
