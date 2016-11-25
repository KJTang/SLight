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
    public string name;

    public CommonLevel(string str) {
        Debug.Log(str);
        name = str;
    }

    public override void OnEnter() {
        SceneManager.LoadSceneAsync("Scene/" + name);
        GameKernel.inputManager.Enable = true;
    }

    public override void Update() {
        // Debug.Log("CommonLevel: Update");
    }

    public override void OnExit() {
        GameKernel.inputManager.Enable = false;
    }
}