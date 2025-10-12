using UnityEngine;

public class Player_sc : MonoBehaviour
{
    // Public Unity Inspector penceresinde görünür ve başka scriptlerden erişilebilir.
    // Sadece bu scriptin içinde erişilebilir.Inspector’da görünmez.
    public float speed = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //script ile nesnenin konumunu bir kez değiştirme. Burada başlangıç konumuna getiriyorum.
        transform.position += new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
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
        


        /*
        script ile nesnenin konumunu sürekli değiştirme
        transform.position += Vector3.right;
        */
        
        /*
        Saniyede kaç birim hareket edeceğini belirleme
        transform.position += Vector3.right * speed * Time.deltaTime;
        */
    }
}