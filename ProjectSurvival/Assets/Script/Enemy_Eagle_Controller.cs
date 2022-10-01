using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy_Eagle_Controller : MonoBehaviour
{

    public float pursuitSpeed;
    public float wanderSpeed;
    float currentSpeed;

    public float directionChangeInterval;

    public bool followPlayer;

    Coroutine moveCoroutine;

    Rigidbody2D rb2d;

    Transform targetTransform;

    Vector3 endPosition;
   

    CircleCollider2D circleCollider;
    BoxCollider2D boxCollider;

    public bool isMove = false;

    SpriteRenderer Renderer;


    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = wanderSpeed;

        rb2d = GetComponent<Rigidbody2D>();
        
        circleCollider = GetComponent<CircleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        Renderer = GetComponent<SpriteRenderer>();
       


    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Move(Rigidbody2D rigidBodyToMove, float speed)
    {
        //sqrMagnitude는 현재위치와 목적지 사이의 대략적인 거리의 벡터 크기를 빠르게 계산할수있음
        float remainingDistance = (transform.position - endPosition).sqrMagnitude;

        //float.Epsilon 0보다 크지만 가장 작은 양수 거의 0이라고 생각하면
        //좋음 사용하는 이유는 float가 설계상 반올림되어 원하는 값으로 계산이 안될경우가 발생할수 있기에 사용한다고 함
        while (remainingDistance > float.Epsilon)
        {
            if (targetTransform != null)
            {
                endPosition = targetTransform.position;
            }

            if (rigidBodyToMove != null) //Move메서드는 Rigidbody2D를 이용해 오브젝트를 이동시키므로 있는지 없는지 확인함
            {
                

                //MoveToWards메서드는 rigidbody2D의 움직임을 계산할때 사용한다. 이 메서드는 현재 위치, 최종위치, 프레임 안에서 이동할 거리를 받는다.
                Vector3 newPosition = Vector3.MoveTowards(rigidBodyToMove.position, endPosition, speed * Time.deltaTime);

                rb2d.MovePosition(newPosition);

                remainingDistance = (transform.position - endPosition).sqrMagnitude;
            }

            yield return new WaitForFixedUpdate();
        }
        isMove = true;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //몬스터의 범위안에 플레이어가 들어오면
        if (collision.gameObject.CompareTag("Player") && followPlayer)
        {
            //속도를 추적속도로 바꿈
            currentSpeed = pursuitSpeed;

            targetTransform = collision.gameObject.transform;
            if (moveCoroutine != null)
            {
                //원래 실행중인 코루틴중지
                StopCoroutine(moveCoroutine);
            }
            //새로운 속도를 적용한 코루틴 실행
            moveCoroutine = StartCoroutine(Move(rb2d, currentSpeed));
            
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //플레이어가 범위를 벗어나면
        if (collision.gameObject.CompareTag("Player"))
        {
            //속도를 평속도로 바꿈
            currentSpeed = wanderSpeed;

            targetTransform = collision.gameObject.transform;

            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }

            targetTransform = null;
            
        }
    }

    private void OnDrawGizmos()
    {
        if (circleCollider != null)
        {
            //에디터에서 서클콜라이더를 표현해줌
            Gizmos.DrawWireSphere(transform.position, circleCollider.radius);
        }
    }

    public void OnDamaged()
    {
        
        //대미지를 입으면 투명도를 변화
        Renderer.color = new Color(1, 1, 1, 0.4f);
        //뒤집어줌
        Renderer.flipY = true;
        //추적을 멈추기위해 서클콜라이더 비활성화
        circleCollider.enabled = false;
        //무적상태를 주기위해 박스콜라이더 비활성화
        boxCollider.enabled = false;
        //레이어도 바꿔줌
        gameObject.layer = 9;
        //맞으면 멈추게 하기위해서 릿지드바디 스태틱(정적)으로 바꿔줌
        rb2d.bodyType = RigidbodyType2D.Static;
        //3초뒤 offDamaged 호출
        Invoke("offDamaged", 3f);
    }

    public void offDamaged()
    {
        
        //데미지 판정이 끝났으므로 투명도 정상화
        Renderer.color = new Color(1, 1, 1, 1f);
        //다시 뒤집어줌
        Renderer.flipY = false;
        //레이어도 다시원상복구
        gameObject.layer = 0;
        //콜라이더들 다시 활성화
        boxCollider.enabled = true;
        circleCollider.enabled = true;
        //릿지드바디도 Dynamic(동적)으로
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        
        

    }


}
