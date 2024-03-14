using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSystem : MonoBehaviour
{

    //private float mouseX, mouseY;
    public float mouseSensitivity;
    public float xRotation;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputDir = new Vector3(0, 0, 0);

        if(Input.GetKey(KeyCode.W)) inputDir.z = +.5f;
        if(Input.GetKey(KeyCode.S)) inputDir.z = -.5f;
        if(Input.GetKey(KeyCode.A)) inputDir.x = -.5f;
        if(Input.GetKey(KeyCode.D)) inputDir.x = +.5f;

        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;
        float moveSpeed = 50f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        CameraZoom();
        freeRotate();

    }

    private void CameraZoom() {
        Vector3 dir = new Vector3(0, 0, 0);
        if (Input.mouseScrollDelta.y > 0) {
            dir.y = -2f;
        }
        if (Input.mouseScrollDelta.y < 0) {
            dir.y = +2f;
        }

        transform.position += dir;
    }


    private void freeRotate(){
        if(Input.GetMouseButton(2)) {
            float mouseX, mouseY;
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation += mouseY;
            xRotation = Mathf.Clamp(xRotation, .1f, 70f);
            
            transform.Rotate(Vector3.up * mouseX);
            transform.GetChild(0).transform.localRotation = Quaternion.Euler(-xRotation, 0, 0);
        }
    }
}
