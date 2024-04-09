using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Controller_Player._Player.gameObject.SetActive(true);
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}
