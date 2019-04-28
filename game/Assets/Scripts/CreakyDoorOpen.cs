using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreakyDoorOpen : MonoBehaviour
{
    // mở cửa
    public float TheDistance = PlayerCasting.DistanceFromTarget;
    public GameObject ActionDisplay;
    public GameObject TheDoor;
    public AudioSource CreakySound;
    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
        //ActionDisplay.GetComponent<Text>().text = "Open Door 111111111111111";
    }

    void OnMouseOver()
    {
        if (TheDistance <= 100)
        {
            ActionDisplay.GetComponent<Text>().text = "Open Door 111111111111111";
            //ActionDisplay.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if(TheDistance <= 3)
            {
                GetComponent<BoxCollider>().enabled = false;
                //ActionDisplay.SetActive(false);
                TheDoor.GetComponent<Animation>().Play("OpenDoorAnim");
                CreakySound.Play();
            }
        }
    }
    void OnMouseExit()
    {
        ActionDisplay.GetComponent<Text>().text = "";
        //ActionDisplay.SetActive(false);

    }
}
