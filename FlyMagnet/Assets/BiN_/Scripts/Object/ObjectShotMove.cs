using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShotMove : MonoBehaviour
{
    [Header("��ź ������Ʈ �̵�")]

    [SerializeField] private float object_Speed; 

    void Update()
    {
        transform.Translate(1 * object_Speed * Time.deltaTime, 0, 0);
    }
}
