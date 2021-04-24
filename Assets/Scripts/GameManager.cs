using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public FieldStateData fieldStateData;
    public Flowchart flowchart;

    private int rightAnswers;
    private int wrongAnswers;

    void Awake() {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        rightAnswers = 0;
        wrongAnswers = 0;
        //DontDestroyOnLoad(gameObject);
    }

    public bool CorrectItemClicked(string item) {
        if (item == fieldStateData.GetCurrentState().expectedItem) {
            rightAnswers++;
            flowchart.SendFungusMessage("correct");
            return true;
        }
        wrongAnswers++;
        flowchart.SendFungusMessage("incorrect");
        return false;
    }

    public void AdvanceGardenState() {
        if (checkForWin()) {
            flowchart.SetIntegerVariable("right", rightAnswers);
            flowchart.SetIntegerVariable("wrong", wrongAnswers);
            ProcessWin();
        }
        else
            fieldStateData.AdvanceGardenState();
    }

    private bool checkForWin() {
        return fieldStateData.IsLastState();
    }

    private void ProcessWin() {
        fieldStateData.GrowPlants();
    }
}
