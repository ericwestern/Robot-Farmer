using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GardenStateData
{
    public GameObject gardenState;
    public string state;
    public string expectedItem;
    public string correctMessage;
    public string incorrectMessage;
    public string helperMessage;

    public void Activate() {
        if (gardenState != null)
            gardenState.SetActive(true);
    }
    
    public void Deactivate() {
        if (gardenState != null)
            gardenState.SetActive(false);
    }
}
