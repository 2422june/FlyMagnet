using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPattern : MonoBehaviour
{
    [Header("������ų ������Ʈ")]

    public static DefaultPattern instance = null;

    public void Awake()
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

    #region //Field
    [Header("������Ʈ�� ���ʿ��� ���������� ���ư�")]
    [SerializeField] private GameObject [] meteor_Object;

    [Header ("������Ʈ ���� ������")]
    [SerializeField] private float Delay;
    
    private GameObject temp;            //������Ʈ�� ������Ű�� ���� ���� ������Ʈ
    public int positionY;
    private int Index;
    private Vector3 pos;
    #endregion

    private void Start()
    {
        pos = Camera.main.WorldToViewportPoint(pos);
        pos.x = 1.2f;
        pos = Camera.main.ViewportToWorldPoint(pos);

        StartCoroutine("StartPattern");                     //���� �� �� �ڷ�ƾ�� ȣ��
    }

    IEnumerator StartPattern()
    {
        WaitForSeconds wait = new WaitForSeconds(Delay);        //������ ����
       
        while (true)                     
        {
            positionY++;

            Index = Random.Range(0, meteor_Object.Length);

            pos = Camera.main.WorldToViewportPoint(pos);
            pos.y = PatternManager.instance.pattern_Position[positionY % PatternManager.instance.pattern_Position.Length];
            pos = Camera.main.ViewportToWorldPoint(pos);

            temp = Instantiate(meteor_Object[Index].gameObject);                           //������Ʈ�� ������Ŵ
            temp.transform.position = new Vector2(pos.x, pos.y);                    //�������� ���� �� ������Ʈ�� ������ų ��ǥ���� ������
            temp.transform.parent = gameObject.transform;

            yield return wait;
            
        }

    }
        
}

