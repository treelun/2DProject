using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharatorManager
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Eagle")
        {

        }
    }




}
