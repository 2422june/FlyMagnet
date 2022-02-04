using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory_Block : MonoBehaviour
{
    private int rand;
    void Start()
    {
        gameObject.GetComponent<Destory_Block>().enabled = false;

    }
    void OnBecameInvisible()
    {
        rand = Random.Range(0, BlockManager.BM.blocks.Length);
        if (BlockManager.BM.blocks[rand] == this.gameObject)
        {
            rand = Random.Range(0, BlockManager.BM.blocks.Length);
            Instantiate(BlockManager.BM.blocks[rand], new Vector2(gameObject.transform.position.x + 2709f, gameObject.transform.position.y), Quaternion.identity);
        }
        else
        {
            Instantiate(BlockManager.BM.blocks[rand], new Vector2(gameObject.transform.position.x + 2709f, gameObject.transform.position.y), Quaternion.identity);
        }
        Destroy(this.gameObject.transform.parent.gameObject);
    }
}
