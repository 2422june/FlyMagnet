using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTest : MonoBehaviour
{
    public void MoveScene()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void GameScene()
    {
        SceneManager.LoadScene("GameSceneTest");
    }
}
