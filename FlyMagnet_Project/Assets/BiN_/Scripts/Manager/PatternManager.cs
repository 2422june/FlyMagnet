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

    [Header("�迭���� �������� �������� index ����")]
    public int Index = 0;

    private GameObject temp;        //�������� temp ������Ʈ�� ���� ��Ű�� ���� ���� ������Ʈ

    public bool isPattern = true;       //������ Ȱ��ȭ ��Ȱ��ȭ ���¸� üũ�� bool ����
    public int Count = 0;               //������ ��� ���� �Ǿ����� üũ�� ����
    public int item_Index;

    [Header("������ų ������ ������Ʈ")]
    public GameObject[] item_Object;

    [Header("������ ���� �迭")]
    [SerializeField] private GameObject[] pattern_Manager;

    

    [Header("������ ��ǥ���� ���� �迭")]
    public float [] pattern_Position;
    private float Timer = 0;
    #endregion

    private void Update()
    {
        if (InGameManager.i.pattern_Timer % 30 == 0 && isPattern && Count > 0)       //60�� ������ ������ ������Ŵ
        {
            if(InGameManager.i.pattern_Timer >= 30f)
            {
                temp = Instantiate(pattern_Manager[Index % pattern_Manager.Length], Vector2.zero, Quaternion.identity);   //�迭�� �ȿ� �ִ� ������ ������Ŵ.
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
