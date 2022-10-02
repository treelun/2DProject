using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragAndDrop : MonoBehaviour
{
    public Vector3 LoadedPos;

    float startPosx;
    float startPosY;
    bool isBeingheld = false;

    public bool isPoint;
    float DroptablePosY;
    
    // Start is called before the first frame update
    void Start()
    {
        LoadedPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingheld)
        {
            Vector2 mousePos;
            //Vector2로 카메라 화면의 마우스위치를 월드 포인트로 가져옴
            //ScreenToWorldPoint는 카메라(Camera)가 비추고 있는 화면(Screen)내의 좌표값을 사용할 수 있게 해준다.

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            this.gameObject.transform.position = new Vector2(mousePos.x - startPosx, mousePos.y - startPosY);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            startPosx = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

            isBeingheld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingheld = false;

        if (isPoint)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.localPosition.x, DroptablePosY, -1f);
        }
        else
        {
            this.gameObject.transform.position = LoadedPos;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Table")
        {
            Debug.Log(collision.transform.tag);
            isPoint = true;
            DroptablePosY = collision.transform.position.y;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Table")
        {
            Debug.Log(collision.transform.tag);
            isPoint = false;
        }
        Debug.Log(isPoint);

    }
}
