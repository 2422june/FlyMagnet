using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public static BlockManager BM;
    public GameObject[] blocks;

    private void Awake()
    {
        if(BM == null)
        {
            BM = this;
        }
    }
}
