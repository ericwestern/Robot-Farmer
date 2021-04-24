using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePanelScript : MonoBehaviour
{
    public InputField inputTextField;
    public Button submitButton;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            submitButton.onClick.Invoke();

    }

    void onEnable() {
        inputTextField.Select();
        inputTextField.ActivateInputField();
    }
}
