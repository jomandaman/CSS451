﻿using System; // for assert
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // for GUI elements: Button, Toggle

public class MainController : MonoBehaviour {

    // reference to all UI elements in the Canvas
    public Button CreateButton = null;
    public Button DeleteSelectedButton = null;
    public Toggle ShowSphereToggle = null;

    // information that will be changed by user action (identify selected)
    private GameObject mSelectedObject = null;
    private GameObject mTheSphere = null;

	// Use this for initialization
	void Start () {
        Debug.Assert(CreateButton != null);
        Debug.Assert(DeleteSelectedButton != null);
        Debug.Assert(ShowSphereToggle != null);

        // Add listeners to the button
        CreateButton.onClick.AddListener(CreateNewCube);
        DeleteSelectedButton.onClick.AddListener(DeleteSelectedCube);
        ShowSphereToggle.onValueChanged.AddListener(ShowSphere);

        // now initialize the sphere reference
        // mTheSphere = transform.Find("MySphere").GetComponent<ShowSphere>(); // C# reference to component 
        mTheSphere = GameObject.Find("MySphere"); // This looks through entire scene, more expensive
        Debug.Assert(mTheSphere != null);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // UI support functions
    void CreateNewCube()
    {
        GameObject cube = Instantiate(Resources.Load("MyCube")) as GameObject;
            // NOTE: Resources.Load("file path to the prefab") so, in this case
            //       MyCube.prefab MUST be located in Resoruces/ folder
        cube.transform.position = new Vector3(10, 0, 10);
    }

    void DeleteSelectedCube()
    {

    }

    void ShowSphere(bool newValue)
    {
        mTheSphere.GetComponent<Renderer>().enabled = newValue;
    }
}
