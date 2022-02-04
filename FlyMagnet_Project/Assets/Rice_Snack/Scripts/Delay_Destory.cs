using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay_Destory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestoryOn", 2.3f);   
    }

    void DestoryOn()
    {
        gameObject.GetComponent<Destory_Block>().enabled = true;
    }

}
