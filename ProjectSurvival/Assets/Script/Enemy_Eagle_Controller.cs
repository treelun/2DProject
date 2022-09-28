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
        //sqrMagnitude�� ������ġ�� ������ ������ �뷫���� �Ÿ��� ���� ũ�⸦ ������ ����Ҽ�����
        float remainingDistance = (transform.position - endPosition).sqrMagnitude;

        //float.Epsilon 0���� ũ���� ���� ���� ��� ���� 0�̶�� �����ϸ�
        //���� ����ϴ� ������ float�� ����� �ݿø��Ǿ� ���ϴ� ������ ����� �ȵɰ�찡 �߻��Ҽ� �ֱ⿡ ����Ѵٰ� ��
        while (remainingDistance > float.Epsilon)
        {
            if (targetTransform != null)
            {
                endPosition = targetTransform.position;
            }

            if (rigidBodyToMove != null) //Move�޼���� Rigidbody2D�� �̿��� ������Ʈ�� �̵���Ű�Ƿ� �ִ��� ������ Ȯ����
            {
                

                //MoveToWards�޼���� rigidbody2D�� �������� ����Ҷ� ����Ѵ�. �� �޼���� ���� ��ġ, ������ġ, ������ �ȿ��� �̵��� �Ÿ��� �޴´�.
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
