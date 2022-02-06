using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed; // �⺻ �ӵ�
    public float e_Power; // ���Ϸ�
    public int electricCharge; // ����

    public int e_PowerN; // N ���Ϸ�
    public int e_PowerS; // S ���Ϸ�

    [SerializeField]
    Sprite[] P_sprite; // �÷��̾� ��������Ʈ

    [SerializeField]
    GameObject checkBar; // üũ��

    SpriteRenderer SPR;

    CheckBar mCheck; // �ڼ� üũ
    Magnet magnet;

    int checkPower; // ���� üũ

    Vector3 hpBarPos;

    public Rigidbody2D rigid;

    [SerializeField]
    Image NSImage;

    Image nsSource;

    [SerializeField]
    Sprite N, S, NS;

    float yVelocity = 2;

    public static PlayerMovement i;

    private void Awake()
    {
        if (i == null)
        {
            i = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        if (GameManager.GM.nowScene == GameManager.Scene.tutorial)
        {
            TutialManager.TM.Coin_Count = 0;
        }
        InGameManager.i.value = 0;
        InGameManager.i.coin = 0;

        speed = 450f;
        electricCharge = 0;

        rigid = GetComponent<Rigidbody2D>();
        SPR = GetComponent<SpriteRenderer>();
       // magnet = Magnet.M;
        checkBar = GameObject.Instantiate(checkBar) as GameObject;
        mCheck = checkBar.GetComponent<CheckBar>();
        nsSource = NSImage.GetComponent<Image>();
        checkBar.transform.position = new Vector3(i.transform.position.x - 90f, -400f, 0);
    }

    void Update()
    {
        // PC ���� �߼� ��ư
        if (Input.GetKey(KeyCode.Space))
            electricCharge = 0;

        if (e_PowerN != 0 || e_PowerS != 0)
            electricCharge = e_PowerN + e_PowerS; //now Player Magnetism

        // �÷��̾� ���� ��������Ʈ ��ȯ
        if (electricCharge == 1)
        {
            nsSource.sprite = S;
            SPR.sprite = P_sprite[0];
        }
        else if (electricCharge == -1)
        {
            nsSource.sprite = N;
            SPR.sprite = P_sprite[1];
        }
        else
        {
            nsSource.sprite = NS;
            SPR.sprite = P_sprite[2];
        }

        // �÷��̾� ����, �ڼ� ���� ��ġ ����
        checkPower = electricCharge * mCheck.GetTarget(); // ��ġ = 1, ����ġ = -1, �߼� = 0

        if (checkPower == 1)
        {
            float positionY = Mathf.SmoothDamp(transform.position.y, 260, ref yVelocity, 0.6f);
            transform.position = new Vector3(transform.position.x, positionY, 0);

            //if (transform.position.y < 260)
            //{
            //    transform.Translate(0, speed * Time.deltaTime, 0);
            //}
            //else
            //{
            //    transform.position = new Vector3(transform.position.x, 260, 0);
            //}
        }
        else if (checkPower == -1)
        {
            float positionY = Mathf.SmoothDamp(transform.position.y, -260, ref yVelocity, 0.6f);
            transform.position = new Vector3(transform.position.x, positionY, 0);

            //if (transform.position.y > -260)
            //{
            //    transform.Translate(0, -1 * speed * Time.deltaTime, 0);
            //}
            //else
            //{
            //    transform.position = new Vector3(transform.position.x, -260, 0);
            //}
        }
        else if (checkPower == 0)
        {
            float positionY = Mathf.SmoothDamp(transform.position.y, 0, ref yVelocity, 0.4f);
            transform.position = new Vector3(transform.position.x, positionY, 0);

            //if (transform.position.y < -0.5f)
            //{
            //    transform.Translate(0, 1 * speed * Time.deltaTime, 0);
            //}
            //else if (transform.position.y > 0.5f)
            //{
            //    transform.Translate(0, -1 * speed * Time.deltaTime, 0);
            //}
            //else
            //{
            //    transform.position = new Vector3(transform.position.x, 0, 0);
            //}
        }


        Vector3 pos = transform.position;
        pos.y += 60;
        //pos.y /= 450f;
        //pos.x /= 800f;
        HpBar.i.transform.localPosition = pos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            BGMManager.i.EFTPlay(BGMManager.effType.coin);
            InGameManager.i.value += InGameManager.i.coinS;
            InGameManager.i.coin++;

            if (GameManager.GM.nowScene == GameManager.Scene.tutorial)
            {
                TutialManager.TM.Coin_Count++;
                if (TutialManager.TM.Coin_Count >= 15)
                {
                    TutialManager.TM.Coin_Count = 15;
                }
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Heal"))
        {
            BGMManager.i.EFTPlay(BGMManager.effType.heal);
            if(InGameManager.i.P_Hp < 5)
            {
                InGameManager.i.P_Hp++;
                HpBar.i.SetHp();
            }
            Destroy(collision.gameObject);
        }
    }
}