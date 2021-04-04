using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCon : MonoBehaviour
{
    //The win con must track this one manually because there are never extreme numbers of cabins in one level
    //Give the number of cabins in this level
    public int cabins;
    int completedCabins;

    //These win cons are tracked by other managers
    public bool targets;
    public bool trees;
    public bool timer;
    public double timeLimit;

    bool targetsDone = false;
    bool treesDone = false;
    double timeLeft;

    //I'm working with the canvas GameObjects rather than the compoenents here
    public GameObject neutral;
    public GameObject victory;
    public GameObject defeat;
    public PlayermodelManager player;

    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        completedCabins = 0;
        if (!targets)
        {
            targetsDone = true;
        }
        if (!trees)
        {
            treesDone = true;
        }
        if (timer)
        {
            timeLeft = timeLimit;
        }
        else
        {
            timeLeft = 1;
        }
        
    }

    void Update()
    {
        if (timer)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                lose();
            }
        }

    }

    public void CabinBuilt()
    {
        completedCabins++;
        winCheck();
    }

    public void treesChopped()
    {
        treesDone = true;
        winCheck();
    }

    public void targetUpdate(bool goodEnding)
    {
        if (goodEnding)
        {
            targetsDone = true;
            winCheck();
        }
        else
        {
            lose();
        }
    }

    public void PlayerDeath()
    {
        lose();
    }

    void winCheck()
    {
        if (completedCabins == cabins && treesDone && targetsDone && !gameOver)
        {
            timer = false;
            gameOver = true;
            neutral.SetActive(false);
            victory.SetActive(true);
            UnityEngine.Debug.Log("You win!");
        }
    }

    void lose()
    {
        if (!gameOver)
        {
            gameOver = true;
            player.ExplodeAll();
            neutral.SetActive(false);
            defeat.SetActive(true);
            UnityEngine.Debug.Log("You lose!");
        }

    }
}
