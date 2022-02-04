using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatternManager : MonoBehaviour
{
    #region //Singleton
    public static PatternManager instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    #region //Field

    [Header("배열방을 랜덤으로 지정해줄 index 변수")]
    public int Index = 0;

    private GameObject temp;        //프리팹을 temp 오브젝트의 생성 시키기 위한 게임 오브젝트

    public bool isPattern = true;       //패턴의 활성화 비활성화 상태를 체크할 bool 변수
    public int Count = 0;               //패턴이 몇번 생성 되었는지 체크할 변수
    public int item_Index;

    [Header("생성시킬 아이템 오브젝트")]
    public GameObject[] item_Object;

    [Header("패턴을 담을 배열")]
    [SerializeField] private GameObject[] pattern_Manager;

    

    [Header("패턴의 좌표값을 담을 배열")]
    public float [] pattern_Position;
    private float Timer = 0;
    #endregion

    private void Update()
    {
        if (InGameManager.i.pattern_Timer % 30 == 0 && isPattern && Count > 0)       //60점 단위로 패턴을 생성시킴
        {
            if(InGameManager.i.pattern_Timer >= 30f)
            {
                temp = Instantiate(pattern_Manager[Index % pattern_Manager.Length], Vector2.zero, Quaternion.identity);   //배열방 안에 있는 패턴을 생성시킴.
                temp.transform.parent = gameObject.transform;
                Index++;
                item_Index = 1;
                isPattern = false;
            }                                              
        }

        if (InGameManager.i.pattern_Timer % 30 == 0 && InGameManager.i.pattern_Timer >= 30f)                              
        {
            Count++;
        }

    }
}
