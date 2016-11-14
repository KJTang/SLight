using UnityEngine;
// using UnityEngine.Assertions;
using System.Collections;
using System.Collections.Generic;

public enum InputKey {
    Left, Right, Up, Down, 
    Jump, Action
};

public class InputManager : IGameManager {
    struct KeyInfo {
        public bool keyStatus;
        public bool keyUp;
        public bool keyDown;
        public KeyInfo(bool status, bool up, bool down) {
            keyStatus = status;
            keyUp = up;
            keyDown = down;
        }
    }
    private Dictionary<InputKey, KeyInfo> inputDict = new Dictionary<InputKey, KeyInfo>(10);

    private bool enable = false;
    public bool Enable {
        get {
            return enable;
        }
        set {
            enable = value;
            if (value == false) {
                List<InputKey> keys = new List<InputKey>(inputDict.Keys);
                foreach (InputKey key in keys) {
                    KeyInfo info = inputDict[key];
                    info.keyUp = false;
                    info.keyDown = false;
                    info.keyStatus = false;
                    inputDict[key] = info;
                }
            }
        }
    }

    public void Init() {
        inputDict.Add(InputKey.Left, new KeyInfo(false, false, false));
        inputDict.Add(InputKey.Right, new KeyInfo(false, false, false));
        inputDict.Add(InputKey.Up, new KeyInfo(false, false, false));
        inputDict.Add(InputKey.Down, new KeyInfo(false, false, false));
        inputDict.Add(InputKey.Jump, new KeyInfo(false, false, false));
        inputDict.Add(InputKey.Action, new KeyInfo(false, false, false));

        #if UNITY_IOS || UNITY_ANDROID
        InitInputOnMobile();
        #endif
        #if UNITY_WINDOWS || UNITY_LINUX || UNITY_EDITOR
        InitInputOnPC();
        #endif
    }

    public void Update() {
        if (enable) {
            DetectInput();
        }
    }

    public void Destroy() {}

    void DetectInput() {
        #if UNITY_IOS || UNITY_ANDROID
        DetectInputOnMobile();
        #endif
        #if UNITY_WINDOWS || UNITY_LINUX || UNITY_EDITOR
        DetectInputOnPC();
        #endif

        // InputTest();
    }

    #if UNITY_IOS || UNITY_ANDROID
    void InitInputOnMobile() {
        // TODO: 
    }

    void DetectInputOnMobile() {
        // TODO: 
    }
    #endif

    #if UNITY_WINDOWS || UNITY_LINUX || UNITY_EDITOR
    private Dictionary<InputKey, KeyCode> keyMap = new Dictionary<InputKey, KeyCode>(10);    

    void InitInputOnPC() {
        keyMap.Add(InputKey.Left, KeyCode.A);
        keyMap.Add(InputKey.Right, KeyCode.D);
        keyMap.Add(InputKey.Up, KeyCode.W);
        keyMap.Add(InputKey.Down, KeyCode.S);
        keyMap.Add(InputKey.Jump, KeyCode.J);
        keyMap.Add(InputKey.Action, KeyCode.K);
    }

    void DetectInputOnPC() {
        List<InputKey> keys = new List<InputKey>(inputDict.Keys);
        foreach (InputKey key in keys) {
            KeyInfo info = inputDict[key];
            info.keyUp = Input.GetKeyUp(keyMap[key]);
            info.keyDown = Input.GetKeyDown(keyMap[key]);
            info.keyStatus = Input.GetKey(keyMap[key]);
            inputDict[key] = info;
        }
    }
    #endif    

    void InputTest() {
        Debug.Log("Left: " + (GetKey(InputKey.Left) ? "true" : "false") + " " + 
            "Right: " + (GetKey(InputKey.Right) ? "true" : "false") + " " + 
            "Up: " + (GetKey(InputKey.Up) ? "true" : "false") + " " + 
            "Down: " + (GetKey(InputKey.Down) ? "true" : "false") + " " + 
            "Jump: " + (GetKey(InputKey.Jump) ? "true" : "false") + " " + 
            "Action: " + (GetKey(InputKey.Action) ? "true" : "false")
        );
    }

    public bool GetKeyDown(InputKey k) {
        return inputDict[k].keyDown;
    }

    public bool GetKeyUp(InputKey k) {
        return inputDict[k].keyUp;
    }

    public bool GetKey(InputKey k) {
        return inputDict[k].keyStatus;
    }
}