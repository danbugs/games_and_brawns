using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Movement : MonoBehaviour
{
    Camera cam;
    Vector3 current_position;
    [SerializeField]
    GameObject Manager;
    List<float> jumps;
    List<float> movement;
    double start;
    double timer;
    double tick_speed;
    Animator anim;

    void Start()
    {
        cam = Camera.main;
        jumps = Manager.GetComponent<Processing>().jump_time_instances;
        movement = Manager.GetComponent<Processing>().emg_values;
        start = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        anim = GameObject.FindGameObjectWithTag("player").GetComponent<Animator>();
    }

    void Update()
    {
        tick_speed += Time.deltaTime;
        timer = (double) (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - start)/1000;
        current_position = cam.transform.position;
        if (Input.GetKeyDown("space"))
        {
            current_position.y += 3;
        }
        while (tick_speed >= 0.1) {
            Tick();
            tick_speed -= 0.1;
        }
        cam.transform.position = current_position;

    }

    void Tick()
    {
        current_position.x += 1;
        if (cam.transform.position.y > 0)
        {
            current_position.y--;
        }
        if (jumps.Count > 0 && (timer >= jumps[0] - 0.1 && timer <= jumps[0] + 0.1))
        {

            jumps.RemoveAt(0);
            current_position.y += 3;
        }
        anim.SetFloat("jump", current_position.y);
        cam.transform.position = current_position;
    }
}
