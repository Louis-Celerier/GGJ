using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SelectionAbilities : MonoBehaviour
{
    [SerializeField] private int indexChoice = 0;

    [SerializeField] private GameObject SelectedUI;

    [SerializeField] private List<GameObject> Abilities;

    void Update()
    {
        UpdateUI();
        
        if (Input.GetKeyDown(KeyCode.A)) //Move to left
        {
            indexChoice--;
        } else if (Input.GetKeyDown(KeyCode.D)) //Move to right
        {
            indexChoice++;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AbilitySelected();    
        }

        if (indexChoice < 0) indexChoice = Abilities.Count - 1;
        if (indexChoice >= Abilities.Count) indexChoice = 0;
    }

    void UpdateUI()
    {
        SelectedUI.GetComponent<RectTransform>().position = Abilities[indexChoice].GetComponent<RectTransform>().position;
    }

    void AbilitySelected()
    {
        Debug.Log("Choice " + (indexChoice + 1) + " selected");
    }
    
}
