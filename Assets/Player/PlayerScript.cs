using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    //movement
    float speed = 100.0f;
    CharacterController cc;
    //interaction
    MeshRenderer lastSelected;
    //crosshair
    public Texture2D crosshairTexture;

    void Start () {
        cc = GetComponent<CharacterController>();
        Cursor.visible = false;
	}

    void OnGUI()
    {
        //draw crosshair
        GUI.DrawTexture(new Rect((Screen.width - crosshairTexture.width) / 2, (Screen.height - crosshairTexture.height) / 2, crosshairTexture.width, crosshairTexture.height), crosshairTexture);
    }
    void Update () {

        //move
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float leftright = Input.GetAxis("Mouse X");
        float updown = Input.GetAxis("Mouse Y");
        Camera.main.transform.Rotate(-updown, 0, 0);
        transform.Rotate(0, leftright, 0);
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = transform.rotation * movement * Time.deltaTime;
        cc.SimpleMove(movement * speed);

        //look
        EyeRaycast();

        //click
        if (lastSelected != null && Input.GetKey("e"))
        {
            lastSelected.material.color = Color.red;
        }
    }

    private void EyeRaycast()//send a ray forwards from the camera, check what was hit
    {

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 20f, LayerMask.GetMask("Interaction")))
        {
            MeshRenderer m = hit.collider.GetComponent<MeshRenderer>();
            if (lastSelected!= null && m != lastSelected)//a new object was hit
            {
                lastSelected.material.color = Color.white;
                m.material.color = Color.green;
                lastSelected = m;
            }
            else//the same object was hit, or nothing was selected before this hit
            {
                m.material.color = Color.green;
                lastSelected = m;
            }
        }
        else //nothing was hit
        {
            if (lastSelected != null)
            {
                lastSelected.material.color = Color.white;
                lastSelected = null;
            }
        }
    }
}
