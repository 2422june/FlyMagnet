using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Tutorial : MonoBehaviour
{
    [SerializeField] GameObject clear;
    [SerializeField] Text Coin_text;
    // Start is called before the first frame update
    void Start()
    {
        TutialManager.TM.Texts.SetActive(true);
        TutialManager.TM.timeScale = false;
        Invoke("stopTime",1f);
    }

    void stopTime()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (TutialManager.TM.timeScale)
        {
            if (TutialManager.TM.Coin_Count == 15)
            {
                Coin_text.text = "<color=#00ff00>[ƒ⁄¿Œ¿ª " + TutialManager.TM.Coin_Count + "/15∞≥ »πµÊ«œººø‰]</color>";
            }
            else
            {
                Coin_text.text = "[ƒ⁄¿Œ¿ª " + TutialManager.TM.Coin_Count + "/15∞≥ »πµÊ«œººø‰]";
            }
            if (TutialManager.TM.Coin_Count == 15)
            {
                clear.SetActive(true);
                InGameManager.i.timeScale = 0;
                //Time.timeScale= 0f;
            }
        }
    }
}
