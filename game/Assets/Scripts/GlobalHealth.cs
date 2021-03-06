﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalHealth : MonoBehaviour
{

    public static int PlayerHealth = 10;
    public int InternalHealth;
    public GameObject HealthDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InternalHealth = PlayerHealth;
        HealthDisplay.GetComponent<Text>().text = "Health: " + InternalHealth;
        if(PlayerHealth == 0)           // nếu hết máu sẽ hiện lên game over
        {
            //Cursor.visible = true;
            //Screen.lockCursor = true;
            Cursor.lockState = CursorLockMode.None;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerHealth = 10;
            //Application.LoadLevel(Application.loadedLevel);


            SceneManager.LoadScene(2);
        }
    }
}
