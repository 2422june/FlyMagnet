using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFade : MonoBehaviour
{

    public static PlayerFade i;

    private void Awake()
    {
        if(i == null)
        {
            i = this;
        }
    }
    [SerializeField]
    float time = 0;

    private bool isCanHited, nowHited, nowToLight;

    private SpriteRenderer mySPR;

    private void Start()
    {
        mySPR = GetComponent<SpriteRenderer>();
        isCanHited = true;
        nowHited = false;
        nowToLight = false;
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Default_Meteor") || collision.CompareTag("Shot_Meteor") || collision.CompareTag("Quick_Meteor"))
        {
            GetDamage(1);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Planet"))
        {
            GetDamage(2);
            Destroy(collision.gameObject);
        }
    }

    void GetDamage(int i)
    {
        if (isCanHited)
        {
            BGMManager.i.EFTPlay(BGMManager.effType.hited);
            //nowHited = true;
            StartCoroutine(Hited());
            InGameManager.i.P_Hp -= i;
            HpBar.i.SetHp();
            isCanHited = false;
            if (InGameManager.i.P_Hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void DestroyPlayer()
    {
        InGameManager.i.P_Hp = 0;
        if (InGameManager.i.P_Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator Hited()
    {
        while (time < 4)
        {
            yield return null;
            Color changeColor = mySPR.color;
            if (nowToLight)
            {
                changeColor.r += 2 * Time.deltaTime;
                changeColor.b = changeColor.r;
                changeColor.g = changeColor.r;

                if (changeColor.r >= 1)
                {
                    changeColor.r = 1;
                    changeColor.b = changeColor.r;
                    changeColor.g = changeColor.r;
                    nowToLight = !nowToLight;
                }
            }
            else
            {
                changeColor.r -= 2 * Time.deltaTime;
                changeColor.b = changeColor.r;
                changeColor.g = changeColor.r;

                if (changeColor.r < 0)
                {
                    changeColor.r = 0;
                    changeColor.b = changeColor.r;
                    changeColor.g = changeColor.r;
                    nowToLight = !nowToLight;
                }
            }
            mySPR.color = changeColor;
            time += Time.deltaTime;
        }

        time = 0;
        mySPR.color = new Color(1, 1, 1);
        nowToLight = false;
        isCanHited = true;
        yield break;
    }
}
