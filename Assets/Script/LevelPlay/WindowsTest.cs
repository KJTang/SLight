using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class WindowsTest : MonoBehaviour
{

    public GUISkin customSkin;
    //public Texture2D OKButton;  
    //public Texture2D cancelButton;
    public Texture2D exitButton;
    private bool showExitWindow = false;
    public string levelName;

    public List<string> pauseButtonEnable = new List<string>();

    void Start()
    {

    }

    void Update()
    {

    }

    void OnGUI()
    {
        GUI.skin = customSkin;
        bool enablePauseBtn = false;
        for (int i = 0; i != pauseButtonEnable.Count; ++i)
        {
            if (("Scene/" + pauseButtonEnable[i]) == SceneManager.GetActiveScene().name)
            {
                enablePauseBtn = true;
                break;
            }
        }
        if (enablePauseBtn && GUI.Button(new Rect(10, 10, 160, 160), exitButton))
        {
            showExitWindow = true;
        }
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity,
            new Vector3(Screen.width / 800.0f, Screen.height / 600.0f, 1));


        if (showExitWindow)
        {
            GameKernel.inputManager.Enable = false;
            GUI.Window(0, new Rect(0, 0, 800, 600), DoMyWindow, "");
            Time.timeScale = 0;
        }
    }

    void DoMyWindow(int winID)
    {
        if (GUI.Button(new Rect(207, 250, 120, 120), ""))
        {
            GameKernel.inputManager.Enable = true;
            showExitWindow = false;
            Time.timeScale = 1;
        }

        if (GUI.Button(new Rect(437, 250, 120, 120), ""))
        {
            LevelState.current_savepoints = 0;
            GameKernel.levelManager.ChangeLevel(
           GameKernel.levelManager.CreateCommonLevel(levelName),
           true
        );
            showExitWindow = false;
            Time.timeScale = 1;
        }
    }
}
