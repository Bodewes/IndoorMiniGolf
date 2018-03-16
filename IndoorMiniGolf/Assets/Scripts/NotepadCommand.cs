using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotepadCommand : MonoBehaviour {

    public GameObject BallsGroup { get; private set; }

    void Awake()
    {
        BallsGroup = GameObject.Find("Balls");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnSelect(string focusedObject)
    {
        if (BallsGroup != null && focusedObject == "Cube.007")
        {
            BallsGroup.BroadcastMessage("OnReset");
        }
    }
}
