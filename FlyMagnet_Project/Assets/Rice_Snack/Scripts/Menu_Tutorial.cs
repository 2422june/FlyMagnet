using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Menu_Tutorial : MonoBehaviour
{
    public void Move_Tutorial()
    {
        GameManager.GM.SetScene(GameManager.Scene.tutorial);
    }
}
