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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //������ �����ȿ� �÷��̾ ������
        if (collision.gameObject.CompareTag("Player") && followPlayer)
        {
            //�ӵ��� �����ӵ��� �ٲ�
            currentSpeed = pursuitSpeed;

            targetTransform = collision.gameObject.transform;
            if (moveCoroutine != null)
            {
                //���� �������� �ڷ�ƾ����
                StopCoroutine(moveCoroutine);
            }
            //���ο� �ӵ��� ������ �ڷ�ƾ ����
            moveCoroutine = StartCoroutine(Move(rb2d, currentSpeed));
            
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //�÷��̾ ������ �����
        if (collision.gameObject.CompareTag("Player"))
        {
            //�ӵ��� ��ӵ��� �ٲ�
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
            //�����Ϳ��� ��Ŭ�ݶ��̴��� ǥ������
            Gizmos.DrawWireSphere(transform.position, circleCollider.radius);
        }
    }

    public void OnDamaged()
    {
        
        //������� ������ ������ ��ȭ
        Renderer.color = new Color(1, 1, 1, 0.4f);
        //��������
        Renderer.flipY = true;
        //������ ���߱����� ��Ŭ�ݶ��̴� ��Ȱ��ȭ
        circleCollider.enabled = false;
        //�������¸� �ֱ����� �ڽ��ݶ��̴� ��Ȱ��ȭ
        boxCollider.enabled = false;
        //���̾ �ٲ���
        gameObject.layer = 9;
        //������ ���߰� �ϱ����ؼ� ������ٵ� ����ƽ(����)���� �ٲ���
        rb2d.bodyType = RigidbodyType2D.Static;
        //3�ʵ� offDamaged ȣ��
        Invoke("offDamaged", 3f);
    }

    public void offDamaged()
    {
        
        //������ ������ �������Ƿ� ���� ����ȭ
        Renderer.color = new Color(1, 1, 1, 1f);
        //�ٽ� ��������
        Renderer.flipY = false;
        //���̾ �ٽÿ��󺹱�
        gameObject.layer = 0;
        //�ݶ��̴��� �ٽ� Ȱ��ȭ
        boxCollider.enabled = true;
        circleCollider.enabled = true;
        //������ٵ� Dynamic(����)����
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        
        

    }


}
