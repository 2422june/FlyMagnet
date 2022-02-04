using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [Header("������ų ������Ʈ")]

    #region //Field
    
    [Header("������Ʈ ���� ������")]
    [SerializeField] private float Delay;

    private GameObject temp;            //������Ʈ�� ������Ű�� ���� ���� ������Ʈ
    private Vector3 pos;
    private int positionY = 0;
    #endregion

    private void Start()
    {
        pos = Camera.main.WorldToViewportPoint(pos);
        pos.x = 1.2f;
        pos = Camera.main.ViewportToWorldPoint(pos);
        
        StartCoroutine("StartPattern");                     //���� �� �� �ڷ�ƾ�� ��� ȣ��
    }

    IEnumerator StartPattern()
    {
        WaitForSeconds wait = new WaitForSeconds(Delay);        //������ ����

        while (true)
        {
            if (DefaultPattern.instance.positionY % 3 == 0)
            {
                positionY = Random.Range(0, PatternManager.instance.pattern_Position.Length);

                Debug.Log("Check : Spawn_Coin");

                pos = Camera.main.WorldToViewportPoint(pos);
                pos.y = PatternManager.instance.pattern_Position[positionY];
                pos = Camera.main.ViewportToWorldPoint(pos);

                temp = Instantiate(PatternManager.instance.item_Object[PatternManager.instance.item_Index]);                     //������Ʈ�� ������Ŵ
                PatternManager.instance.item_Index = 0;
                temp.transform.position = new Vector2(pos.x, pos.y);                                                             //�������� ���� �� ������Ʈ�� ������ų ��ǥ���� ������
                temp.transform.parent = gameObject.transform;
            }

            yield return wait;

        }
    }
}
