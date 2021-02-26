using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    public Player player;
    public GameObject heart;
    public GameObject heart1;
    public GameObject heart2;

    void Update()
    {
        if (player.playerHealth == 3)
        {
            heart.SetActive(true);
            heart1.SetActive(true);
            heart2.SetActive(true);
        }

        if (player.playerHealth == 2)
        {
            heart.SetActive(true);
            heart1.SetActive(true);
            heart2.SetActive(false);
        }

        if (player.playerHealth == 1)
        {
            heart.SetActive(true);
            heart1.SetActive(false);
            heart2.SetActive(false);
        }

        if (player.playerHealth <= 0)
        {
            heart.SetActive(false);
            heart1.SetActive(false);
            heart2.SetActive(false);
        }
    }
    //yay

}
