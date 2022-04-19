using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public static bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if (paused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume() {
        PausePanel.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
    }

    public void Pause() {
        PausePanel.SetActive(true);
        paused = true;
        Time.timeScale = 0f;
    }

    public void Exit() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
