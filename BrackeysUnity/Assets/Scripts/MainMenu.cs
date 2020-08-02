using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class MainMenu : MonoBehaviour
{
    public Canvas StartCanvas;
    public Canvas ControlsCanvas;
    public Canvas SettingsCanvas;
    public Canvas InstructionsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        StartCanvas.enabled = true;
        ControlsCanvas.enabled = false;
        SettingsCanvas.enabled = false;
        InstructionsCanvas.enabled = false;
    }

    public void PressedStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PressedControls()
    {
        StartCanvas.enabled = false;
        ControlsCanvas.enabled = true;
        SettingsCanvas.enabled = false;
        InstructionsCanvas.enabled = false;
    }

    public void PressedInstructions()
    {
        StartCanvas.enabled = false;
        ControlsCanvas.enabled = false;
        SettingsCanvas.enabled = false;
        InstructionsCanvas.enabled = true;
    }

    public void PressedSettings()
    {
        StartCanvas.enabled = false;
        ControlsCanvas.enabled = false;
        SettingsCanvas.enabled = true;
        InstructionsCanvas.enabled = false;
    }

    public void PressedBack()
    {
        StartCanvas.enabled = true;
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
