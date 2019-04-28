using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp9mm : MonoBehaviour
{

    public float TheDistance = PlayerCasting.DistanceFromTarget;
    public GameObject TextDisplay;

    public GameObject FakeGun;
    public GameObject RealGun;
    public GameObject AmmoDisplay;
    public AudioSource PickUpAudio;

    public GameObject ObjectiveComplete;


    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;

    }

    void OnMouseOver()                      // di chuyển chuột đến gần thì hiện lên chữ (giống vụ mở cửa)
    {
        if (TheDistance <= 2)
        {
            TextDisplay.GetComponent<Text>().text = "Take 9mm Pistol";
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)           // đến gần khẩu súng
            {
                StartCoroutine(TakeNineMil());
                ObjectiveComplete.SetActive(true);
            }
        }
    }

    void OnMouseExit()
    {
        TextDisplay.GetComponent<Text>().text = "";
    }

    IEnumerator TakeNineMil()               // nhặt súng
    {
        PickUpAudio.Play();
        transform.position = new Vector3(0, -1000, 0);
        FakeGun.SetActive(false);
        RealGun.SetActive(true);
        AmmoDisplay.SetActive(true);
        yield return new WaitForSeconds(0.1f);
    }
}
