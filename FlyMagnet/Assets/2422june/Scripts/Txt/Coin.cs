using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{

    [SerializeField]
    Text coin;

    void Start()
    {
        coin = GetComponent<Text>();
    }

    void Update()
    {
        if (GameManager.GM.nowScene == GameManager.Scene.inGame || GameManager.GM.nowScene == GameManager.Scene.tutorial)
        {
            coin.text = ": " + InGameManager.i.coin.ToString();
        }

        if (GameManager.GM.nowScene == GameManager.Scene.menu)
        {
            coin.text = ": " + GameManager.GM.coin.ToString();
        }
    }
}
