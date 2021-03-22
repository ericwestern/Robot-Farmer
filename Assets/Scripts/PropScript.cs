using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropScript : MonoBehaviour
{
    private float xOriginalCoordinate;
    private float yOriginalCoordinate;
    private float zOriginalCoordinate;

    private MeshRenderer renderer;
    private Color orginalColor;
    private Color mouseOverColor = Color.green;

    private bool animating = false;
    private float animationTimer;
    private float xRotation = 0;
    private float rotDirection = 0;

    public float rotationChange = 25;
    public float ccwLimit = 0;
    public float cwLimit = -45;

    public string ItemName;


    // Start is called before the first frame update
    void Start()
    {
        xOriginalCoordinate = this.transform.position.x;
        yOriginalCoordinate = this.transform.position.y;
        zOriginalCoordinate = this.transform.position.z;
        renderer = GetComponent<MeshRenderer>();
        orginalColor = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (animating) {
            //TODO: animate
            if (Time.time - animationTimer >= 5) {
                animating = false;
                GameManager.Instance.AdvanceGardenState();   
                this.transform.position = new Vector3(xOriginalCoordinate,
                                                    yOriginalCoordinate,
                                                    zOriginalCoordinate);
                this.transform.eulerAngles = new Vector3(0, 0, 0);
                xRotation = 0;
                rotDirection = 0;
            } else {
                if (xRotation >= ccwLimit) {
                    rotDirection += Time.deltaTime * -rotationChange;
                } else if (xRotation <= cwLimit) {
                    rotDirection += Time.deltaTime * rotationChange;
                }
                xRotation += rotDirection;
                this.transform.rotation = Quaternion.Euler(xRotation, 0, 0);
            }
        }
    }

    void OnMouseOver() {
        renderer.material.color = mouseOverColor;
    }

    void OnMouseExit() {
        renderer.material.color = orginalColor;
    }

    void OnMouseUpAsButton() {
        if (GameManager.Instance.CorrectItemClicked(ItemName)) {
            renderer.material.color = orginalColor;
            this.transform.position = new Vector3(-7, 2, 0);
            animating = true;
            animationTimer = Time.time;
        }
    }
}
