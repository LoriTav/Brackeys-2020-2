using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class PauseManu : MonoBehaviour
{
    public Canvas PauseCanvas;
    public Canvas ControlsCanvas;
    public Canvas SettingsCanvas;
    public Canvas InstructionsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        PauseCanvas.enabled = false;
        ControlsCanvas.enabled = false;
        SettingsCanvas.enabled = false;
        InstructionsCanvas.enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                PauseGame();
            }

            else
            {
                ResumeGame();
            }
        }
    }

    public void ResumeGame()
    {
        PauseCanvas.enabled = false;
        ControlsCanvas.enabled = false;
        SettingsCanvas.enabled = false;
        InstructionsCanvas.enabled = false;
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        PauseCanvas.enabled = true;
        ControlsCanvas.enabled = false;
        SettingsCanvas.enabled = false;
        InstructionsCanvas.enabled = false;
        Time.timeScale = 0;
    }

    public void PressedControls()
    {
        PauseCanvas.enabled = false;
        ControlsCanvas.enabled = true;
        SettingsCanvas.enabled = false;
        InstructionsCanvas.enabled = false;
    }

    public void PressedInstructions()
    {
        PauseCanvas.enabled = false;
        ControlsCanvas.enabled = false;
        SettingsCanvas.enabled = false;
        InstructionsCanvas.enabled = true;
    }

    public void PressedSettings()
    {
        PauseCanvas.enabled = false;
        ControlsCanvas.enabled = false;
        SettingsCanvas.enabled = true;
        InstructionsCanvas.enabled = false;
    }

    public void PressedBack()
    {
        PauseCanvas.enabled = true;
        ControlsCanvas.enabled = false;
        SettingsCanvas.enabled = false;
        InstructionsCanvas.enabled = false;
    }

    public void PressedQuit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
