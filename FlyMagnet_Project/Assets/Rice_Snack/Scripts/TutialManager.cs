using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutialManager : MonoBehaviour
{
    public static TutialManager TM;
    public int Coin_Count;
    public int text_Count = 0;
    public GameObject Texts;
    public bool timeScale;

    private void Awake()
    {
        if (TM == null)
        {
            TM = this;
        }
        Coin_Count = 0;
        timeScale = true;
    }
}
