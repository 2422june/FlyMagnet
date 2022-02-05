using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    public static HpBar i;

    private void Awake()
    {
        if(i == null)
        {
            i = this;
        }
        else
        {
            Destroy(this);
        }
    }

    [SerializeField]
    GameObject Player;

    [SerializeField]
    Slider mySlider;

    private void Start()
    {
        InGameManager.i.P_Hp = 5;
        mySlider.value = InGameManager.i.P_Hp;
    }

    public void SetHp()
    {
        mySlider.value = InGameManager.i.P_Hp;
    }
}
