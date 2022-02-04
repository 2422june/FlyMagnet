using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [Header("생성시킬 오브젝트")]

    #region //Field
    
    [Header("오브젝트 생성 딜레이")]
    [SerializeField] private float Delay;

    private GameObject temp;            //오브젝트를 스폰시키기 위한 게임 오브젝트
    private Vector3 pos;
    private int positionY = 0;
    #endregion

    private void Start()
    {
        pos = Camera.main.WorldToViewportPoint(pos);
        pos.x = 1.2f;
        pos = Camera.main.ViewportToWorldPoint(pos);
        
        StartCoroutine("StartPattern");                     //시작 된 후 코루틴을 즉시 호출
    }

    IEnumerator StartPattern()
    {
        WaitForSeconds wait = new WaitForSeconds(Delay);        //딜레이 선언

        while (true)
        {
            if (DefaultPattern.instance.positionY % 3 == 0)
            {
                positionY = Random.Range(0, PatternManager.instance.pattern_Position.Length);

                Debug.Log("Check : Spawn_Coin");

                pos = Camera.main.WorldToViewportPoint(pos);
                pos.y = PatternManager.instance.pattern_Position[positionY];
                pos = Camera.main.ViewportToWorldPoint(pos);

                temp = Instantiate(PatternManager.instance.item_Object[PatternManager.instance.item_Index]);                     //오브젝트를 생성시킴
                PatternManager.instance.item_Index = 0;
                temp.transform.position = new Vector2(pos.x, pos.y);                                                             //랜덤으로 돌린 후 오브젝트를 생성시킬 좌표값을 정해줌
                temp.transform.parent = gameObject.transform;
            }

            yield return wait;

        }
    }
}
