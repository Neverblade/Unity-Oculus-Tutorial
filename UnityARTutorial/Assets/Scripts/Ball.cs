using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed;

    private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// FixedUpdate gets called every 0.02 seconds.
	void FixedUpdate () {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed;

        rigidbody.AddForce(movement);
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Coin") {
            Destroy(other.gameObject);
        }
    }
}
