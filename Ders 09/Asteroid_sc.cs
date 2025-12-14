using Unity.VisualScripting;
using UnityEngine;

public class Asteroid_sc : MonoBehaviour
{

    [SerializeField] float rotateSpeed = 20.0f;
    [SerializeField] GameObject explosionPrefeb;
    [SerializeField] SpawnManager_sc spawnManager_Sc;
    void Start()
    {
        spawnManager_Sc = GameObject.Find("Spawn Manager").GetComponent<SpawnManager_sc>();
        if (spawnManager_Sc == null)
        {
            Debug.Log("Asteroid_sc::Start,spawnManager_sc is NULL");
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Instantiate(explosionPrefeb, this.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            spawnManager_Sc.StartSpawning();
            Destroy(this.gameObject);
        }
    }
}
