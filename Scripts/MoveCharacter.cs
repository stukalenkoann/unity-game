using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour {
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate(Vector3.forward * Time.deltaTime, Space.Self);
		
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate(Vector3.back * Time.deltaTime, Space.Self);

		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate(Vector3.left * Time.deltaTime, Space.Self);

		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate(Vector3.right * Time.deltaTime, Space.Self);

		}
	}
	void FixedUpdate(){
		

	}
}
