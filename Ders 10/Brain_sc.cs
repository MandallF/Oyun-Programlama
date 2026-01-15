using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityStandartAssets.Chracter;
[RequireComponent(typeof(ThirdPersonChracter))]
public class Brain_sc : MonoBehaviour
{
    int DNAlenght=1;
    public float timeAlive=0;
    public DNA_sc dna_sc;
    private ThirdPersonChracter chracter;
    bool isAlive=true;
    Vector3 mVector;
    bool isJumping;

    Vector3 sPos;
    public float distanceTraveled=0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //read dna
        float h=0;
        float v=0;
        bool crouch = false;
        if(dna_sc.getGene(0)==0) v=1;
        else if (dna_sc.getGene(0)==1) v=-1;
        else if (dna_sc.getGene(0)==2) h=-1;
        else if (dna_sc.getGene(0)==3) h=1;
        else if (dna_sc.getGene(0)==4) isJumping=true;
        else if (dna_sc.getGene(0)==5) crouch=true;

        mVector=v*Vector3.forward + h*Vector3.right;
        
        isJumping=false;
        if (isAlive)
        {
            chracter.Move(mVector, crouch, isJumping);
            timeAlive += Time.deltaTime;
            distanceTraveled = Vector3.Distance(this.transform.position, sPos);
        }
        isJumping = false;
    }
    void OnCollisonEnter (Collison other)
    {
        if(other.gameObject.tag == "dead")
        {
            isAlive = false;
        }
    }
    public void Init()
    {
        //ileri
        //geri
        //sol
        //sağ
        //zıpla
        //çök
        dna_sc = new DNA_sc(DNAlenght,6);
        chracter = GetComponent<ThirdPersonChracter>();
        timeAlive = 0;
        isAlive=true;
        sPos = this.tranform.position;
    }
}
