using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour {

	private Animator anim;

	void Start() {
		anim = GetComponent<Animator>();
	}

	void Update () {

		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
			anim.Play("Walk");
		} else {
			anim.Play("Idle");
		}

		if (Input.GetKey (KeyCode.W)) {
			transform.Translate(Vector3.forward * Time.deltaTime*10, Space.Self);
		
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate(Vector3.back * Time.deltaTime*10, Space.Self);

		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate(Vector3.left * Time.deltaTime*10, Space.Self);

		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate(Vector3.right * Time.deltaTime*10, Space.Self);

		}
		
	}

	void FixedUpdate(){
	}
}