using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossAnimate : MonoBehaviour
{

    public GameObject UpCurs;
    public GameObject DownCurs;
    public GameObject LeftCurs;
    public GameObject RightCurs;

    private void Start()
    {
        StartCoroutine(WaitingAnim());
    }
    // Update is called once per frame
    void Update()                   // khi bắn thì animation của tâm súng thay đổi
    {
        if (GlobalAmmo.LoadedAmmo >= 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                UpCurs.GetComponent<Animator>().enabled = true;
                DownCurs.GetComponent<Animator>().enabled = true;
                LeftCurs.GetComponent<Animator>().enabled = true;
                RightCurs.GetComponent<Animator>().enabled = true;
                StartCoroutine(WaitingAnim());
            }
        }
    }
    IEnumerator WaitingAnim()                       // animation duy trì 0.09s rồi dừng
    {
        yield return new WaitForSeconds(0.09f);
        UpCurs.GetComponent<Animator>().enabled = false;
        DownCurs.GetComponent<Animator>().enabled = false;
        LeftCurs.GetComponent<Animator>().enabled = false;
        RightCurs.GetComponent<Animator>().enabled = false;
    }
}
