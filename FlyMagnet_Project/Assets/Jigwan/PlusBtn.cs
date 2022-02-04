using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusBtn : MonoBehaviour
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
            player.e_PowerN = 1;
        }
        else
        {
            player.e_PowerN = 0;
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
