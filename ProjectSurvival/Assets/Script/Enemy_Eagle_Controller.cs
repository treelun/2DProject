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
        isMove = true;


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

    public void OnDamaged()
    {
        
        
        Renderer.color = new Color(1, 1, 1, 0.4f);

        Renderer.flipY = true;
        circleCollider.enabled = false;
        boxCollider.enabled = false;
        gameObject.layer = 9;
        rb2d.bodyType = RigidbodyType2D.Static;
        Invoke("offDamaged", 3f);
    }

    public void offDamaged()
    {
        

        Renderer.color = new Color(1, 1, 1, 1f);

        Renderer.flipY = false;
        gameObject.layer = 0;
        boxCollider.enabled = true;
        circleCollider.enabled = true;
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        
        

    }

    void DeActive()        
    {
        gameObject.SetActive(false);
    }

}
