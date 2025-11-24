using UnityEngine;

public class Bonus_sc : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int bonusId;
    void Update()
    {
        // Aşağıya doğru hareket
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Ekrandan çıktıysa yok et
        if (transform.position.y < -5.77f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player script'ine eriş
            Player_sc player = other.GetComponent<Player_sc>();

            if (player != null)
            {
                switch (bonusId)
                {
                //Üçlü Atış Bonusu
                case 0:
                    player.TripleShootActive();
                    break;
                
                //Hız Bonusu
                case 1:
                    player.SpeedBonusActive();
                    break;
                
                //Kalkan Bonusu
                case 2:
                    player.ShieldBonusActive();
                    break;
                default:
                    Debug.Log("Hata Durumu");
                    break;
                }
            }

            // Bonus objesini yok et
            Destroy(gameObject);
        }
    }
}