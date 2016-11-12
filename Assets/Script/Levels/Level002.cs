using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level002 : Level {
    public Level002() {
        name = "Level002";
    }

    public override void OnEnter() {
        SceneManager.LoadSceneAsync("Scene/Level002");
        GameKernel.inputManager.Enable = true;
    }

    public override void Update() {}
    
    public override void OnExit() {
        GameKernel.inputManager.Enable = false;
    }
}