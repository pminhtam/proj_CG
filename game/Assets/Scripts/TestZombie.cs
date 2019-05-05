using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestZombie : MonoBehaviour
{
    public GameObject TheEnemy;
    // Start is called before the first frame update
    void Start()
    {
        TheEnemy.GetComponent<Animation>().Play("attack");
    }

    // Update is called once per frame
    void Update()
    {
        TheEnemy.GetComponent<Animation>().Play("attack");
    
    }
}
