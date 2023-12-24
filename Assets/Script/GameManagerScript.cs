using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject pauseMenu;

    public TMP_Text scoreText;
    public TMP_Text yay;


    public int score;
    public int specialPickup;
    public int numberofSpecialForInvincibility;

    public GameObject[] specialPickups;
    // Start is called before the first frame update
    void Start()
    {
        numberofSpecialForInvincibility = 1;
        specialPickup = 0;
        specialPickups = GameObject.FindGameObjectsWithTag("SpecialPickup");
    }

    // Update is called once per frame
    void Update()
    {


        scoreText.text = "score is " + score;

        if (Input.GetKeyDown("escape"))
        {
            pauseMenu.SetActive(true);
        }

        if (specialPickup == numberofSpecialForInvincibility)
        {
            pauseMenu.SetActive(true);
            yay.text = "you win!!!";
            specialPickup = 0;
        }
    }

    public void AddScore()
    {
        score = score + 1;
    }

    public void AddSpecialPickup()
    {
        if (specialPickup < numberofSpecialForInvincibility)
        {
            specialPickup = specialPickup + 1;
        }

    }
    public void AddLose()
    {
        pauseMenu.SetActive(true);
        yay.text = "you lose!!!";
    }

}
