using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Level {
    public string name;
    public Level() {
        name = "BaseLevel";
    }

    public virtual void OnEnter() {
        // Debug.Log("BaseLevel: OnEnter");
    }
    public virtual void Update() {
        // Debug.Log("BaseLevel: Update");
    }
    public virtual void OnExit() {
        // Debug.Log("BaseLevel: OnExit");
    }
}

public class CommonLevel : Level {
    public CommonLevel(string str) {
        name = str;
    }

    public override void OnEnter() {
        SceneManager.LoadSceneAsync("Scene/" + name);
        GameKernel.inputManager.Enable = true;
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    public override void Update() {
        // Debug.Log("CommonLevel: Update");
    }

    public override void OnExit() { 
        GameKernel.inputManager.Enable = false;
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    void OnSceneChanged(Scene previousScene, Scene newScene) {
        GameKernel.actionManager.ClearAll();
    }
}