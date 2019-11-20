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

    void Start()
    {
        cam = Camera.main;
        jumps = Manager.GetComponent<Processing>().jump_time_instances;
        movement = Manager.GetComponent<Processing>().emg_values;
        start = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    void Update()
    {
        tick_speed += Time.deltaTime;
        timer = (double) (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - start)/1000;
        while (tick_speed >= 0.1) {
            Tick();
            tick_speed -= 0.1;
        }

    }

    void Tick()
    {
        Debug.Log(timer);
        current_position = cam.transform.position;
        current_position.x += 1;
        if (cam.transform.position.y > 0)
        {
            current_position.y--;
        }
        if (jumps.Count > 0 && (timer >= jumps[0] - 0.05 && timer <= jumps[0] + 0.05))
        {
            jumps.RemoveAt(0);
            current_position.y += 3;
        }
        cam.transform.position = current_position;
    }
}
