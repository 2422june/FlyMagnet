using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LicenceQuit : MonoBehaviour
{
    public void Click()
    {
        GameManager.GM.TrueLicence(false);
    }
}
