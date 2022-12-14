using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EagleEnemy : Enemy
{
    GameObject Player;
    GameObject PlayerHpBar;
    GameObject GameOver;
    Rigidbody2D rb2d;
    //방향 전환을 위한 벡터값
    public Vector2 direction;
    //독수리가 방향전환 지점을 체크하기위해서 LayerMask를 사용
    public LayerMask layerMask_wall;
    //어떤걸 기준으로 체크할것인가 에디터에서 넣어줌
    public Transform checkWall;

    public float Hp;
    public bool retry = false;

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
        Time.timeScale = 1;
        //player의 체력이 0이면 
        if (PlayerHpBar.GetComponent<Image>().fillAmount == 0)
        {
            //플레이어 파괴
            Destroy(Player);
            //gameover활성화
            GameOver.SetActive(true);
            retry = true;
            Time.timeScale = 0;
        }
    }
    public IEnumerator EnemyMove()
    {
        while (true)
        {
            yield return null;

            //Physics2D.Raycast(checkWall.position은 ray의 기준점이라고 생각해야할듯,
            //방향,ray의 길이, 이 스크립트에서는 layermask를 사용하므로 해당하는 layer입력)
            if (Physics2D.Raycast(checkWall.position, direction, 0.1f, layerMask_wall))
            {
                //위조건에 따르면 checkwall==벽을 인식하기 위한 오브젝트가 direction 의 방향으로 , 0.1f의 길이만큼
                //ray를 발사함 발사한 ray가 leyerMask_wall(에디터에서 오브젝트넣어줌)에 닿으면
                //방향전환 메서드 실행
                EnemyFlip();
                //실행후 direction은 반대값을 가지게함 direction의 방향이 그대로라면
                //방향전환후 wall을 만났을때 인식하지 못할수있음
                direction = new Vector2(-direction.x, direction.y);
            }
            //Enemy클래스를 상속받으므로 Enemy클래스의 값인 movement(EmemyMove가 담겨있음..오타나있네)의 Move를 실행
            movement.Move(direction);


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            //독수리 몬스터이기에 위에서 캐릭터를 공격하므로 캐릭터보다 위에서 collison되면 데미지를줌
            if (transform.position.y > collision.transform.position.y)
            {
                OnDamaged(collision.transform.position);
            }
            
        }
    }
    

    void OnDamaged(Vector2 targetPos)
    {
        //무적을 주기위해 레이어 변경
        Player.gameObject.layer = 9;
        //피격 효과를위해 투명도 변화
        Player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);
        
        //맞았을때 뒤로 밀리는 효과를 주기위해 삼항연산자 사용
        int dirc = Player.transform.position.x - targetPos.x > 0 ? 1 : -1;
        Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(dirc, 1) * 9, ForceMode2D.Impulse);
        //실직적으로 데미지를 줌
        PlayerHpBar.GetComponent<Image>().fillAmount -= 0.4f;
        //2초뒤 offDamge메서드를 불러옴
        Invoke("offDamage", 2f);

    }

    void offDamage()
    {
        //레리어 정상으로 돌림
        Player.gameObject.layer = 0;
        //투명도 정상으로 돌림
        Player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
    }




}
