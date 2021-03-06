﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collision : MonoBehaviour
{

    

    [Header("Materials")]
    public MaterialManager material;
	public ScoreManager score;
    public Cube cube;
    Blinker blinker;
    int i = 0;
    // Start is called before the first frame update

    AudioPlayer player;


    void Start()
    {
        blinker = GetComponent<Blinker>();
        player = GetComponent<AudioPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject gOther = other.gameObject;
        //Debug.Log(gOther.tag);
        if(gOther.tag == "P")
        {
            player.playCoin();
            blinker.blink();
        	Destroy(gOther);
        	score.increment();
            //Debug.Log("UP");
        }
        else
        if(gOther.tag == "B")
        {
            player.playHertz();
            blinker.blinkCyan();
            Destroy(gOther);
            score.incrementHertz();
            //Debug.Log("UP");
        }
        else
        if(gOther.tag == "CC")
        {
            cube.CollideGreen();
        }
        else
        if(gOther.tag == "CP")
        {
            cube.CollideGreen(true);
        }
        else
        if(gOther.tag == "CT")
        {
            cube.CollideGreenTrig();
        }
        else
        if(gOther.tag == "T")
        {
            if(!cube.powerUp)
            {
                material.startRed();
                cube.startRed();
                player.playTrig();
            }
            else
                score.incrementMult();
            Destroy(gOther);
        }
        else
        if(gOther.tag == "T2")
        {
            if(!cube.powerUp)
            {
                material.startGreen();
                cube.startRed();
                player.playTrig();
            }
            else
                score.incrementMult();
            Destroy(gOther);
        }
        else
        if(gOther.tag == "T3")
        {
            if(!cube.powerUp)
            {
                material.startBlue();
                cube.startBlue();
                player.playTrig();
            }
            else
                score.incrementMult();
            Destroy(gOther);
        }
    }
}
