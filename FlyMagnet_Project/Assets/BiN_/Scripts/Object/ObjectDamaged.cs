using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDamaged : MonoBehaviour
{
    [Header("� ������ ��ȣ�ۿ�")]

    [SerializeField] private int Damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            InGameManager.i.P_Hp -= Damage;
        }
    }
}
