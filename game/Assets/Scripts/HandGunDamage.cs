using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunDamage : MonoBehaviour
{

    public int DamageAmount = 5;
    public float TargetDistance;
    public float AllowedRange = 150.0f;

    public RaycastHit hit;
    public GameObject TheBullet;
    public GameObject TheBlood;


    void Start()
    {
        DamageAmount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalAmmo.LoadedAmmo >= 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit Shot;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                {
                    DamageAmount = 5;

                    //print("Found an object - distance: " + Shot.distance);
                    //Debug.Log(Shot);
                    TargetDistance = Shot.distance;
                    if (TargetDistance < AllowedRange)
                    {
                        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                        {
                            if (hit.transform.tag == "Zombie")
                            {
                                Instantiate(TheBlood, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));   // hiển thị lỗ đạn khi bị bắn

                            }
                            if (hit.collider.tag == "ZombieHead")
                            {
                                DamageAmount = 10;
                                Instantiate(TheBlood, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));   // hiển thị lỗ đạn khi bị bắn

                            }
                            if (hit.transform.tag == "Untagged")
                            {
                                Instantiate(TheBullet, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));   // hiển thị lỗ đạn khi bị bắn
                            }
                        }

                        // truyền đến hàm DeductPoints ở EnemyScript
                        Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);


                    }
                }
            }
        }
    }
}
