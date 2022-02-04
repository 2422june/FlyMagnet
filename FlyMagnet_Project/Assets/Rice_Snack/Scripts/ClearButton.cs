using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearButton : MonoBehaviour
{
    public void Tutial_Clear()
    {
        InGameManager.i.timeScale = 1;
        GameManager.GM.SetScene(GameManager.Scene.menu);
        
    }
}
