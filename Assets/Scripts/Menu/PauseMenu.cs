using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    
    [SerializeField] private GameObject _pauseMenu;
    private bool isGamePaused = false;
    MouseLook _mouseLook;
    private void Start() {
        _pauseMenu.SetActive(false);
        _mouseLook = GameObject.FindWithTag("Player").GetComponent<MouseLook>();
    }

    private void Update() {
        if (Input.GetButtonDown("Cancel")) {
            if (isGamePaused) {
                ResumeGame();                
            } else {
                PauseGame(); 
            }
        }
    }
    
    public void PauseGame() {
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
        isGamePaused = true;

        _mouseLook.showMouse = true;
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
        _pauseMenu.SetActive(false);
        isGamePaused = false;

        _mouseLook.showMouse = false;
    }

    public void LoadMenu() {
        // Prints error, we need to build the game
        SceneManager.LoadScene("Menu"); 
    }

    public void QuitGame() {
        Application.Quit();
    }
}