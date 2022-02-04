using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatBlock : MonoBehaviour
{
    private GameObject SpawnHelper;
    // Start is called before the first frame update
    void Start()
    {
        SpawnStart();
    }

    void SpawnStart()
    {
        float blockX = -605;
        for (int i = 0; i < 2; i++)
        {
            SpawnHelper = Instantiate(BlockManager.BM.blocks[i], new Vector3(blockX, -400f, 0f), Quaternion.identity);
            blockX += 2322f;        
        }
    }
}
