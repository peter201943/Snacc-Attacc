using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Transform quitBox;
    public Transform controlScreen;
    public Transform creditScreen;

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene("Story1Scene");
        Time.timeScale = 1;
    }
    public void CallControls()
    {
        if (controlScreen.gameObject.activeInHierarchy == false)
        {
            controlScreen.gameObject.SetActive(true);
        }
        else
        {
            controlScreen.gameObject.SetActive(false);
        }
    }
    public void CallCredits()
    {
        if (creditScreen.gameObject.activeInHierarchy == false)
        {
            creditScreen.gameObject.SetActive(true);
        }
        else
        {
            creditScreen.gameObject.SetActive(false);
        }
    }
    public void CallQuit()
    {
        if (quitBox.gameObject.activeInHierarchy == false)
        {
            quitBox.gameObject.SetActive(true);
        }
        else
        {
            quitBox.gameObject.SetActive(false);
        }
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}