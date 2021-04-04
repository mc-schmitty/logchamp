using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndScripts : MonoBehaviour
{

    public int nextLevel;

    public void loadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void mainMenu()
    {
        //Please do not change the order of the main menu in the scene heirarchy
        SceneManager.LoadScene(0);
    }

    public void reload()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


}
