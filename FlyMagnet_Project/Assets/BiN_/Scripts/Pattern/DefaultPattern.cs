using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPattern : MonoBehaviour
{
    [Header("생성시킬 오브젝트")]

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
    [Header("오브젝트가 왼쪽에서 오른쪽으로 날아감")]
    [SerializeField] private GameObject [] meteor_Object;

    [Header ("오브젝트 생성 딜레이")]
    [SerializeField] private float Delay;
    
    private GameObject temp;            //오브젝트를 스폰시키기 위한 게임 오브젝트
    public int positionY;
    private int Index;
    private Vector3 pos;
    #endregion

    private void Start()
    {
        pos = Camera.main.WorldToViewportPoint(pos);
        pos.x = 1.2f;
        pos = Camera.main.ViewportToWorldPoint(pos);

        StartCoroutine("StartPattern");                     //시작 된 후 코루틴을 호출
    }

    IEnumerator StartPattern()
    {
        WaitForSeconds wait = new WaitForSeconds(Delay);        //딜레이 선언
       
        while (true)                     
        {
            positionY++;

            Index = Random.Range(0, meteor_Object.Length);

            pos = Camera.main.WorldToViewportPoint(pos);
            pos.y = PatternManager.instance.pattern_Position[positionY % PatternManager.instance.pattern_Position.Length];
            pos = Camera.main.ViewportToWorldPoint(pos);

            temp = Instantiate(meteor_Object[Index].gameObject);                           //오브젝트를 생성시킴
            temp.transform.position = new Vector2(pos.x, pos.y);                    //랜덤으로 돌린 후 오브젝트를 생성시킬 좌표값을 정해줌
            temp.transform.parent = gameObject.transform;

            yield return wait;
            
        }

    }
        
}

