using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Jump : MonoBehaviour
{

    TextAsset file;
    string[] lines;
    List<float> emg_values;
    List<float> filtered_emg_values;
    int helper = 0;

    // Start is called before the first frame update
    void Start()
    {
        emg_values = new List<float>();
        filtered_emg_values = new List<float>();
        file = (TextAsset)Resources.Load("data_converted");
        lines = file.text.Split('\n');
        for (float i = 0; i < lines.Length - 1; i++)
        {
            if (i >= 3)
            {
                string[] current_line = lines[(int) i].Split('\t');
                emg_values.Add(float.Parse(current_line[5]));
                if (emg_values[emg_values.Count - 1] > 0.5 && i - 1000 > helper)
                {
                    Debug.Log("@" + i / 1000 + " found: " + emg_values[emg_values.Count - 1]);
                    filtered_emg_values.Add(emg_values[emg_values.Count - 1]);
                    helper = (int) i;
                }
                else
                {
                    continue;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}
