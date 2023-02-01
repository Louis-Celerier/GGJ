using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void PlayClicked()
    {
        Debug.Log("Change Scene to play scene");
    }

    public void QuitClicked()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
