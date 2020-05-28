using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;

public class CameraManager : MonoBehaviour
{
    public GameObject focus;
    public float distance = 5f;
    public float height = 2f;
    public float dampening = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, focus.transform.position + focus.transform.TransformDirection(new Vector3(0f, height, -distance)), dampening * Time.deltaTime);
        Transform t = focus.transform;
        transform.LookAt(t);

        //if hold right mouse button
        if (Input.GetKeyDown(KeyCode.C) && GetComponent<SimpleCameraController>().enabled == false)
        {
            //free view
            GetComponent<SimpleCameraController>().enabled = true;
        }
        else if(Input.GetKeyDown(KeyCode.C) && GetComponent<SimpleCameraController>().enabled == true)
        {
            //car view
            GetComponent<SimpleCameraController>().enabled = false;
            transform.position = Vector3.Lerp(transform.position, focus.transform.position + focus.transform.TransformDirection(new Vector3(0f, height, -distance)), dampening * Time.deltaTime);
            t = focus.transform;
            transform.LookAt(t);
        }


    }
}
