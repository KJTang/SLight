using UnityEngine;
// using UnityEngine.Assertions;
using System;
using System.Collections;
using System.Collections.Generic;

public enum InputKey {
    None, 
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
    private int leftFinger = -1, rightFinger = -1;
    private Vector2 leftFingerPos, rightFingerPos;
    private InputKey leftFingerState = InputKey.None, lastLeftFingerState = InputKey.None;
    private InputKey rightFingerState = InputKey.None, lastRightFingerState = InputKey.None;
    private float leftFingerOffset = 50.0f, rightFingerOffset = 100.0f;
    private int rightFingerCount = 0, rightFingerMaxCount = 30;

    void InitInputOnMobile() {}

    void DetectInputOnMobile() {
        // clear 
        if (lastLeftFingerState != InputKey.None) {
            KeyInfo info = inputDict[lastLeftFingerState];
            info.keyUp = false;
            inputDict[lastLeftFingerState] = info;
            lastLeftFingerState = InputKey.None;
        }
        if (lastRightFingerState != InputKey.None) {
            KeyInfo info = inputDict[lastRightFingerState];
            info.keyUp = false;
            inputDict[lastRightFingerState] = info;
            lastRightFingerState = InputKey.None;
        }
        // detect
        for (int i = 0; i != Input.touchCount; ++i) {
            Touch currentTouch = Input.GetTouch(i);
            if (currentTouch.phase == TouchPhase.Began) {
                OnTouchBegan(currentTouch);
            }
            if (currentTouch.phase == TouchPhase.Moved) {
                OnTouchMoved(currentTouch);
            }
            if (currentTouch.phase == TouchPhase.Ended) {
                OnTouchEnded(currentTouch);
            }
        }
    }

    void OnTouchBegan(Touch currentTouch) {
        if (leftFinger == -1 && currentTouch.position.x <= Screen.width / 2) {
            leftFinger = currentTouch.fingerId;
            leftFingerPos = currentTouch.position;
        }
        if (rightFinger == -1 && currentTouch.position.x >= Screen.width / 2) {
            rightFinger = currentTouch.fingerId;
            rightFingerPos = currentTouch.position;
        }
    }

    void OnTouchMoved(Touch currentTouch) {
        if (currentTouch.fingerId == leftFinger) {
            float horizon = currentTouch.position.x - leftFingerPos.x;
            float vertical = currentTouch.position.y - leftFingerPos.y;
            switch (leftFingerState) {
                case InputKey.None: {
                    if (horizon >= leftFingerOffset) {
                        leftFingerState = InputKey.Right;
                    } else if (horizon <= -leftFingerOffset) {
                        leftFingerState = InputKey.Left;
                    }
                    if (vertical >= leftFingerOffset) {
                        leftFingerState = InputKey.Up;
                    } else if (vertical <= -leftFingerOffset) {
                        leftFingerState = InputKey.Down;
                    }
                    if (leftFingerState != InputKey.None) {
                        KeyInfo info = inputDict[leftFingerState];
                        info.keyUp = false;
                        info.keyDown = true;
                        info.keyStatus = true;
                        inputDict[leftFingerState] = info;
                    }
                    break;
                }
                case InputKey.Left: {
                    if (horizon > -leftFingerOffset) {
                        KeyInfo info = inputDict[leftFingerState];
                        info.keyUp = true;
                        info.keyDown = false;
                        info.keyStatus = false;
                        inputDict[leftFingerState] = info;
                        lastLeftFingerState = leftFingerState;
                        leftFingerState = InputKey.None;
                    }
                    break;
                }
                case InputKey.Right: {
                    if (horizon < leftFingerOffset) {
                        KeyInfo info = inputDict[leftFingerState];
                        info.keyUp = true;
                        info.keyDown = false;
                        info.keyStatus = false;
                        inputDict[leftFingerState] = info;
                        lastLeftFingerState = leftFingerState;
                        leftFingerState = InputKey.None;
                    }
                    break;
                }
                case InputKey.Up: {
                    if (vertical < leftFingerOffset) {
                        KeyInfo info = inputDict[leftFingerState];
                        info.keyUp = true;
                        info.keyDown = false;
                        info.keyStatus = false;
                        inputDict[leftFingerState] = info;
                        lastLeftFingerState = leftFingerState;
                        leftFingerState = InputKey.None;
                    }
                    break;
                }
                case InputKey.Down: {
                    if (vertical > -leftFingerOffset) {
                        KeyInfo info = inputDict[leftFingerState];
                        info.keyUp = true;
                        info.keyDown = false;
                        info.keyStatus = false;
                        inputDict[leftFingerState] = info;
                        lastLeftFingerState = leftFingerState;
                        leftFingerState = InputKey.None;
                    }
                    break;
                }
            }
        } else if (currentTouch.fingerId == rightFinger) {
            float horizon = currentTouch.position.x - rightFingerPos.x;
            float vertical = currentTouch.position.y - rightFingerPos.y;
            switch (rightFingerState) {
                case InputKey.None: {
                    // Jump
                    if (vertical >= rightFingerOffset) {
                        rightFingerState = InputKey.Jump;
                        KeyInfo info = inputDict[rightFingerState];
                        info.keyUp = false;
                        info.keyDown = true;
                        info.keyStatus = true;
                        inputDict[rightFingerState] = info;
                        break;
                    }
                    // Action
                    if (Math.Abs(horizon) < rightFingerOffset && Math.Abs(vertical) < rightFingerOffset) {
                        ++rightFingerCount;
                    } else {
                        rightFingerCount = 0;
                    }
                    if (rightFingerCount >= rightFingerMaxCount) {
                        rightFingerState = InputKey.Action;
                        KeyInfo info = inputDict[rightFingerState];
                        info.keyUp = false;
                        info.keyDown = true;
                        info.keyStatus = true;
                        inputDict[rightFingerState] = info;
                        rightFingerCount = 0;
                        break;
                    }
                    break;
                }
                case InputKey.Jump: {
                    if (vertical < rightFingerOffset) {
                        KeyInfo info = inputDict[rightFingerState];
                        info.keyUp = true;
                        info.keyDown = false;
                        info.keyStatus = false;
                        inputDict[rightFingerState] = info;
                        lastRightFingerState = rightFingerState;
                        rightFingerState = InputKey.None;
                    }
                    break;
                }
                case InputKey.Action: {
                    if (Math.Abs(horizon) >= rightFingerOffset || Math.Abs(vertical) >= rightFingerOffset) {
                        KeyInfo info = inputDict[rightFingerState];
                        info.keyUp = true;
                        info.keyDown = false;
                        info.keyStatus = false;
                        inputDict[rightFingerState] = info;
                        lastRightFingerState = rightFingerState;
                        rightFingerState = InputKey.None;
                    }
                    break;
                }
            }
        }
    }

    void OnTouchEnded(Touch currentTouch) {
        if (currentTouch.fingerId == leftFinger) {
            leftFinger = -1;
            if (leftFingerState != InputKey.None) {
                KeyInfo info = inputDict[leftFingerState];
                info.keyUp = true;
                info.keyDown = false;
                info.keyStatus = false;
                inputDict[leftFingerState] = info;
                lastLeftFingerState = leftFingerState;
                leftFingerState = InputKey.None;
            }
        } else if (currentTouch.fingerId == rightFinger) {
            rightFinger = -1;
            if (rightFingerState != InputKey.None) {
                KeyInfo info = inputDict[rightFingerState];
                info.keyUp = true;
                info.keyDown = false;
                info.keyStatus = false;
                inputDict[rightFingerState] = info;
                lastRightFingerState = rightFingerState;
                rightFingerState = InputKey.None;
            }
        }
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
        Debug.Log("Left: " + (GetKeyUp(InputKey.Left) ? "true" : "false") + " " + 
            "Right: " + (GetKeyUp(InputKey.Right) ? "true" : "false") + " " + 
            "Up: " + (GetKeyUp(InputKey.Up) ? "true" : "false") + " " + 
            "Down: " + (GetKeyUp(InputKey.Down) ? "true" : "false") + " " + 
            "Jump: " + (GetKeyUp(InputKey.Jump) ? "true" : "false") + " " + 
            "Action: " + (GetKeyUp(InputKey.Action) ? "true" : "false")
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