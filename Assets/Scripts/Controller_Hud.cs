using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public Text gameOverText;

    public static bool gameOver;

    public static int points;

    public Text pointsText;

    public Text powerUpText;

    private Controller_Player player;

    void Start()
    {
        gameOver = false;
        gameOverText.gameObject.SetActive(false);
        points = 0;
        player = GameObject.Find("Player").GetComponent<Controller_Player>();
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over" ;
            gameOverText.gameObject.SetActive(true);
        }
        if (player!=null)
        {
            if (player.powerUpCount <= 0)
            {
                powerUpText.text = "PowerUp: None";
            }
            else if (player.powerUpCount == 1)
            {
                powerUpText.text = "PowerUp: Speed Up";
            }
            else if (player.powerUpCount == 2)
            {
                powerUpText.text = "PowerUp: Missile";
            }
            else if (player.powerUpCount == 3)
            {
                powerUpText.text = "PowerUp: Double shoot";
            }
            else if (player.powerUpCount == 4)
            {
                powerUpText.text = "PowerUp: Laser";
            }
            else if (player.powerUpCount == 5)
            {
                powerUpText.text = "PowerUp: Option";
            }
            else if (player.powerUpCount >= 6)
            {
                powerUpText.text = "PowerUp: Shield";
            }
        }
        pointsText.text = "Score: " + points.ToString();
    }
}
