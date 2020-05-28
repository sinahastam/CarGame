using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class CarController : MonoBehaviour
{
 
    public InputManager input;
    public List<WheelCollider> throttleWheels;
    public List<WheelCollider> steerWheels;
    public List<GameObject> wheelBodies;
    public List<GameObject> steerWheelBodies;
    public List<GameObject> carLights;
    public List<GameObject> breakLights;
    public float strenghtCoefficient = 20000f;
    public float maxTurn = 20f;
    public float carSpeed;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputManager>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //calculate car speed
        carSpeed = rb.velocity.magnitude * 3.6f;

        foreach (WheelCollider wheel in throttleWheels)
        {
            wheel.motorTorque = strenghtCoefficient * Time.deltaTime * input.throttle;
        }

        foreach(WheelCollider wheel in steerWheels)
        {
            wheel.steerAngle = maxTurn * input.steer;
            wheel.transform.localEulerAngles = new Vector3(0f, input.steer * maxTurn, 0f);
            
        }

        foreach(GameObject wheel in wheelBodies)
        {
            
            var localVel = transform.InverseTransformDirection(rb.velocity);
            if (localVel.z > 0)
            {
                //if forward
                wheel.transform.Rotate(carSpeed, 0f, 0f);    
            }
            else
            {
                //if backward
                wheel.transform.Rotate(-carSpeed, 0f, 0f);
            }
        }

        foreach (GameObject wheel in steerWheelBodies)
        {
            if (Input.GetKey(KeyCode.D) && (UnityEditor.TransformUtils.GetInspectorRotation(wheel.transform).y < maxTurn))
            {
                var rotation = Vector3.up * input.steer*2;
                wheel.transform.Rotate(rotation, Space.World);
            }else if(Input.GetKey(KeyCode.A) && (UnityEditor.TransformUtils.GetInspectorRotation(wheel.transform).y > -maxTurn))
            {
                var rotation = Vector3.up * input.steer*2;
                wheel.transform.Rotate(rotation, Space.World);
            }
            else
            {
                if (UnityEditor.TransformUtils.GetInspectorRotation(wheel.transform).y > 0)
                {
                    var rotation = Vector3.up * -1f;
                    wheel.transform.Rotate(rotation, Space.World);
                }

                if (UnityEditor.TransformUtils.GetInspectorRotation(wheel.transform).y < 0)
                {
                    var rotation = Vector3.up * 1f;
                    wheel.transform.Rotate(rotation, Space.World);
                }
            }


            var localVel = transform.InverseTransformDirection(rb.velocity);
            if (localVel.z > 0)
            {
                //if forward
                wheel.transform.Rotate(carSpeed, 0f, 0f);
            }
            else
            {
                //if backward
                wheel.transform.Rotate(-carSpeed, 0f, 0f);
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            foreach (GameObject light in carLights)
            {
                //if has light
                if (light.GetComponent<Light>() != null)
                {
                    Light l = light.GetComponent<Light>();
                    if(l.enabled == true)
                    {
                        l.enabled = false;
                    }
                    else
                    {
                        l.enabled = true;
                    }
                }

                //if has mesh
                if (light.GetComponent<MeshRenderer>() != null)
                {
                    MeshRenderer m = light.GetComponent<MeshRenderer>();
                    if(m.enabled == true)
                    {
                        m.enabled = false;
                    }
                    else
                    {
                        m.enabled = true;
                    }
                }

            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            foreach (GameObject bl in breakLights)
            {
                //if has light
                if (bl.GetComponent<Light>() != null)
                {
                    Light l = bl.GetComponent<Light>();
                    l.enabled = true;
                }

                //if has mesh
                if (bl.GetComponent<MeshRenderer>() != null)
                {
                    MeshRenderer m = bl.GetComponent<MeshRenderer>();
                    m.enabled = true;
                }
            }
        }
        else
        {
            foreach (GameObject bl in breakLights)
            {
                //if has light
                if (bl.GetComponent<Light>() != null)
                {
                    Light l = bl.GetComponent<Light>();
                    l.enabled = false;
                }

                //if has mesh
                if (bl.GetComponent<MeshRenderer>() != null)
                {
                    MeshRenderer m = bl.GetComponent<MeshRenderer>();
                    m.enabled = false;
                }
            }
        }
    }



}
