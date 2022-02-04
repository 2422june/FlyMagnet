using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShotMove : MonoBehaviour
{
    [Header("산탄 오브젝트 이동")]

    [SerializeField] private float object_Speed; 

    void Update()
    {
        transform.Translate(1 * object_Speed * Time.deltaTime, 0, 0);
    }
}
