using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField]
    Text GameStartTxt;

    [SerializeField]
    Color txtColor;

    [SerializeField]
    bool nowToLight;

    bool isClick;

    private void Start()
    {
        isClick = false;
        nowToLight = false;
        txtColor = GameStartTxt.color;
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

            GameStartTxt.color = txtColor;
        }
        else
        {
            if (txtColor.a > 0)
            {
                txtColor.a -= Time.deltaTime;
                GameStartTxt.color = txtColor;
            }
            else
            {
                GameManager.GM.SetScene(GameManager.Scene.menu);
                //GameManager.GM.TrueGameOver(false);
            }
        }
        
    }

    // Start is called before the first frame update
    public void Click()
    {
        if (!isClick)
        {
            isClick = true;
            BGMManager.i.EFTPlay(BGMManager.effType.title);
        }
    }
}
