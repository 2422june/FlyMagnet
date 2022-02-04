using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager i;

    private void Awake()
    {
        if (i == null)
        {
            i = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public GameObject[] gimic;

    GameObject pattrn;

    public bool isEndPattern;
    public int P_Hp;
    public int score;
    public float timer;
    public int round;
    public int pattern_Timer;

    public float timeScale;

    public int value;
    public int coin;
    public int coinS = 10;


    // Start is called before the first frame update
    void Start()
    {
        ALLDestroy();
        score = 0;
        value = 0;
        round = 0;
        P_Hp = 5;
    }

    void ALLDestroy()
    {
        if (pattrn != null)
        {
            Destroy(pattrn.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        pattern_Timer = (int)timer;
        if (GameManager.GM.nowScene == GameManager.Scene.inGame)
        {
            timer += Time.deltaTime * timeScale;

            score = (int)(timer) + value;
        }

        #region 积己 俊府绢
        if (round == (score % 10))
        {
            isEndPattern = false;
            round++;
            //积己
        }
        #endregion

        if (P_Hp <= 0)
        {
            BGMManager.i.EFTPlay(BGMManager.effType.boom);
            ALLDestroy();
            GameManager.GM.TrueGameOver(true);
            P_Hp = 1;
            timeScale = 0;
        }
    }
}
