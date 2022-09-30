using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EagleEnemy : Enemy
{
    GameObject Player;
    GameObject PlayerHpBar;
    GameObject GameOver;
    Rigidbody2D rb2d;
    //���� ��ȯ�� ���� ���Ͱ�
    public Vector2 direction;
    //�������� ������ȯ ������ üũ�ϱ����ؼ� LayerMask�� ���
    public LayerMask layerMask_wall;
    //��� �������� üũ�Ұ��ΰ� �����Ϳ��� �־���
    public Transform checkWall;

    public float Hp;

    private void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        PlayerHpBar = GameObject.Find("PlayerHpBar");
        GameOver = GameObject.Find("GameOver");
        GameOver.SetActive(false);
    }
    // Start is called before the first frame update
    private void Update()
    {
        StartCoroutine(EnemyMove());
        if (PlayerHpBar.GetComponent<Image>().fillAmount == 0)
        {
            Destroy(Player);
            GameOver.SetActive(true);
        }
    }
    public IEnumerator EnemyMove()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (transform.position.y > collision.transform.position.y)
            {
                OnDamaged(collision.transform.position);
            }
            
        }
    }
    

    void OnDamaged(Vector2 targetPos)
    {
        Player.gameObject.layer = 9;

        Player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);
        

        int dirc = Player.transform.position.x - targetPos.x > 0 ? 1 : -1;
        Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(dirc, 1) * 9, ForceMode2D.Impulse);
        PlayerHpBar.GetComponent<Image>().fillAmount -= 0.4f;

        Invoke("offDamage", 2f);

    }

    void offDamage()
    {
        Player.gameObject.layer = 0;
        Player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
    }




}
