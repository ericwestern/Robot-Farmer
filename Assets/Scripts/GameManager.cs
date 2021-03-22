using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public FieldStateData GardenStateData;

    void Awake() {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }

    public bool CorrectItemClicked(string item) {
        if (item == GardenStateData.GetCurrentState().expectedItem) {
            return true;
        }
        return false;
    }

    public void AdvanceGardenState() {
        if (checkForWin())
            ProcessWin();
        else
            GardenStateData.AdvanceGardenState();
    }

    private bool checkForWin() {
        return GardenStateData.IsLastState();
    }

    private void ProcessWin() {
        GardenStateData.GrowPlants();
    }
}
