using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial: MonoBehaviour
{
    [SerializeField] Text text;
    [Multiline(3)]
    [SerializeField] string[] text_String;
    public void Talk_Tutorial()
    {
        if (TutialManager.TM.text_Count >= 11)
        {
            TutialManager.TM.timeScale = true;
            TutialManager.TM.Texts.SetActive(false);
            InGameManager.i.timeScale = 1;
            Time.timeScale = 1f;
        }
        else
        {
            BGMManager.i.EFTPlay(BGMManager.effType.normal);
            text.text = text_String[TutialManager.TM.text_Count];
            TutialManager.TM.text_Count++;
            InGameManager.i.timeScale = 0;
        }

    }
}