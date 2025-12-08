using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEngine;



public class Enemy_sc : MonoBehaviour
{

    int speed = 5;
    Player_sc player_sc;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_sc = GameObject.Find("Player").GetComponent<Player_sc>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (this.transform.position.y < -5.5f)
        {
            this.transform.position = new Vector3(Random.Range(-9.5f, 9.5f), 7.4f, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
    {
        Player_sc player_sc = other.transform.GetComponent<Player_sc>();
        player_sc.Damage();  

        animator.SetTrigger("OnEnemyDeath");
        speed = 0;
        Destroy(gameObject,2.3f);
    }

    else if (other.tag == "Laser")
    {
        
        Destroy(other.gameObject);
        
        if(player_sc != null)
            {
                player_sc.AddScore(10);
            }
        animator.SetTrigger("OnEnemyDeath");
        speed = 0;
        Destroy(this.gameObject,2.3f);
    }
    }
    }