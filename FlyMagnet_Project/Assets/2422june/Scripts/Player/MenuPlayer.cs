using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayer : MonoBehaviour
{
    float speed;
    Vector3 up, down;
    bool nowUp;

    // Start is called before the first frame update
    void Start()
    {
        nowUp = true;
        up = new Vector3(transform.position.x, 0, 0);
        down = new Vector3(transform.position.x, -300, 0);
        speed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (nowUp)
        {
            transform.Translate((up - transform.position) * Time.deltaTime);
            if((up + transform.position).y >= -20)
            {
                nowUp = !nowUp;
            }
        }
        else
        {
            transform.Translate((down - transform.position) * Time.deltaTime);
            if((down - transform.position).y > -20)
            {
                nowUp = !nowUp;
            }
        }
    }
}
