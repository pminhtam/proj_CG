using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashToMenu : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SplashFinish());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SplashFinish()
    {
        yield return new WaitForSeconds(5.5f);
        SceneManager.LoadScene(4);
    }
}
