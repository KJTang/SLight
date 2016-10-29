using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level001 : Level {
    public Level001() {
        name = "Level001";
    }

    public override void OnEnter() {
        SceneManager.LoadSceneAsync("Scene/Level001");
        GameKernel.inputManager.Enable = true;
    }

    public override void Update() {}
    
    public override void OnExit() {
        GameKernel.inputManager.Enable = false;
    }
}