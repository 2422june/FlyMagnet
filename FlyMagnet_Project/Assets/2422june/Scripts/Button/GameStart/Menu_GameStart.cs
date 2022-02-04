using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click()
    {
        BGMManager.i.EFTPlay(BGMManager.effType.normal);
        GameManager.GM.SetScene(GameManager.Scene.inGame);
    }
}
