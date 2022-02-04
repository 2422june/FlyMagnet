using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLaser : MonoBehaviour
{
    [Header("레이저 오브젝트")]

    #region //Field
    [SerializeField] private GameObject laser_Object;

    [SerializeField] private float move_Speed;
    private Vector3 pos;
    #endregion

    void Update()
    {
        pos = Camera.main.WorldToViewportPoint(pos);

        if (pos.x < 0) Destroy(this.gameObject, 3f);
        else transform.position += new Vector3(1 * move_Speed * Time.deltaTime, 0, 0);
    }
}
