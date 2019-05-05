using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderFollow : MonoBehaviour
{

    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedRange = 30; // cách 10 thì đuổi
    public GameObject TheEnemy;
    public float EnemySpeed = 0.01f;        // tốc độ di chuyển of zombie
    public int AttackTrigger;       // trạng thái của zombie có tấn công không
    public RaycastHit Shot;

    public int IsAttacking;
    public GameObject ScreenFlash;      // màn hình đỏ (Khi bị tấn công)
    public AudioSource Hurt01;      
    public AudioSource Hurt02;
    public AudioSource Hurt03;
    public int PainSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(ThePlayer.transform);
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out Shot))
        {
            TargetDistance = Shot.distance;
            if(TargetDistance< AllowedRange)        // nếu đến gần zombie thì nó mới đuổi
            {
                EnemySpeed = 0.01f;
                if(AttackTrigger == 0)
                {
                    TheEnemy.GetComponent<Animation>().Play("walk");
                    transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed*Time.deltaTime);

                }
            } 
            else    // nếu không ở trạng thái nghỉ
            {
                EnemySpeed = 0;
                TheEnemy.GetComponent<Animation>().Play("idle");
            }
        }

        if(AttackTrigger == 1)          // nếu zombie đến gần thì nó tấn công
        {
            if(IsAttacking == 0)
            {
                StartCoroutine(EnemyDamage());
            }
            EnemySpeed = 0;
            TheEnemy.GetComponent<Animation>().Play("attack");

        }
    }

    void OnTriggerEnter(Collider other)     // zombie đến gần
    {
        AttackTrigger = 1;
    }

    void OnTriggerExit(Collider other)
    {
        AttackTrigger = 0;
    }

    IEnumerator EnemyDamage()
    {
        IsAttacking = 1;
        PainSound = Random.Range(1, 4);     // chọn ngẫu nhiên âm thanh
        yield return new WaitForSeconds(0.4f);
        ScreenFlash.SetActive(true);
        GlobalHealth.PlayerHealth -= 1;     // máu bị mất đi 1
        if (PainSound == 1)             // âm thanh khi zombie tấn công
        {
            Hurt01.Play();
        }
        else if(PainSound == 2)
        {
            Hurt02.Play();
        }
        else
        {
            Hurt03.Play();
        }
        yield return new WaitForSeconds(0.05f);
        ScreenFlash.SetActive(false);
        yield return new WaitForSeconds(0.75f);
        IsAttacking = 0;
    }
}
