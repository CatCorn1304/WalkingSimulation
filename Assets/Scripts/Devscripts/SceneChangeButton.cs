using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneChangeButton : MonoBehaviour
{
    public string targetSceneName;

    public void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}

