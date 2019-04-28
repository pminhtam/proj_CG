using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunReloading : MonoBehaviour
{

    public AudioSource ReloadSound;
    public GameObject CrossObject;
    public GameObject MechanicsObject;
    public int ClipCount;
    public int ReserveCount;
    public int ReloadAvailable;
    public GunFire GunComponent;

    void Start()
    {
        GunComponent = GetComponent<GunFire>();
    }
    // Update is called once per frame
    void Update()
    {
        ClipCount = GlobalAmmo.LoadedAmmo;      // số đạn ở trong súng
        ReserveCount = GlobalAmmo.CurrentAmmo;  // số đạn còn

        if (ReserveCount == 0)                  // nếu không còn đạn
        {
            ReloadAvailable = 0;
        }
        else
        {
            ReloadAvailable = 10 - ClipCount;    // số đạn cần nnạp vào súng cho đủ 10 viên đạn
        }

        if (Input.GetButtonDown("Reload"))
        {
            if (ReloadAvailable >= 1)
            {
                if (ReserveCount <= ReloadAvailable)  // nếu không đủ đạn để nạp đầy súng
                {
                    GlobalAmmo.LoadedAmmo += ReserveCount;
                    GlobalAmmo.CurrentAmmo -= ReserveCount;
                    ActionReload();
                }
                else                                  // nạp đầy súng
                {
                    GlobalAmmo.LoadedAmmo += ReloadAvailable;
                    GlobalAmmo.CurrentAmmo -= ReloadAvailable;
                    ActionReload();
                }
            }
            StartCoroutine(EnableScripts());

        }
    }

    IEnumerator EnableScripts()         // mở lại chức năng bắn sau khi nạp đạn xong
    {
        yield return new WaitForSeconds(1.1f);
        GunComponent.enabled = true;
        CrossObject.SetActive(true);
        MechanicsObject.SetActive(true);
    }


    void ActionReload()             // trong lúc nạp đạn thì tạm thời không bắn được
    {
        GunComponent.enabled = false;
        CrossObject.SetActive(false);
        MechanicsObject.SetActive(false);
        ReloadSound.Play();
        GetComponent<Animation>().Play("HandgunReload");        // chạy animation tên HandgunReload ở component M9
    }
}
