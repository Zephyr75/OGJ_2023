using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu, mainMenu, creditsMenu;

    private bool isPaused = true;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused) {
            Screen.SetResolution(Screen.width, Screen.height, true);
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        }
        
    }

    public void StartGame() {
        mainMenu.SetActive(false);
        isPaused = false;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void Pause() {
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void Quit() {
        Application.Quit();
        print("Quit");
    }

    public void LoadCredits() {
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void LoadMainMenu() {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Restart() {
        Application.LoadLevel(Application.loadedLevel);
    }

}
