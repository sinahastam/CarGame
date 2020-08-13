using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject carObject;
    public TextMeshProUGUI carSpeedTxt;
    public TextMeshProUGUI nitroAmountTxt;
    private GameObject menuPanel;
    public GameObject controlsPanel;
    public GameObject ResetButton;
    public GameObject ControlsButton;
    private bool isMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel = GameObject.Find("menu");
        menuPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Speed ui text
        carSpeedTxt.SetText(Mathf.RoundToInt(carObject.GetComponent<CarController>().carSpeed).ToString() + " km/h");

        //Nitro ui text
        if (carObject.GetComponent<CarController>().nitro < 0)
        {
            nitroAmountTxt.color = Color.red;
            nitroAmountTxt.SetText("0" + " Nitro");
        }
        else
        {
            nitroAmountTxt.color = Color.black;
            nitroAmountTxt.SetText(Mathf.RoundToInt(carObject.GetComponent<CarController>().nitro).ToString() + " Nitro");
        }

       
        //Show menu when esc pressed
        if (isMenu == false && Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(true);
            isMenu = true;
        }
        else if (isMenu == true && Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(false);
            isMenu = false;
        }


    }   

    //Restart Button
    public void teleportToStart()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(50, 0, -10f);
        player.transform.rotation = new Quaternion(0, 0, 0, 0);
        player.GetComponent<Rigidbody>().Sleep();

    }

    public void showControlsMenu()
    {
        GameObject.Find("Reset").SetActive(false);
        GameObject.Find("Controls").SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void closeControlsMenu()
    {
        controlsPanel.SetActive(false);
        ResetButton.SetActive(true);
        ControlsButton.SetActive(true);
    }
}
