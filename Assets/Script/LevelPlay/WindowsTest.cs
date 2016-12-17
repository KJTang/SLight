using UnityEngine;
using System.Collections;

public class WindowsTest : MonoBehaviour {

    public GUISkin customSkin;  
    public Texture2D OKButton;  
    public Texture2D cancelButton;
    public Texture2D exitButton;
    private bool showExitWindow = false;
    public string levelName;
    void Start()
    {

    }

    void Update()
    {

    }

    void OnGUI()
    {
        GUI.skin = customSkin;
        if (GUI.Button(new Rect(10, 10, 40, 40), exitButton))
        {
            showExitWindow = true; 
        }
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity,
            new Vector3(Screen.width / 800.0f, Screen.height / 600.0f, 1));


        if (showExitWindow)
        {
            GUI.Window(0,new Rect(0, 0, 800, 600),DoMyWindow, "");
            Time.timeScale = 0;
        }
    }

    void DoMyWindow(int winID)
    {
        if (GUI.Button(new Rect(207, 250, 120, 120), cancelButton))
        {
            showExitWindow = false;
            Time.timeScale = 1;
        }
        
        if (GUI.Button(new Rect(437, 250,120, 120), OKButton))
        {
            GameKernel.levelManager.ChangeLevel(
           GameKernel.levelManager.CreateCommonLevel(levelName),
           true
        );
            showExitWindow = false;
            Time.timeScale = 1;
        }
    }
}
