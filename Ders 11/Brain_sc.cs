using System.IO.Pipes;
using System.Numerics;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Brain_sc : MonoBehaviour
{

    public GameObject paddle;
    public GameObject ball;
    Rigidbody2D brb;
    float yvel;
    float paddleMinY = 8.8f;
    float paddleMaxY = 17.4f;
    float paddleMaxSpeed = 15;
    public float numSaved = 0;
    public float numMissed = 0;
    AnonymousPipeClientStream ann;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ann = new AnonymousPipeClientStream(6,1,1,4,0.11);
        brb = ball.GetComponent<Rigidbody2D>();  
    }

    List<double> Run(double bx, double by, double bvx, double bvy,
                        double px, double py, double pv, bool train)
    {
        List<double> inputs = new List<double>();
        List<double> outputs = new List<double>();
        inputs.Add(bx);
        inputs.Add(by);
        inputs.Add(bvx);
        inputs.Add(bvy);
        inputs.Add(px);
        inputs.Add(py);
        outputs.Add(pv);
        if(train)
            return (ann.Train(inputs,outputs));
        else
            return (ann.CalcOutput(inputs,outputs));
    }

    // Update is called once per frame
    void Update()
    {
        float posy = MathF.Clamp(paddle.transform.position.y+(yvel*Time.deltaTime*paddleMaxSpeed),
                                    paddleMinY, paddleMaxY);
        paddle.transform.position = new Vector3(paddle.transform.position.x, posy, paddle.transform.position.z);
        List<double> output = new List<double>();
        int layerMask = 1 << 9;
        RaycastHit2D hit = Physics2D.Raycast(ball.transform.position, brb.linearVelocity, 1000, layerMask);

        if(hit.collider != null)
        {
            if(hit.collider != null && hit.collider.gameObject.tag == "backwall")
            {
                float dy = (hit.point.y - paddle.transform.position.y);

                output = Run(ball.transform.position.x,
                                ball.transform.position.y,
                                brb.linearVelocity.x, brb.linearVelocity.y,
                                paddle.transform.position.x,
                                paddle.transform.position.y,
                                dyitrue);
                yvel = (float) output[0];
            }
        }
        else 
        yvel =0;
    }
}
