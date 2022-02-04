using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EFTSoundBar : MonoBehaviour
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
            my.value = GameManager.GM.EFTvolum;
            isOpenOption = false;
        }
        else
        {
            return;
        }

    }
    public void SetEFT()
    {
        BGMManager.i.SetEftVolume(my.value);
        PlayerPrefs.SetFloat("EFTvolum", GameManager.GM.EFTvolum);
    }
}
