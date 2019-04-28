using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBlow : MonoBehaviour
{

    public int EnemyHealth = 10;
    public GameObject TheBarrel;
    public GameObject FakeBarrel;

    void DeductPoints(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }
    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth <= 0)
        {
            TheBarrel.SetActive(false);
            FakeBarrel.SetActive(true);
        }
    }

}
