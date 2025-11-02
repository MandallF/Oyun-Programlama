using UnityEngine;

public class Player_sc : MonoBehaviour
{
    // Public Unity Inspector penceresinde görünür ve başka scriptlerden erişilebilir.
    // Sadece bu scriptin içinde erişilebilir.Inspector’da görünmez.
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private float atesBeklemeSuresi = 0.5f; // iki atış arası süre (yarım saniye)
    [SerializeField]
    private float sonrakiAtisZamani = 0f;  // bir sonraki atışa kadar geçen süre
    [SerializeField]
    private int lives = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //script ile nesnenin konumunu bir kez değiştirme. Burada başlangıç konumuna getiriyorum.
        transform.position += new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        cubeMovement();
        fireLaser();
    }





    //Küp Hareketlerini Belirleyen Fonksiyon
    void cubeMovement()
    {
        /*
        //Klavye tuşları ile hareket ettirme (Dikey)
        float verticalInput = Input.GetAxis("Vertical");
        transform.position += Vector3.up * verticalInput * speed * Time.deltaTime;
        */


        //BONUS(Hem Dikey Hem Yatay Hareket)
        // Dikey (↑ ↓ veya W/S)
        float verticalInput = Input.GetAxis("Vertical");

        // Yatay (← → veya A/D)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Toplam hareket vektörü (x = yatay, y = dikey)
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // Normalize et (çapraz hareketlerde hız artmasın)
        if (movement.magnitude > 1f)
            movement.Normalize();

        // Nesneyi hareket ettir (FPS bağımsız)
        transform.position += movement * speed * Time.deltaTime;

        //y ekseninde hareketini sınırlama
        transform.position = new Vector3(
        transform.position.x,
        Mathf.Clamp(transform.position.y, -4.48f, 0));
        
        //x ekseninde hareketini sınırlama
        if(transform.position.x < -9.27f)
        {
            transform.position = new Vector3(9.27f, transform.position.y, 0);
        }
                if(transform.position.x > 9.27f)
        {
            transform.position = new Vector3(-9.27f, transform.position.y, 0);
        }



        /*
        script ile nesnenin konumunu sürekli değiştirme
        transform.position += Vector3.right;
        */

        /*
        Saniyede kaç birim hareket edeceğini belirleme
        transform.position += Vector3.right * speed * Time.deltaTime;
        */
    }

    void fireLaser()
    {
        // Space tuşuna basıldığında ve bekleme süresi dolmuşsa ateş et
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= sonrakiAtisZamani)
        {
            Instantiate(laserPrefab, transform.position, transform.rotation);

            // bir sonraki atış zamanı belirle
            sonrakiAtisZamani = Time.time + atesBeklemeSuresi;
        }
    }
    
    public void Damage()
    {
        lives--;
        if(lives == 0)
        {
            SpawnManager_sc spawnManager_sc = GameObject.Find("Spawn Manager").GetComponent<SpawnManager_sc>();
            if (spawnManager_sc != null)
            {
                spawnManager_sc.OnPlayerDeath();
            }
            else
            {
                Debug.LogError("Player_sc:Damage spawnManager_sc is NULL");
            }
            //önce yazılır: eğer nesne yok edilirse sonrasında gerçekleştiremez.
            Destroy(this.gameObject);

        }
    }


}