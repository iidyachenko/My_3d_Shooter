using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposeObject : MonoBehaviour {

    [SerializeField]
    private string objtag;

  public void DisposeTagObject()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(objtag);
        foreach (GameObject obj in objects)
        {
            DestroyImmediate(obj);
        }
    }
}
