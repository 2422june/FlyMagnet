using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Fade : MonoBehaviour
{
    #region SetSingleton
    public static Fade i;
    private void Awake()
    {
        if(i == null)
        {
            i = this;
        }
    }
    #endregion

    #region field

        private Image color;

        [SerializeField]
        float time;

        private bool nowToLight, immediately;

    [SerializeField]
    GameObject fadeImage;

    #endregion

    void Start()
    {
        color = fadeImage.GetComponentInChildren<Image>();
        nowToLight = false;
        immediately = false;
        fadeImage.SetActive(false);
        time = 0;
    }

    public void SetFade(float _time, bool _immediately)
    {
        time = _time;
        nowToLight = false;
        immediately = _immediately;
        fadeImage.SetActive(true);
        color.color = new Color(0, 0, 0, 1);
        OnFade();
    }

    public void OnFade()
    {
        StartCoroutine(On());
    }

    public void OffFade()
    {
        StartCoroutine(Off());
    }

    IEnumerator On()
    {
        while (true)
        {
            yield return null;
            Color changeColor = color.color;
            //if (nowToLight)
            //{
                changeColor.a += (1f / time) * Time.deltaTime;

                if (changeColor.a >= 1)
                {
                    changeColor.a = 1;
                    //nowToLight = !nowToLight;
                    break;
                }
            //}
            color.color = changeColor;
        }
        if (immediately)
        {
            OffFade();
        }
        yield break;
    }

    IEnumerator Off()
    {
        while (true)
        {
            yield return null;
            Color changeColor = color.color;
            
            changeColor.a -= (1f / time) * Time.deltaTime;

            if (changeColor.a <= 0)
            {
                changeColor.a = 0;
                //nowToLight = !nowToLight;
                break;
            }

            color.color = changeColor;
            //timer += Time.deltaTime;
        }

        fadeImage.SetActive(false);
        yield break;
    }
}
