using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    //public���� ����Ƽ �����Ϳ��� ��������
    public float movementSpeed;
    public float Jumpforce;
    public float maxSpeed;
    GameObject Enemy_Eagle;
    Vector2 movement = new Vector2();

    Rigidbody2D rb2d;

    public bool isJump = false;
    public bool isRun = false;

    Animator animator;
    GameObject EnemyHpBar;

    // Start is called before the first frame update
    void Start()
    {
        //������ �ٵ� ���ϸ����� ���� ������Ʈ�� ����Ϸ��� �� �� ������Ʈ�� �ض�...
        //������ �����Ѵٰ� ���� ���ִ°� �ƴϱ⶧���� ���α׷��� �����?? �����ѰŸ����� �׾ȿ� ���� ����ִ��� ��
        // �׷��� ������ start�� �Ƶ� Awake�� �Ƶ� ������ �θ��� �ؼ� �� �������. ��...
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        EnemyHpBar = GameObject.Find("EnemyHpBar");
        Enemy_Eagle = GameObject.Find("Enemy_Eagle");


    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        JumpCharacter();
        if (EnemyHpBar.GetComponent<Image>().fillAmount == 0)
        {
            Destroy(Enemy_Eagle);
        }
    }
    private void FixedUpdate()
    {
        
    }

    //ĳ���� ������
    void MoveCharacter()
    {
        //�̰��ӿ��� �������� �յڸ� �ʿ��ϹǷ� ����(horizontal)�� �޾ƿ´�.
        movement.x = Input.GetAxisRaw("Horizontal");

        movement.Normalize();
        //AddForce�� ����Ͽ� ĳ������ �������� ����
        rb2d.AddForce(Vector2.right * movement.x * movementSpeed);

        //animation�� �۵��ϱ����� �Լ� rigidbody2d�� velocity(�ӷ�)�� x���� 0�� �ƴϸ� �����̰� �����Ƿ�
        if (rb2d.velocity.x != 0)
        {
            //�޸��� �ִϸ��̼� true
            animator.SetBool("isRun", true);
        }
        else
        {
            //�ƴ϶�� ���߾� �ִ»����̹Ƿ� false��ȯ ������ �ٷ� 0���� �Ǵ°��� �ƴϱ⿡ �ִϸ��̼� ��ȯ�� �ڿ������� ����
            animator.SetBool("isRun", false);
        }
        //ĳ������ ������ȯ�� ���� key��
        int key = 0;

        //������ٵ��� x���� �ӷ��� maxspeed���� ũ�� ������ ����Ű�� ������
        if (rb2d.velocity.x > maxSpeed && Input.GetKey(KeyCode.D))
        {
            //rigidbody2d.velocity�� Vector2���� �־��� AddForce�� ����ϱ⿡ ������ ��Ӻپ� �ӵ��� ��������
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
            //Ű���� �޴� if���� �� ����� �Ⱦ ���⿡ �־����
            key = 1;
        }
        //���� ���� �ӵ� ������ ���� ��������� ���������� �������� ����
        else if (rb2d.velocity.x < -maxSpeed && Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
            key = -1;
        }
        //Ű���� 0�� �ƴϸ�
        if (key != 0)
        {
            //Vector3�� x���� key���� �־��� ������ ����Ŀ� ���� 2D�̱⿡ ������ȯ�� ������ 
            transform.localScale = new Vector3(key, 1, 1);
        }
    }

    //���� �ϴ� �޼���
    void JumpCharacter()
    {
     //�����̽��ٸ� ������  
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //isjump�� false���� Ȯ��
            if (!isJump)
            {
                print("isJump = true");
                //��� �����Ҽ������� isjump�� true��
                isJump = true;
                //���� �ִϸ��̼��� ����ϱ����� ��
                animator.SetBool("isJump", true);
                //���� �ִϸ��̼��� ����ϴµ� �޸��� �ִϸ��̼��� ������ �ȵǹǷ� false�� ��
                animator.SetBool("isRun", false);

                //���������� �������ϴ� �� Vector3.up ���� ���ϴ� ���� jumpforce�� ������ ���� rigidbody2D.velocity�� ������
                rb2d.velocity = Vector3.up * Jumpforce;
            }
           
        }
    }

    //�ݶ��̴����� �浹�ߴ��� �˱����� �Լ� Enter�� �浹�� �����ϸ� ������
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�浹�� ��ü�� tag���� ������
        if (collision.transform.CompareTag("Ground"))
        {
            print("isJump = false");
            //isjump�� false�� �ٲ��� player�� ���� ����� ��쿡�� �����ϰ� �ϰ�ͱ� ����
            isJump = false;
            //���� �ִϸ��̼� ����
            animator.SetBool("isJump", false);
        }

        if (collision.transform.tag == "Eagle")
        {
            if (rb2d.velocity.y < 0 && transform.position.y > collision.transform.position.y)
            {
                OnAttack(collision.transform);
            }
        }

    }


    void OnAttack(Transform enermy)
    {
        rb2d.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        EnemyHpBar.GetComponent<Image>().fillAmount -= 0.4f;
        Enemy_Eagle_Controller enemy_Eagle_Controller = enermy.GetComponent<Enemy_Eagle_Controller>();
        enemy_Eagle_Controller.OnDamaged();
    }





}
