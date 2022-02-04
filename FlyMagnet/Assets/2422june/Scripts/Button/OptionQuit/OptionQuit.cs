using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionQuit : MonoBehaviour
{

    public void Click()
    {
        GameManager.GM.TrueOption(false);
    }
}
