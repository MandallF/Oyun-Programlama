using System.Collections;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    [Header("Hareket Ayarları")]
    [SerializeField] private float speed = 5f;

    [Header("Ateşleme Ayarları")]
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject tripleLaserPrefab;
    [SerializeField] private float atesBeklemeSuresi = 0.25f; // iki atış arası minimum süre
    private float sonrakiAtisZamani = 0f;

    [Header("Can Ayarları")]
    [SerializeField] private int lives = 3;

    [Header("Bonus Özellikler")]
    [SerializeField] private bool isTripleShootActive = false;

    void Start()
    {
        transform.position = Vector3.zero;
    }

    void Update()
    {
        cubeMovement();
        fireLaser();
    }

    // --- Hareket ---
    void cubeMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        if (movement.magnitude > 1f)
            movement.Normalize();

        transform.position += movement * speed * Time.deltaTime;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -9.27f, 9.27f),
            Mathf.Clamp(transform.position.y, -4.48f, 0),
            0f
        );

        // Ekranın sağ/sol sınırından çıkarsa diğer taraftan girsin (wrap)
        if (transform.position.x <= -9.27f)
            transform.position = new Vector3(9.27f, transform.position.y, 0);
        else if (transform.position.x >= 9.27f)
            transform.position = new Vector3(-9.27f, transform.position.y, 0);
    }

    // --- Ateşleme ---
    void fireLaser()
    {
        // Space tuşuna basılıysa ve cooldown süresi geçtiyse
        if (Input.GetKey(KeyCode.Space) && Time.time > sonrakiAtisZamani)
        {
            sonrakiAtisZamani = Time.time + atesBeklemeSuresi;

            if (!isTripleShootActive)
            {
                // Tekli atış
                Instantiate(laserPrefab, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
            }
            else
            {
            // Üçlü atış
            Instantiate(tripleLaserPrefab, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
        }
    }

    // --- Hasar ---
    public void Damage()
    {
        lives--;
        if (lives <= 0)
        {
            SpawnManager_sc spawnManager_sc = GameObject.Find("Spawn Manager")?.GetComponent<SpawnManager_sc>();
            if (spawnManager_sc != null)
                spawnManager_sc.OnPlayerDeath();
            else
                Debug.LogError("Player_sc: Damage -> SpawnManager_sc is NULL!");

            Destroy(this.gameObject);
        }
    }

    // --- Triple Shoot Aktifleştirme ---
    public void TripleShootActive()
    {
        isTripleShootActive = true;
        StartCoroutine(TripleShootCancelRoutine());
    }

    IEnumerator TripleShootCancelRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShootActive = false;
    }
}
