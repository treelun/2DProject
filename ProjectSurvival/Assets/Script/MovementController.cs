using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    //public으로 유니티 에디터에서 설정해줌
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
        //릿지드 바디나 에니메이터 등의 컴포넌트를 사용하려면 꼭 겟 컴포넌트를 해라...
        //위에서 선언한다고 값이 들어가있는게 아니기때문에 프로그램은 축약어로?? 선언한거만알지 그안에 뭐가 들어있는지 모름
        // 그렇기 때문에 start가 됐든 Awake가 됐든 위에서 부르든 해서 꼭 담아주자. 후...
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

    //캐릭터 움직임
    void MoveCharacter()
    {
        //이게임에서 움직임은 앞뒤만 필요하므로 수평(horizontal)을 받아온다.
        movement.x = Input.GetAxisRaw("Horizontal");

        movement.Normalize();
        //AddForce를 사용하여 캐릭터의 움직임을 구현
        rb2d.AddForce(Vector2.right * movement.x * movementSpeed);

        //animation을 작동하기위한 함수 rigidbody2d의 velocity(속력)의 x값이 0이 아니면 움직이고 있으므로
        if (rb2d.velocity.x != 0)
        {
            //달리는 애니메이션 true
            animator.SetBool("isRun", true);
        }
        else
        {
            //아니라면 멈추어 있는상태이므로 false반환 문제는 바로 0으로 되는것이 아니기에 애니메이션 전환이 자연스럽지 않음
            animator.SetBool("isRun", false);
        }
        //캐릭터의 방향전환을 위한 key값
        int key = 0;

        //릿지드바디의 x값의 속력이 maxspeed보다 크고 오른쪽 방향키를 누르면
        if (rb2d.velocity.x > maxSpeed && Input.GetKey(KeyCode.D))
        {
            //rigidbody2d.velocity에 Vector2값을 넣어줌 AddForce를 사용하기에 가속이 계속붙어 속도에 제한을줌
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
            //키값을 받는 if문을 더 만들기 싫어서 여기에 넣어버림
            key = 1;
        }
        //위와 같이 속도 제한을 위해 만들었지만 왼쪽으로의 움직임을 제한
        else if (rb2d.velocity.x < -maxSpeed && Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
            key = -1;
        }
        //키값이 0이 아니면
        if (key != 0)
        {
            //Vector3로 x값에 key값을 넣어줌 음수냐 양수냐에 따라 2D이기에 방향전환이 가능함 
            transform.localScale = new Vector3(key, 1, 1);
        }
    }

    //점프 하는 메서드
    void JumpCharacter()
    {
     //스페이스바를 누르면  
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //isjump가 false인지 확인
            if (!isJump)
            {
                print("isJump = true");
                //계속 점프할수없도록 isjump를 true로
                isJump = true;
                //점프 애니메이션을 재생하기위한 값
                animator.SetBool("isJump", true);
                //점프 애니메이션을 재생하는데 달리는 애니메이션이 나오면 안되므로 false를 줌
                animator.SetBool("isRun", false);

                //실질적으로 점프를하는 값 Vector3.up 위로 향하는 값에 jumpforce를 곱해준 값을 rigidbody2D.velocity에 저장함
                rb2d.velocity = Vector3.up * Jumpforce;
            }
           
        }
    }

    //콜라이더끼리 충돌했는지 알기위한 함수 Enter는 충돌을 시작하면 실행함
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //충돌한 개체의 tag값을 가져옴
        if (collision.transform.CompareTag("Ground"))
        {
            print("isJump = false");
            //isjump를 false로 바꿔줌 player가 땅에 닿았을 경우에만 점프하게 하고싶기 때문
            isJump = false;
            //점프 애니메이션 종료
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
