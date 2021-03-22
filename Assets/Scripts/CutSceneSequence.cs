using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneSequence : MonoBehaviour
{
    public GameObject cam1;

    void Start()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence() {
        yield return new WaitForSeconds(4);
    }
}
