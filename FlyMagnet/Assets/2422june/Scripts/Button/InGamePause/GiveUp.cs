using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveUp : MonoBehaviour
{
    public void Click()
    {
        GameManager.GM.TruePause(false);
        PlayerFade.i.DestroyPlayer();
    }
}
