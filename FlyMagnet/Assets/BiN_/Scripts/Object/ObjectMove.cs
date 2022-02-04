using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [Header("������Ʈ �̵� ��ũ��Ʈ")]

    [Tooltip ("�̵� �ӵ�")]
    [SerializeField] private float move_Speed;

    private Vector3 pos;
    
    private void Update()
    {
        transform.position += new Vector3(-1 * move_Speed * Time.deltaTime * InGameManager.i.timeScale, 0, 0);

        pos = Camera.main.WorldToViewportPoint(transform.position);
        
        if (pos.x < 0f)
           Destroy(this.gameObject);

    }

}
