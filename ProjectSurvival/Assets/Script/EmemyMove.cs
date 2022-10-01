using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyMove : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Vector2 direction;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 _dir)
    {
        //균일한 이동을 위해 정규화해줌
        direction = _dir.normalized;

    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(direction.x * speed * Time.fixedDeltaTime, rb2d.velocity.y);
    }
}
