using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSpider : MonoBehaviour
{
    public GameObject TheSpider;
    //public GameObject ThePlayer;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeSpider", 0, 5.0f);

    }

    // Update is called once per frame
    void Update()
    {

        //StartCoroutine(makeZombie());


    }
    void makeSpider()
    {
        //yield return new WaitForSeconds(10f);

        Vector3 myVector = new Vector3(transform.position.x+ Random.Range(-50.0f, 50.0f), transform.position.y, transform.position.z+ Random.Range(-50.0f, 50.0f));
        //TheZombie.SetActive(true);
        Instantiate(TheSpider, myVector, Quaternion.identity);
        //TheZombie.SetActive(true);

        //yield return new WaitForSeconds(10f);


    }
}
