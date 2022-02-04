using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Licence : MonoBehaviour
{
    public void Click()
    {
        GameManager.GM.TrueLicence(true);
    }
}
