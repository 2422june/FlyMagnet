using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDamaged : MonoBehaviour
{
    [Header("운석 데미지 상호작용")]

    [SerializeField] private int Damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            InGameManager.i.P_Hp -= Damage;
        }
    }
}
