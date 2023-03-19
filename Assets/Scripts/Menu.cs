using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu, mainMenu, creditsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        mainMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Quit() {
        Application.Quit();
    }

    public void LoadCredits() {
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void LoadMainMenu() {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

}
