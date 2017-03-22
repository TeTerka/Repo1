using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    float speed = 5.0f;
    CharacterController cc;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Camera.main.transform.Rotate(-mouseY, 0, 0);
        transform.Rotate(0, mouseX, 0);
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = transform.rotation * movement;
        cc.SimpleMove(movement * speed);
    }
}
