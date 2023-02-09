using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMusicLvl4 : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Level 1")
        {
            Destroy(this.gameObject);
        }
        if (currentScene.name == "Level 2")
        {
            Destroy(this.gameObject);
        }
        if (currentScene.name == "Level 3")
        {
            Destroy(this.gameObject);
        }
        if (currentScene.name == "Level 7")
        {
            Destroy(this.gameObject);
        }
        if (currentScene.name == "Level 8")
        {
            Destroy(this.gameObject);
        }
        if (currentScene.name == "Level 9")
        {
            Destroy(this.gameObject);
        }
        if (currentScene.name == "Level 10")
        {
            Destroy(this.gameObject);
        }
        if (currentScene.name == "Level 11")
        {
            Destroy(this.gameObject);
        }
        if (currentScene.name == "Level 12")
        {
            Destroy(this.gameObject);
        }
    }

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
