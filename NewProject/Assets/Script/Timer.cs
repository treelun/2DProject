using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    float time = 0f;
    public bool isNextday = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //타이머임
        time += Time.deltaTime;
        gameObject.GetComponent<TextMeshProUGUI>().text = time.ToString();
        if (time > 10)
        {
            isNextday = true;

            
        }
    }
}
