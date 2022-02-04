using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPatternSpawn : MonoBehaviour
{
    [Header("������ ���� ��ũ��Ʈ")]

    #region //Field
    [Header ("������ų ������ ������Ʈ")]
    [SerializeField] private GameObject laser_Object;

    [Header ("�������� ������ų ��Ҹ� �̸� ������")]
    [SerializeField] private GameObject dangerSign_Object;


    [Header("������Ʈ ������")]
    [SerializeField] private float spawn_Delay;
    [SerializeField] private float sign_Delay;

    private GameObject dangerSign;       //�������� ������ų ��Ҹ� �̸� �����ִ� ������Ʈ�� �� ���� ������Ʈ�� ������Ŵ
    private GameObject temp;            //�������� �� ���� ������Ʈ�� ������Ŵ.
    private Vector3 pos;                //ȭ���� ��ǥ���� ���� ��Ű�� ���� ����
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
