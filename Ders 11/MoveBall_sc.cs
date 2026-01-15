using UnityEngine;

public class MoveBall_sc : MonoBehaviour
{
    Vector3 ballStartPosition;
    Rigidbody2D rb;
    float speed = 400;
    public AudioSource blip;
    public AudioSource blop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        ballStartPosition = this.transform.position;
        ResetBall();
        
    }

    void OnCollisionEnter2D(Collision2D col){

        if(col.gameObject.tag =="backwall")
            blop.Play();
        else
            blip.Play();
    }

    public void ResetBall(){
        this.transform.position = ballStartPosition;
        rb.linearVelocity = Vector3.zero;
        Vector3 dlr = new Vector3(Random.Range(100,300), Random.Range(-100,100),0).normalized;
        rb.AddForce(dlr*speed);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown("space")){
        ResetBall();
       } 
    }
}
