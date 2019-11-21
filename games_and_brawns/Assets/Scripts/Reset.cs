using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("hud").transform.GetChild(0).gameObject.SetActive(true);
            if (!VARIABLES.viz && gameObject.CompareTag("start")) GameObject.FindGameObjectWithTag("hud").transform.GetChild(1).gameObject.SetActive(true);
            VARIABLES.viz = !VARIABLES.viz;
        }
    }
}
