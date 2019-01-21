using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneColor : MonoBehaviour {

    public Color planeColor;
    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material.color = planeColor;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
