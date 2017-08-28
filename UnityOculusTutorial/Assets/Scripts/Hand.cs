using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    public OVRInput.Controller controller;

    public GameObject boardPrefab;
    public GameObject ballPrefab;

    private GameObject board;
    private GameObject ball;

    public float scale;

    private float indexTriggerState;
    private float oldIndexTriggerState;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        oldIndexTriggerState = indexTriggerState;
        indexTriggerState = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);

        if (indexTriggerState > 0.9f && oldIndexTriggerState < 0.9f) {
            Respawn();
        }
	}

    void Respawn() {
        if (board != null) {
            Destroy(board);
            Destroy(ball);
        }

        Vector3 position = OVRInput.GetLocalControllerPosition(controller);

        board = Instantiate(boardPrefab, position, Quaternion.identity);
        board.transform.localScale = Vector3.one * scale;
        board.transform.parent = transform;

        ball = Instantiate(ballPrefab, position + new Vector3(0, 0.05f, 0), Quaternion.identity);
        ball.transform.localScale = Vector3.one * scale;
    }
}
