using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorPatternSpawner : MonoBehaviour
{
    #region //Field

    [Header ("생성시킬 오브젝트")]
    [SerializeField] private GameObject meteor_Object;

    [Header("오브젝트 생성 딜레이")]
    [SerializeField] private float Delay;

    [Header("오브젝트의 생성 y좌표값")]
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
            yield return wait;         //시작 하자마자 딜레이를 줌

            pos = Camera.main.WorldToViewportPoint(pos);
            pos.y = PatternManager.instance.pattern_Position[positionY % PatternManager.instance.pattern_Position.Length];
            pos = Camera.main.ViewportToWorldPoint(pos);

            positionY++;

            temp = Instantiate(meteor_Object.gameObject);
            temp.transform.position = new Vector2(pos.x, pos.y);

            if (InGameManager.i.pattern_Timer % 30 == 0 && PatternManager.instance.Count >= current_Count)           //카운트값이 현재 카운트값보다 커지면 while문을 멈춤
            {
                break;
            }
        }

        PatternManager.instance.isPattern = true;               //isPattern을 true로 바꾸고 난 후 자기 자신을 삭제 시킴
        Destroy(this.gameObject);
    }
}
