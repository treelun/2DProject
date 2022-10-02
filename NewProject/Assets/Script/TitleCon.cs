using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleCon : MonoBehaviour
{

    TMP_Text tmptext;
    // Start is called before the first frame update
    void Start()
    {
        tmptext = GetComponent<TMP_Text>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (tmptext != null)
        {
            StartCoroutine(TitleColor());
        }

        

    }
    IEnumerator TitleColor()
    {
        float ran1 = Random.Range(0, 256);
        float ran2 = Random.Range(0, 256);
        float ran3 = Random.Range(0, 256);
        tmptext.color = new Color32((byte)ran1, (byte)ran2, (byte)ran3, 255);
        yield return new WaitForSeconds(1f);
    }
}
