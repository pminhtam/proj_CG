using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeZombie : MonoBehaviour
{
    public GameObject TheZombie;
    //public GameObject ThePlayer;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeZombie", 0, 7.0f);

    }

    // Update is called once per frame
    void Update()
    {

        //StartCoroutine(makeZombie());


    }
    void makeZombie()
    {
        //yield return new WaitForSeconds(10f);

        Vector3 myVector = new Vector3(transform.position.x+ Random.Range(-100.0f, 100.0f), transform.position.y, transform.position.z+ Random.Range(-100.0f, 100.0f));
        //TheZombie.SetActive(true);
        Instantiate(TheZombie, myVector, Quaternion.identity);
        //TheZombie.SetActive(true);

        //yield return new WaitForSeconds(10f);


    }
}
