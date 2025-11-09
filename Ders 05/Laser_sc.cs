using UnityEngine;

public class Laser_sc : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float maxY = 13f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y > maxY)
        {
            Destroy(gameObject);
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Düşmanla çarpıştıysa
        {
            Destroy(other.gameObject); // Düşmanı yok et
            Destroy(gameObject); // Mermiyi yok et
        }
    }
}
