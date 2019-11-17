using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    Camera cam;
    Vector3 current_position;
    float timer = 0;
    [SerializeField]
    GameObject Manager;
    List<float> jumps;
    List<float> movement;
    const float tick_speed = 0.1f;

    void Start()
    {
        cam = Camera.main;
        jumps = Manager.GetComponent<Processing>().jump_time_instances;
        movement = Manager.GetComponent<Processing>().emg_values;
    }

    void Update()
    {
        timer += (Time.deltaTime) % 60;
        current_position = cam.transform.position;

        if(timer % tick_speed >=  0 - 0.01 && timer % tick_speed <= 0 + 0.01)
        {
            current_position.x += 1;
            if (current_position.y > 0)
            {
                current_position.y -= 1;
            }
        }

        if (jumps.Count > 0 && (timer >= jumps[0] - 0.01 && timer <= jumps[0] + 0.01))
        {
            //Debug.Log(timer + " = " + jumps[0]);
            jumps.RemoveAt(0);
            current_position.y += 2;
        }

        cam.transform.position = current_position;
    }
}
