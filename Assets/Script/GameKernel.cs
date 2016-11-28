using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;
using System.Collections.Generic;

public interface IGameManager {
    void Init();
    void Update();
    void Destroy();
}

public class GameKernel : MonoBehaviour {
    public static LevelManager levelManager = new LevelManager();
    public static InputManager inputManager = new InputManager();
    public static ActionManager actionManager = new ActionManager();
    public static EventManager eventManager = new EventManager();
    public static ResourceManager resourceManager = new ResourceManager();
    // public static ActorManager actorManager = new ActorManager();
    // public static FileManager fileManager = new FileManager();

    List<IGameManager> gameManagers = new List<IGameManager>();

    void Awake() {
        // won't destroy after change scene
        DontDestroyOnLoad(transform.gameObject);

        gameManagers.Add(levelManager);
        gameManagers.Add(inputManager);
        gameManagers.Add(actionManager);
        gameManagers.Add(eventManager);
        gameManagers.Add(resourceManager);
        // gameManagers.Add(actorManager);
        // gameManagers.Add(fileManager);

        for (int i = 0; i != gameManagers.Count; ++i) {
            gameManagers[i].Init();
        }
    }

    void Start() {
        // levelManager.ChangeLevel(levelManager.CreateCommonLevel("LevelA1"), true);
        // levelManager.ChangeLevel(new Level002(), true);
        // Debugging
        inputManager.Enable = true;
    }
    
    void Update() {
        for (int i = 0; i != gameManagers.Count; ++i) {
            gameManagers[i].Update();
        }
    }

    void OnDestroy() {
        for (int i = 0; i != gameManagers.Count; ++i) {
            gameManagers[i].Destroy();
            gameManagers[i] = null;
        }
    }
}
