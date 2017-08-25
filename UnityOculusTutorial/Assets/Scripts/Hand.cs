using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    public OVRInput.Controller controller;
    public Manager manager;

    private float indexTriggerState;
    private float oldIndexTriggerState;
	
	// Update is called once per frame
	void Update () {
        oldIndexTriggerState = indexTriggerState;
        indexTriggerState = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);

        if (oldIndexTriggerState < 0.9f && indexTriggerState > 0.9f) {
            Vector3 handPosition = OVRInput.GetLocalControllerPosition(controller);
            manager.SpawnGame(gameObject, handPosition);
        }
	}
}