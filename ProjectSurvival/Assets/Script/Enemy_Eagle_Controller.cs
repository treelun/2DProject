using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    Vector2 direction;

    float currentAngle = 0;
    CircleCollider2D circleCollider;

    


    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = wanderSpeed;

        rb2d = GetComponent<Rigidbody2D>();
        
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(rb2d.position, endPosition, Color.red);
        Debug.Log(targetTransform);
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

       
    }


/*    void ChooseNewEndPoint()
    {
        currentAngle += Random.Range(40, 50);


        currentAngle = Mathf.Repeat(currentAngle, 40);

        endPosition = Vector3FromAngle(currentAngle);
    }*/

/*    Vector3 Vector3FromAngle(float inputAngleDegrees)
    {
        float inputAngleRadians = inputAngleDegrees * Mathf.Deg2Rad;

        return new Vector3(Mathf.Cos(inputAngleRadians), Mathf.Sin(inputAngleRadians), 0);
    }*/



    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.CompareTag("Player") && followPlayer)
        {
            currentSpeed = pursuitSpeed;

            targetTransform = collision.gameObject.transform;

            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }

            moveCoroutine = StartCoroutine(Move(rb2d, currentSpeed));
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
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
            Gizmos.DrawWireSphere(transform.position, circleCollider.radius);
        }
    }

}
