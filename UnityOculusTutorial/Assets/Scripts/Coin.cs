﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public float rotationRate;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.one * rotationRate);
	}
}