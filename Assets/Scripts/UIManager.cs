using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Buttons
    public Button Vase1Button;
    public Button Vase2Button;
    public Button Vase3Button;
    public Button Vase4Button;
    public Button Vase5Button;
    public Button MainMenuButton;
    public Button GalleryButton;
    #endregion

    private Modes currentMode = Modes.Menu;
    public Text uiVaseName;
    public Text uiVaseText;
    public GameObject[] Vases;
    public GameObject textPanels;

    private int currentVaseLooking;
    private int currentVaseExit;

    //Names
    [HideInInspector] private string vase1Name = "Kappa";
    [HideInInspector] private string vase2Name = "Gotokoneko";
    [HideInInspector] private string vase3Name = "Raijin";

    //Texts
    [HideInInspector] private string vase1String = "The Kappa usually kidnap children to eat them, though you have nothing to fear, the kappa are extremely well-educated. By showing some reverence to them, they will reciprocate and drop the water from their head, causing them to lose their powers temporarily.";
    [HideInInspector] private string vase2String = "Have you noticed the burning flames in the Seiken’s house during the nights? The gotoku-neko is of the few yokais attracted to flames.Because of this, it tends to enter cold homes and lights the fire within them.The gotoku-neko is probably the cause of it.";
    [HideInInspector] private string vase3String = "HAHAXD";

    private void Update()
    {
        if (currentMode == Modes.Menu)
        {
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        Vase1Button = GameObject.Find("Vase1Button").GetComponent<Button>();
        Vase2Button = GameObject.Find("Vase2Button").GetComponent<Button>();
        Vase3Button = GameObject.Find("Vase3Button").GetComponent<Button>();
        MainMenuButton = GameObject.Find("MenuButton").GetComponent<Button>();
        GalleryButton = GameObject.Find("GalleryButton").GetComponent<Button>();
        textPanels = GameObject.Find("Texts");
        textPanels.SetActive(false);
    }

    public void CameraZoom(int index)
    {
        //Set Buttons interactable
        MainMenuButton.interactable = false;
        Vase1Button.interactable = false;
        Vase2Button.interactable = false;
        Vase3Button.interactable = false;
        GalleryButton.interactable = true;

        //Get name of the vase
        string vaseName = Vases[index].gameObject.name;
        //Find the vase in the scene
        GameObject currentVase = GameObject.Find(vaseName);

        //Get position coordinates for the selected vase
        float XVase = currentVase.transform.position.x;
        float YVase = currentVase.transform.position.y;
        float ZVase = currentVase.transform.position.z;

        //Create a new vector using the position coordinates of the selected vase
        Vector3 cameraNewVector = new Vector3(XVase, YVase, ZVase - 3);

        //Move the camera based on the vector created previously
        Camera.main.transform.position = cameraNewVector;

        //Call set text function 
        CameraZoomed(index);

        //Enable rotation
        currentVase.GetComponent<RotateObject>().rotateEnabled = true;
    }

    public void BackToGallery()
    {
        MainMenuButton.interactable = true;
        Vase1Button.interactable = true;
        Vase2Button.interactable = true;
        Vase3Button.interactable = true;
        GalleryButton.interactable = false;

        //Find the vases in the scene
        GameObject[] VasesReset = GameObject.FindGameObjectsWithTag("Vase");

        //For each vase, set rotation boolean to false
        foreach (GameObject v in VasesReset)
        {
            v.GetComponent<RotateObject>().DisableRotate();
        }

        //Set camera to initial position
        Camera.main.transform.position = new Vector3(0, 0, -10);

        //Set camera to initial size/zoom
        // Camera.main.orthographicSize = 5;

        //Disable text panels
        textPanels.SetActive(false);
    }



    public void CameraZoomed(int index)
    {
        textPanels.SetActive(true);
        switch (index)
        {
            case 0:
                uiVaseName.text = vase1Name;
                uiVaseText.text = vase1String;
                break;
            case 1:
                uiVaseName.text = vase2Name;
                uiVaseText.text = vase2String;
                break;
            case 2:
                uiVaseName.text = vase3Name;
                uiVaseText.text = vase3String;
                break;
        }
    }

}
