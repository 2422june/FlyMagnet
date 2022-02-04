using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ReGame : MonoBehaviour
{
    [SerializeField]
    Text ReGameTxt;

    [SerializeField]
    Color txtColor;

    [SerializeField]
    bool nowToLight;

    bool isClick;

    private void Start()
    {
        isClick = false;
        nowToLight = false;
        txtColor = ReGameTxt.color;
    }

    private void Update()
    {
        if (!isClick)
        {
            if (nowToLight)
            {
                if (txtColor.a < 1)
                {
                    txtColor.a += (160 / 255f) * Time.deltaTime;
                }
                else
                {
                    nowToLight = false;
                }
            }
            else
            {
                if (txtColor.a > (160 / 255f))
                {
                    txtColor.a -= (160 / 255f) * Time.deltaTime;
                }
                else
                {
                    nowToLight = true;
                }
            }

            ReGameTxt.color = txtColor;
        }
        else
        {
            if (txtColor.a > 0)
            {
                txtColor.a -= Time.deltaTime;
                ReGameTxt.color = txtColor;
            }
            else
            {
                GameManager.GM.SetScene(GameManager.Scene.menu);
                GameManager.GM.TrueGameOver(false);
                isClick = false;
            }
        }

    }

    public void Click()
    {
        if (!isClick)
        {
            isClick = true;
            BGMManager.i.EFTPlay(BGMManager.effType.title);
        }
    }
}
