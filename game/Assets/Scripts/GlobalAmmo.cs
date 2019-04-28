using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour
{
    public static int CurrentAmmo;  // số đạn còn
    public int InternalAmmo;
    public GameObject AmmoDisplay;

    public static int LoadedAmmo;  // số đạn nạp vào súng
    public int InternalLoaded;
    public GameObject LoadedDisplay;


    // Update is called once per frame
    void Update()
    {
        InternalAmmo = CurrentAmmo;
        InternalLoaded = LoadedAmmo;
        AmmoDisplay.GetComponent<Text>().text = "" + InternalAmmo;  // số đạn còn
        LoadedDisplay.GetComponent<Text>().text = "" + LoadedAmmo;  // số đạn nạp vào súng
    }
}
