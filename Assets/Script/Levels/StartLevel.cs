using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartLevel : Level {
    public StartLevel() {
        name = "StartLevel";
    }

    public override void OnEnter() {
        SceneManager.LoadSceneAsync("Scene/StartScene");
    }

    public override void Update() {}
    
    public override void OnExit() {}

    public void ChangeToLevel(int level) {
        //
    }
}