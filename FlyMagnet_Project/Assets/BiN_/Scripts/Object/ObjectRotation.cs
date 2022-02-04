using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [Header("오브젝트 회전")]
    [SerializeField] private float rotation_Speed;

    void Update()
    {
        transform.Rotate(0, 0, 1 * rotation_Speed * Time.deltaTime);
    }
}
