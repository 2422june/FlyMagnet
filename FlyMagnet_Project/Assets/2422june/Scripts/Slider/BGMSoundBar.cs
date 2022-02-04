using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BGMSoundBar : MonoBehaviour
{
    public bool isOpenOption;
    Slider my;

    // Start is called before the first frame update
    void Start()
    {
        my = GetComponent<Slider>();
    }

    private void Update()
    {
        if (isOpenOption)
        {
            my.value = GameManager.GM.BGMvolum;
            isOpenOption = false;
        }
        else
        {
            return;
        }

    }

    public void SetBGM()
    {
        BGMManager.i.SetBGMVolume(my.value);
        PlayerPrefs.SetFloat("BGMvolum", GameManager.GM.BGMvolum);
    }
}
