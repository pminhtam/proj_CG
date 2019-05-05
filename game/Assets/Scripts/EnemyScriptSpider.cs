using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptSpider : MonoBehaviour
{

    public int EnemyHealth = 10;
    public GameObject TheSpider;
    void DeductPoints(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }
    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth <= 0)
        {
            //Destroy(gameObject);
            this.GetComponent<SpiderFollow>().enabled = false;
            TheSpider.GetComponent<Animation>().Play("die");
            GlobalScore.CurrentScore += 3;
            //StartCoroutine(EndZombie());
            EnemyHealth = 1;
        }
    }
    IEnumerator EndZombie()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

    }
}
