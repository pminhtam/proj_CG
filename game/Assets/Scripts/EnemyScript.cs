using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // zombie chết
    // nếu chết sẽ để lại đạn
    public int EnemyHealth = 10;
    public GameObject TheZombie;

    public GameObject AmmoCrate;

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
            this.GetComponent<ZombieFollow>().enabled = false;
            TheZombie.GetComponent<Animation>().Play("Dying");
            // chết sẽ tạo một thùng đạn

            StartCoroutine(EndZombie());

        }
    }
    IEnumerator EndZombie()
    {
        yield return new WaitForSeconds(3);
        GlobalScore.CurrentScore += 5;
        Destroy(gameObject);
        Instantiate(AmmoCrate, transform.position, Quaternion.identity);
    }
}
