using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : IGameManager {
    public Level curLevel = null;

    private bool initTransition = true;
    private int timer = 0;

    public void Init() {
        // Debug.Log("LevelManager Init");
    }

    public void Update() {
        if (curLevel != null) {
            curLevel.Update();
        }
        if (!initTransition) {
            ++timer;
            // wait 1 frame, cause SceneManager.LoadScene() take effect in next frame
            if (timer > 1) {
                initTransition = true;
                timer = 0;
                curLevel.OnEnter();
            }
        }
    }

    public void Destroy() {
        // Debug.Log("LevelManager Destroy");
    }

    public void ChangeLevel(Level level, bool useTransistion = false) {
        // Debug.Log("LevelManager ChangeLevel");
        if (curLevel != null) {
            curLevel.OnExit();
            curLevel = null;
        }
        curLevel = level;
        if (useTransistion) {
            SceneManager.LoadScene("Scene/TransitionScene");
            initTransition = false;
        } else {
            curLevel.OnEnter();
        }
    }
}