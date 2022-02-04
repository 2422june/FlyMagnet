using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    Transform target;
    [SerializeField] float speed;
    [SerializeField] float distance;

    public bool isMagnet;

    public static Magnet M;

    void Start()
    {
        isMagnet = false;
        target = PlayerMovement.i.GetComponent<Transform>();    
    }

    void Update()
    {
        if (isMagnet && Vector2.Distance(transform.position, target.position) > distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void OffisMagnet()
    {
        isMagnet = false;
    }
}
