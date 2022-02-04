using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjecetShot : MonoBehaviour
{
    [Header("오브젝트가 산탄하며 퍼짐")]

    #region //Field
    [SerializeField] private GameObject shot_Object;
    #endregion
    
    private void Start()
    {
        Invoke("Shot", 3f);
    }

    private void Shot()
    {
        for(int i = -220; i <= -140; i += 20)
        {
            GameObject temp = Instantiate(shot_Object.gameObject);
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
            temp.transform.position = transform.position;
            
            Destroy(temp.gameObject, 2f);   
        }

        Destroy(this.gameObject);
    }
}
