using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEngine;



public class Enemy_sc : MonoBehaviour
{

    int speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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

    void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        Player_sc player_sc = other.transform.GetComponent<Player_sc>();
        player_sc.Damage();  

       
        Destroy(gameObject);
    }

    else if (other.tag == "Laser")
    {
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
    }


}