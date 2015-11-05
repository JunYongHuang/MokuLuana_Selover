using UnityEngine;
using System.Collections;

public class FirstPerson : MonoBehaviour {

	Camera cam;
	CharacterController cc;
	public float moveSpeed = 100;
	Vector3 mousePrev;
	float mouseSensitivityX = .5f;
	float mouseSensitivityY = .5f;
	float rotationX = 0;
	float rotationY = 0;

	void Start () {
		cam = Camera.main;
		cc = GetComponent<CharacterController> ();
	}

	void Update () {

		Vector3 mouseDelta = Input.mousePosition - mousePrev;
		mousePrev = Input.mousePosition;

		rotationX -= mouseDelta.y * mouseSensitivityY;		
		rotationY += mouseDelta.x * mouseSensitivityX;

		rotationX = Mathf.Clamp (rotationX, -120, 120);
		
		transform.rotation = Quaternion.Euler(new Vector3 (0, rotationY, 0));
		cam.transform.localRotation = Quaternion.Euler (new Vector3 (rotationX, 0, 0));

		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		

		Vector3 moveForward = v * transform.forward; 
		Vector3 moveSideway = h * transform.right;

		Vector3 move = moveForward + moveSideway;
		if (move.magnitude > 1)	move = move.normalized;

	
		cc.SimpleMove (move * moveSpeed);
	}
}
