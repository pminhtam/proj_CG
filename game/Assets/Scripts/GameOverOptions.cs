using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOptions : MonoBehaviour
{

    public void MainMenu()
    {
        SceneManager.LoadScene(4);

    }


    public void Quit()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;


    }

    // Update is called once per frame
    void Update()
    {
        //Cursor.visible = true;

    }
}
