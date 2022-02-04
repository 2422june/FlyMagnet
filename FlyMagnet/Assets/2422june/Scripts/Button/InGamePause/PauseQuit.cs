using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseQuit : MonoBehaviour
{

    public void Click()
    {
        GameManager.GM.TruePause(false);
    }
}
