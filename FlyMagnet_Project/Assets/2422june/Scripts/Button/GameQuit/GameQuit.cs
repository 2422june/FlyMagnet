using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuit : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click()
    {
        BGMManager.i.EFTPlay(BGMManager.effType.normal);
        Invoke("QUIT", 0.5f);
    }

    void QUIT()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
