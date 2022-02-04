using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Scene
    {
        title, menu, inGame, tutorial
    };

    public Scene nowScene;

    public bool isTrueOption, isTrueGameOver, isTruePause, isTrueLicence;

    GameObject optionView;
    GameObject gameOverView;
    GameObject pauseView;
    GameObject GameQuit;
    GameObject LicenceView;


    public int TScore1, TScore2, TScore3, coin;

    public float BGMvolum, EFTvolum;

    [SerializeField]
    GameObject BGMsoundSlider, EFTsoundSlider, scoreBoard;

    [SerializeField]
    Text tScore, Ts1, Ts2, Ts3;

    public static GameManager GM;

    void Awake()
    {
        if(GM == null)
        {
            nowScene = Scene.title;
            GM = this;
            isTrueOption = false;
            isTrueGameOver = false;
            isTruePause = false;
            isTrueLicence = false;

            BGMvolum = 20f / 100f;
            EFTvolum = 60f / 100f;

            TScore1 = 0;
            TScore2 = 0;
            TScore3 = 0;

            coin = 0;

            if (PlayerPrefs.HasKey("1TopScore"))
            {
                TScore1 = PlayerPrefs.GetInt("1TopScore");
                TScore2 = PlayerPrefs.GetInt("2TopScore");
                TScore3 = PlayerPrefs.GetInt("3TopScore");
            }
            else
            {
                PlayerPrefs.SetInt("1TopScore", TScore1);
                PlayerPrefs.SetInt("2TopScore", TScore2);
                PlayerPrefs.SetInt("3TopScore", TScore3);
            }

            if (PlayerPrefs.HasKey("Coin"))
            {
                coin = PlayerPrefs.GetInt("Coin");
            }
            else
            {
                PlayerPrefs.SetInt("Coin", coin);
            }

            if (PlayerPrefs.HasKey("BGMvolum"))
            {
                BGMvolum = PlayerPrefs.GetFloat("BGMvolum");
                EFTvolum = PlayerPrefs.GetFloat("EFTvolum");
            }
            else
            {
                PlayerPrefs.SetFloat("EFTvolum", EFTvolum);
                PlayerPrefs.SetFloat("BGMvolum", BGMvolum);
            }

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        optionView = GameObject.Find("OptionView");
        LicenceView = GameObject.Find("LicenceView");
        gameOverView = GameObject.Find("GamrOverLabel");
        pauseView = GameObject.Find("Pause");
        GameQuit = GameObject.Find("GameQuit");
        //DontDestroyOnLoad(optionView.gameObject);
        optionView.SetActive(isTrueOption);
        pauseView.SetActive(isTruePause);
        gameOverView.SetActive(isTrueGameOver);
        LicenceView.SetActive(isTrueLicence);
    }

    public void TrueOption(bool isOn)
    {
        if (isTrueOption != isOn)
        {
            if (isOn)
            {
                EFTsoundSlider.GetComponent<EFTSoundBar>().isOpenOption = true;
                BGMsoundSlider.GetComponent<BGMSoundBar>().isOpenOption = true;
            }
            BGMManager.i.EFTPlay(BGMManager.effType.normal);
            isTrueOption = isOn;
            optionView.SetActive(isTrueOption);

            GameQuit.SetActive((nowScene != Scene.inGame) && (nowScene != Scene.tutorial));

        }
    }

    public void TrueLicence(bool isOn)
    {
        if (isTrueLicence != isOn)
        {
            BGMManager.i.EFTPlay(BGMManager.effType.normal);
            isTrueLicence = isOn;
            LicenceView.SetActive(isTrueLicence);
        }
    }

    public void TruePause(bool isOn)
    {
        if (isTruePause != isOn)
        {
            if (isOn)
            {
                InGameManager.i.timeScale = 0;
            }
            else
            {
                InGameManager.i.timeScale = 1;
            }
            BGMManager.i.EFTPlay(BGMManager.effType.normal);
            isTruePause = isOn;
            pauseView.SetActive(isTruePause);
        }
    }

    public void TrueGameOver(bool isOn)
    {
        //BGMManager.i.BgmPause();
        Fade.i.SetFade(0.5f, false);
        isTrueGameOver = isOn;
        gameOverView.SetActive(isTrueGameOver);
        tScore.text = "Score: " + InGameManager.i.score.ToString();
        if (isOn)
        {
            if(nowScene == Scene.inGame)
            {
                coin += InGameManager.i.coin;
                PlayerPrefs.SetInt("Coin", coin);
            }

            Save();
        }
            
        Fade.i.OffFade();
    }

    public void SetScene(Scene value)
    {
        Fade.i.SetFade(0.5f, false);

        if (nowScene != Scene.title && value == Scene.menu)
            BGMManager.i.BGMPlay(BGMManager.bgmType.title);

        nowScene = value;
        InGameManager.i.enabled = false;
        scoreBoard.SetActive(false);
        switch (nowScene)
        {
            case Scene.menu:

                scoreBoard.SetActive(true);

                Ts1.text = "1: " + PlayerPrefs.GetInt("1TopScore").ToString();
                Ts2.text = "2: " + PlayerPrefs.GetInt("2TopScore").ToString();
                Ts3.text = "3: " + PlayerPrefs.GetInt("3TopScore").ToString();
                break;

            case Scene.inGame:
                InGameManager.i.enabled = true;
                InGameManager.i.isEndPattern = true;
                InGameManager.i.score = 0;
                InGameManager.i.timer = 0;
                InGameManager.i.P_Hp = 5;
                InGameManager.i.timeScale = 1;
                BGMManager.i.BGMPlay(BGMManager.bgmType.inGame1);
                break;

            case Scene.tutorial:
                InGameManager.i.timeScale = 1;
                InGameManager.i.enabled = true;
                InGameManager.i.isEndPattern = true;
                InGameManager.i.score = 0;
                InGameManager.i.timer = 0;
                InGameManager.i.P_Hp = 5;
                BGMManager.i.BGMPlay(BGMManager.bgmType.inGame1);
                break;
        }
        SceneManager.LoadScene((int)nowScene);
        Fade.i.OffFade();
    }

    public void Save()
    {
        if (InGameManager.i.score > TScore1)
        {
            TScore3 = TScore2;
            PlayerPrefs.SetInt("3TopScore", TScore3);

            TScore2 = TScore1;
            PlayerPrefs.SetInt("2TopScore", TScore2);

            TScore1 = InGameManager.i.score;
            PlayerPrefs.SetInt("1TopScore", TScore1);

        }
        else if (InGameManager.i.score > TScore2)
        {
            TScore3 = TScore2;
            PlayerPrefs.SetInt("3TopScore", TScore3);

            TScore2 = InGameManager.i.score;
            PlayerPrefs.SetInt("2TopScore", TScore2);
        }
        else if (InGameManager.i.score < TScore2 && InGameManager.i.score > TScore3)
        {
            TScore3 = InGameManager.i.score;
            PlayerPrefs.SetInt("3TopScore", TScore3);
        }

        //Debug.Log(PlayerPrefs.GetInt("1TopScore") + " " + PlayerPrefs.GetInt("2TopScore") + " " + PlayerPrefs.GetInt("3TopScore"));
    }
}
