using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickUpBook : MonoBehaviour
{

    public float TheDistance = PlayerCasting.DistanceFromTarget;
    public GameObject TextDisplay;

    public GameObject Book;

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
            TextDisplay.GetComponent<Text>().text = "Pick up book";
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)           // đến gần khẩu súng
            {
                StartCoroutine(TakeNineMil());
                ObjectiveComplete.SetActive(true);
                TextDisplay.GetComponent<Text>().text = "";
                SceneManager.LoadScene(5);

            }
        }
    }

    void OnMouseExit()
    {
        TextDisplay.GetComponent<Text>().text = "";
    }

    IEnumerator TakeNineMil()               // nhặt súng
    {
        transform.position = new Vector3(0, -1000, 0);
        Book.SetActive(false);
        yield return new WaitForSeconds(0.1f);
    }
}
