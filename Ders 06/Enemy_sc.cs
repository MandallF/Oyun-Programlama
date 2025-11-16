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
void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        Player_sc player_sc = other.GetComponent<Player_sc>();

        // Player yok edilmişse hata almamak için kontrol
        if (player_sc != null)
        {
            player_sc.Damage();
        }

        Destroy(gameObject);
    }
    else if (other.CompareTag("Laser"))
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
    }