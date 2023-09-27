using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Modes
{
    Menu, Game, Gallery
}

public class MenuManager : MonoBehaviour
{
    GameObject menuUI;
    //GameObject galleryUI;

    GameObject uiManagerObj;
    public Modes currentMode;

    private void Start()
    {
        uiManagerObj = GameObject.Find("UIManager");
        menuUI = GameObject.Find("MenuUI");
        //galleryUI = GameObject.Find("GalleryUI")
    }

    public void ModeChange(int index)
    {
        switch (index)
        {
            case 0:
                Camera.main.transform.position = new Vector3(0, 0, -10);
                currentMode = Modes.Menu;
                menuUI.SetActive(true);
                //galleryUI.SetActive(false);
                
                break;
            case 1:
                Camera.main.transform.position = new Vector3(0, 0, -10);
                currentMode = Modes.Game;
                menuUI.SetActive(false);
                //galleryUI.SetActive(false);
                break;
            case 2:
                Camera.main.transform.position = new Vector3(0, 0, -10);
                currentMode = Modes.Gallery;
                //galleryUI.SetActive(true);
                menuUI.SetActive(false);
                break;
        }
    }
}
