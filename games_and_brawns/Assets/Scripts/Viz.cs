using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viz : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (VARIABLES.viz)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("death"))
            {
                go.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
