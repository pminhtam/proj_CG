using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public GameObject Flash;
    void Start()
    {
        Flash.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (GlobalAmmo.LoadedAmmo >= 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                AudioSource gunsound = GetComponent<AudioSource>();
                gunsound.Play();                                // tiếng súng nổ
                
                StartCoroutine(MuzzleOff());
                GetComponent<Animation>().Play("GunShot");      // súng giật khi bắn
                GlobalAmmo.LoadedAmmo -= 1;                     // trừ 1 viên đạn
            }
        }
    }

    public IEnumerator MuzzleOff()
    {
        Flash.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        Flash.SetActive(false);
    }
}
