using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPatternSpawn : MonoBehaviour
{
    [Header("레이저 생성 스크립트")]

    #region //Field
    [Header ("생성시킬 레이저 오브젝트")]
    [SerializeField] private GameObject laser_Object;

    [Header ("레이저를 생성시킬 장소를 미리 보여줌")]
    [SerializeField] private GameObject dangerSign_Object;


    [Header("오브젝트 딜레이")]
    [SerializeField] private float spawn_Delay;
    [SerializeField] private float sign_Delay;

    private GameObject dangerSign;       //레이저를 생성시킬 장소를 미리 보여주는 오브젝트를 이 게임 오브젝트에 생성시킴
    private GameObject temp;            //레이저를 이 게임 오브젝트에 생성시킴.
    private Vector3 pos;                //화면의 좌표값을 저장 시키기 위한 변수
    private int position_Index;
    #endregion

    private void Start()
    {
       StartCoroutine("StartPattern");
    }

    IEnumerator StartPattern()
    {
        WaitForSeconds spawnDealy = new WaitForSeconds(spawn_Delay);
        WaitForSeconds signDelay = new WaitForSeconds(sign_Delay);
        
        yield return spawnDealy;
        SetDangerSign();
        dangerSign = Instantiate(dangerSign_Object.gameObject, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
        
        yield return signDelay;
        SetLaser();

    }

    private void SetDangerSign()
    {
        pos = Camera.main.WorldToViewportPoint(pos);
        pos.x = 1.0f;
        pos.y = PatternManager.instance.pattern_Position[position_Index % PatternManager.instance.pattern_Position.Length];
        pos = Camera.main.ViewportToWorldPoint(pos);
    }

    private void SetLaser()
    {
        pos = Camera.main.WorldToViewportPoint(pos);
        pos.x = 1.5f;
        pos = Camera.main.ViewportToWorldPoint(pos);
    }

}
