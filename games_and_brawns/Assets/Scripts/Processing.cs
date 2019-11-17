using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Processing : MonoBehaviour
{

    TextAsset file;
    string[] lines;
    public List<float> emg_values;
    public List<float> jump_time_instances;
    int findpeaks_helper = 0;

    void Awake()
    {
        emg_values = new List<float>();
        jump_time_instances = new List<float>();
        //Debug.Log("LOADED");
        file = (TextAsset)Resources.Load("data_converted");
        lines = file.text.Split('\n');
        for (float i = 0; i < lines.Length - 1; i++)
        {
            if (i >= 3)
            {
                string[] current_line = lines[(int) i].Split('\t');
                emg_values.Add(float.Parse(current_line[5]));
                if (emg_values.Count > 0 && emg_values[emg_values.Count - 1] > 0.3 && i - 1000 > findpeaks_helper)
                {
                    //Debug.Log("@" + i / 1000 + " found: " + emg_values[emg_values.Count - 1]);
                    jump_time_instances.Add(i / 1000);
                    findpeaks_helper = (int) i;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
