using Unity.VisualScripting;
using UnityEngine;

public class Laser_sc : MonoBehaviour
{

    [SerializeField]
    private float speed = 10f;
    

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position += new Vector3(0f, 0.25f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        if(transform.position.y > 7.61f)
        {
            Destroy(this.gameObject);
        }

    }
}