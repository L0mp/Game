using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public GameObject RestartMenuPanel;
    public GameObject Player;
    
    
    
    bool gameOver = false;

    public Text endtext;
    public int pointsToWin;

    public GameObject[] healthPointArray;
    public static bool healthGained;
    public static bool healthLost;

    public static bool slowTime;
    public static bool invincibilty;

    public float slowTimeDelay;
    public float timeFromSlow;
    public float invincibltyDelay;
    public float timeFromInvicibilty;


    public int healthPoints = 3;

    public static float GameSpeed;

    public void SlowTimeActive()
    {
        GameSpeed = 2;
        if (timeFromSlow >= slowTimeDelay)
        {
            slowTime = false;
            GameSpeed = 4;
            timeFromSlow = 0;
        }
        timeFromSlow += Time.deltaTime;
    }
    public void InvincibiltyActive()
    {

        if (timeFromInvicibilty >= invincibltyDelay)
        {
            invincibilty = false;
            timeFromInvicibilty = 0;
        }
        timeFromInvicibilty += Time.deltaTime;
    }


    public void HealthGained() 
    {
        if (healthPoints < 3) 
        {
            healthPoints++;
        }
        if (healthPoints == 3)
        {
            healthPointArray[2].SetActive(true);
        }
        if (healthPoints == 2)
        {
            healthPointArray[1].SetActive(true);
        }
        healthGained = false;
    }
    public void HealthLost()
    {
        
        healthPoints--;
                    
            
            if (healthPoints == 2)
            {
                healthPointArray[2].SetActive(false);
            }
        if (healthPoints == 1)
            {
                healthPointArray[1].SetActive(false);
            }
        if (healthPoints == 0)
        {
            healthPointArray[0].SetActive(false);
            gameOver = true;
        }
        healthLost = false;

	}
	                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
	void Start()
    {
        
        RestartMenuPanel.gameObject.SetActive(false);
        GameSpeed = 4;
        healthGained = false;
        healthLost = false;
        slowTime = false;
        invincibilty = false;

    }

    void Update()
    {
        if (gameOver)
        {
            RestartMenuPanel.gameObject.SetActive(true);
            Player.gameObject.SetActive(false);
        }
        if (healthGained == true)
        {
            HealthGained();
        }
        if (healthLost == true && invincibilty == false)
        {
            HealthLost();
        }
        if (PlayerControler.numberOfPoints >= pointsToWin)
        {			
            gameOver = true;
        }
    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
        PlayerControler.numberOfPoints = 0;
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }
}
