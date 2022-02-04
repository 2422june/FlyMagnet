using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Vector3 position;
    public float speed = 5f;
    void Start()
    {
        position = transform.position;
        if (GameManager.GM.nowScene == GameManager.Scene.menu || GameManager.GM.nowScene == GameManager.Scene.title)
        {
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        position.x += -1*speed * Time.deltaTime * InGameManager.i.timeScale;
        transform.position = position;
    }

}
