using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    public static float DistanceFromTarget;     // khoảng cách tới đối tượng gần nhất bị chiếu vào
    public float ToTarget;
    //Đo khoảng cách tơi một đối tượng gần nhất

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            ToTarget = hit.distance;
            DistanceFromTarget = ToTarget;

        }
    }
}
