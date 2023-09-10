﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarCnt : MonoBehaviour
{
    Vector2     velo;
    float       axisH;
    float       axisV;
    
    Rigidbody2D rbody;
    bool        isMoving = false;

    GameObject  SquareWR;
    GameObject  SquareWL;
    GameObject  CircleWR;
    GameObject  CircleWL;

    GameObject  bar;

    void Start()
    {
        bar = GameObject.FindGameObjectWithTag("Bar");
        rbody = GetComponent<Rigidbody2D>();
        SquareWR = GameObject.Find("SquareWR");
        SquareWL = GameObject.Find("SquareWL");
        CircleWR = GameObject.Find("CircleWR");
        CircleWL = GameObject.Find("CircleWL");
        SquareWR.SetActive(false);
        SquareWL.SetActive(false);
        CircleWR.SetActive(false);
        CircleWL.SetActive(false);
    }

    void Update()
    {
        //GameObject bar = GameObject.FindGameObjectWithTag("Bar");
        int BarLength = bar.GetComponent<GameMgr>().getBarLength();
        if (BarLength == 0)
        {
            SquareWR.SetActive(false);
            SquareWL.SetActive(false);
            CircleWR.SetActive(false);
            CircleWL.SetActive(false);
        }
        else
        {
            SquareWR.SetActive(true);
            SquareWL.SetActive(true);
            CircleWR.SetActive(true);
            CircleWL.SetActive(true);
        }

        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");
            axisV = Input.GetAxisRaw("Vertical");
        }
        axisV = 0;
    }

    void FixedUpdate()
    {
        //GameObject bar = GameObject.FindGameObjectWithTag("Bar");
        float barSpeed = bar.GetComponent<GameMgr>().getBarSpeed();
        velo = new Vector2(axisH, axisV) * barSpeed;
        rbody.velocity = velo;
    }

    public void SetAxis(float h, float v)
    {
        axisH = h;
        axisV = v;
        if (axisH == 0 && axisV == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

}
