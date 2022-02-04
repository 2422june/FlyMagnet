using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public float speed;
    public RectTransform[] backgrounds;
 
    float leftPosX = 0f;
    float rightPosX = 0f;
    float xScreenHalfSize;
    float yScreenHalfSize;
    void Start()
    {
        speed = 200;

        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        leftPosX = -(xScreenHalfSize * 2);
        rightPosX = xScreenHalfSize * 2 * backgrounds.Length;
    }



    void FixedUpdate()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].localPosition += new Vector3(-speed, 0, 0) * Time.deltaTime;

            if (backgrounds[i].localPosition.x <= -1920)//-26.5f)
            {
                //Vector3 nextPos = backgrounds[i].position;

                //nextPos = new Vector3(30.96f, nextPos.y, nextPos.z);
                //backgrounds[i].position = nextPos;

                //nextPos = new Vector3(-7.3f, nextPos.y, nextPos.z);
                //backgrounds[(i + 1) % backgrounds.Length].position = nextPos;

                //nextPos = new Vector3(11.89f, nextPos.y, nextPos.z);
                //backgrounds[(i + 2) % backgrounds.Length].position = nextPos;


                Vector3 nextPos = backgrounds[i].localPosition;
                nextPos = new Vector3(1920, nextPos.y, nextPos.z);

                backgrounds[i].localPosition = nextPos;
            }
        }
    }



}
