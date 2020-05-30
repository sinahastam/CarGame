using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject carObject;
    public TextMeshProUGUI carSpeedTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        carSpeedTxt.SetText(Mathf.RoundToInt(carObject.GetComponent<CarController>().carSpeed).ToString() +" km/h");
    }
}
