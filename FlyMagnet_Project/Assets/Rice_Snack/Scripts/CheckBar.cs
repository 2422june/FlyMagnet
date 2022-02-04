using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBar : MonoBehaviour
{
    public enum type
    {
        non, N, S
    };

    public type target;

    private void Start()
    {
        target = type.non;
    }

    public int GetTarget()
    {
        if (target == type.N)
        {
            return -1;
        }
        if (target == type.S)
        {
            return 1;
        }
        return 0;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "N")
        {
            target = type.N;
        }
        if (collision.gameObject.tag == "S")
        {
            target = type.S;
        }
    }
}
