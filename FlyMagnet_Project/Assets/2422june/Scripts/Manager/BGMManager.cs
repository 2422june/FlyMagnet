using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    #region SetSingleTon
    public static BGMManager i;

    private void Awake()
    {
        if(i == null)
        {
            i = this;
            BGMManager.i.BGMOnLoop(true);
        }
    }
    #endregion

    #region field
    public enum bgmType
    {
        title, inGame1
    };
    public enum effType
    {
        title, normal, hited, coin, heal, boom
    };

    [SerializeField]
    List<AudioClip> BGM = new List<AudioClip>();

    [SerializeField]
    List<AudioClip> EFF = new List<AudioClip>();

    [SerializeField]
    private AudioSource BgmPlayer;

    [SerializeField]
    private AudioSource EffPlayer;

    //public float BGMvolum, EFTvolum;
    #endregion

    private void Start()
    {
        BgmPlayer.Stop();
        EffPlayer.Stop();

        if(GameManager.GM.nowScene == GameManager.Scene.title)
        {
            SetBGMVolume(GameManager.GM.BGMvolum);
            SetEftVolume(GameManager.GM.EFTvolum);
            BGMPlay(BGMManager.bgmType.title);
        }
    }

    #region Function
    public void BGMPlay(bgmType type)
    {
        BgmPlayer.clip = BGM[(int)type];
        BgmPlayer.Play();
    }

    public void EFTPlay(effType type)
    {
        EffPlayer.clip = EFF[(int)type];
        EffPlayer.Play();
    }

    public void BgmPause()
    {
        BgmPlayer.Pause();
    }

    public void BGMOnLoop(bool isOn)
    {
        BgmPlayer.loop = isOn;
    }

    public void SetBGMVolume(float _volume)
    {
        GameManager.GM.BGMvolum = _volume;
        BgmPlayer.volume = _volume;
    }

    public void SetEftVolume(float _volume)
    {
        GameManager.GM.EFTvolum = _volume;
        EffPlayer.volume = _volume;
    }
    #endregion
}
