using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorPatternSpawner : MonoBehaviour
{
    #region //Field

    [Header ("������ų ������Ʈ")]
    [SerializeField] private GameObject meteor_Object;

    [Header("������Ʈ ���� ������")]
    [SerializeField] private float Delay;

    [Header("������Ʈ�� ���� y��ǥ��")]
    [SerializeField] private int positionY;

    private GameObject temp;
    private Vector3 pos;
    private int current_Count;

    #endregion

    private void Start()
    {
        pos = Camera.main.WorldToViewportPoint(pos);
        pos.x = 1.2f;
        pos = Camera.main.ViewportToWorldPoint(pos);

        current_Count = PatternManager.instance.Count;

        StartCoroutine("StartPattern");
    }

    IEnumerator StartPattern()
    {
        WaitForSeconds wait = new WaitForSeconds(Delay);

        while(true)
        {
            yield return wait;         //���� ���ڸ��� �����̸� ��

            pos = Camera.main.WorldToViewportPoint(pos);
            pos.y = PatternManager.instance.pattern_Position[positionY % PatternManager.instance.pattern_Position.Length];
            pos = Camera.main.ViewportToWorldPoint(pos);

            positionY++;

            temp = Instantiate(meteor_Object.gameObject);
            temp.transform.position = new Vector2(pos.x, pos.y);

            if (InGameManager.i.pattern_Timer % 30 == 0 && PatternManager.instance.Count >= current_Count)           //ī��Ʈ���� ���� ī��Ʈ������ Ŀ���� while���� ����
            {
                break;
            }
        }

        PatternManager.instance.isPattern = true;               //isPattern�� true�� �ٲٰ� �� �� �ڱ� �ڽ��� ���� ��Ŵ
        Destroy(this.gameObject);
    }
}
