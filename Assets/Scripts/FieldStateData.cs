using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldStateData : MonoBehaviour
{
    public GardenStateData[] gardenStates;
    public GameObject plants;
    public float growthSpeed;
    private int currentState = 0;
    private bool plantsGrowing = false;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (plantsGrowing) {
            foreach (Transform child in plants.transform) {
                if (child.transform.localScale.x < 1)
                    child.transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
                else
                    plantsGrowing = false;
            }
        }
    }

    public GardenStateData GetCurrentState(){
        return gardenStates[currentState];
    }

    public void AdvanceGardenState() {
        gardenStates[currentState].Deactivate();
        currentState++;
        gardenStates[currentState].Activate();
    }

    public bool IsLastState() {
        return (currentState == gardenStates.Length - 1);
    }

    public void GrowPlants() {
        plants.SetActive(true);
        plantsGrowing = true;
    }
}
