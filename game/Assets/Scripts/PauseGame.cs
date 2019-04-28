using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseGame : MonoBehaviour
{

    public bool Paused = false;
    public GameObject ThePlayer;
    public GameObject PauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(Paused == false)
            {
                Time.timeScale = 0;
                Paused = true;
                ThePlayer.GetComponent<FirstPersonController>().enabled = false;
                Cursor.visible = true;
                PauseMenu.SetActive(true);

            }
            else
            {
                Time.timeScale = 1;
                Paused = false;
                ThePlayer.GetComponent<FirstPersonController>().enabled = true;
                Cursor.visible = false;
                PauseMenu.SetActive(false);

            }
        }    
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1;
        Paused = false;
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = false;
        PauseMenu.SetActive(false);
    }
}
