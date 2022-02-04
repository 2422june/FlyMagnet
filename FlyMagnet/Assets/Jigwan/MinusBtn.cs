using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusBtn : MonoBehaviour
{
    PlayerMovement player;

    bool isBtn;

    void Start()
    {
        player = PlayerMovement.i;
    }

    void Update()
    {
        if (isBtn)
        {
            player.e_PowerS = -1;
        }
        else
        {
            player.e_PowerS = 0;
        }
    }

    public void OnPointerDown()
    {
        isBtn = true;
    }

    public void OnPointerUp()
    {
        isBtn = false;
    }
}
