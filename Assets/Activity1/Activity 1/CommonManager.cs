using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonManager : MonoBehaviour
{


    public void Activity1()
    {
        LoadSceneByName("Activity");
    }
    public void Activity2()
    {
        LoadSceneByName("Activity 2");
    }
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
