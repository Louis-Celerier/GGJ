using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour
{
    [SerializeField] private RawImage currentImage;
    
    [SerializeField] private List<Texture> icons;
    private int index = 0;

    private void Start()
    {
        currentImage.texture = icons[index]; 
    }

    public void Selected()
    {
        index++;
        if (index >= icons.Count) index = icons.Count - 1;
        currentImage.texture = icons[index];

        Debug.Log("Level: " + (icons.Count - index) );
    }
    
}
