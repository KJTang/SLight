using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum PuzzleType {
    SWITCH_ON, 
    SWITCH_OFF, 
    RANGE_IN, 
    RANGE_OUT, 
};

public enum TriggerType {
    AND, 
    OR,
};

public class Puzzle : MonoBehaviour {
    public bool isTriggered = false;
    private bool isTriggeredLastTime = false;

    public Vector2 range = new Vector2(0.0f, 0.0f);
    public TriggerType triggerType;
    public bool isPermanentChange = false;

    public List<Puzzle> puzzles = new List<Puzzle>();
    public List<PuzzleType> puzzleTypes = new List<PuzzleType>();

    void Start () {
        isTriggeredLastTime = isTriggered;
    }
	
    public virtual void Update () {
        isTriggeredLastTime = isTriggered;
        if (puzzles.Count == 0) {
            return;
        }
        if (isPermanentChange && isTriggered) {
            return;
        }
        switch (triggerType) {
            case TriggerType.AND: {
                isTriggered = DetermineAnd();
                break;
            }
            case TriggerType.OR: {
                isTriggered = DetermineOr();
                break;
            }
        }
        // Debug.Log(gameObject + " isTriggered: " + isTriggered);
    }

    bool DetermineAnd() {
        bool triggerTest = true;
        for (int i = 0; i != puzzles.Count; ++i) {
            switch (puzzleTypes[i]) {
                case PuzzleType.SWITCH_ON: {
                    triggerTest = puzzles[i].isTriggered;
                    break;
                }
                case PuzzleType.SWITCH_OFF: {
                    triggerTest = !(puzzles[i].isTriggered);
                    break;
                }
                case PuzzleType.RANGE_IN: {
                    if (Math.Abs(transform.position.x - puzzles[i].transform.position.x) <= range.x && 
                        Math.Abs(transform.position.y - puzzles[i].transform.position.y) <= range.y) {
                        triggerTest = true;
                    } else {
                        triggerTest = false;
                    }
                    break;
                }
                case PuzzleType.RANGE_OUT: {
                    if (Math.Abs(transform.position.x - puzzles[i].transform.position.x) > range.x || 
                        Math.Abs(transform.position.y - puzzles[i].transform.position.y) > range.y) {
                        triggerTest = true;
                    } else {
                        triggerTest = false;
                    }
                    break;
                }

            }
            if (triggerTest != true) {
                break;
            }
        }
        return triggerTest;
    }

    bool DetermineOr() {
        bool triggerTest = false;
        for (int i = 0; i != puzzles.Count; ++i) {
            switch (puzzleTypes[i]) {
                case PuzzleType.SWITCH_ON: {
                    triggerTest = puzzles[i].isTriggered;
                    break;
                }
                case PuzzleType.SWITCH_OFF: {
                    triggerTest = !(puzzles[i].isTriggered);
                    break;
                }
                case PuzzleType.RANGE_IN: {
                    if (Math.Abs(transform.position.x - puzzles[i].transform.position.x) <= range.x && 
                        Math.Abs(transform.position.y - puzzles[i].transform.position.y) <= range.y) {
                        triggerTest = true;
                    } else {
                        triggerTest = false;
                    }
                    break;
                }
                case PuzzleType.RANGE_OUT: {
                    if (Math.Abs(transform.position.x - puzzles[i].transform.position.x) > range.x || 
                        Math.Abs(transform.position.y - puzzles[i].transform.position.y) > range.y) {
                        triggerTest = true;
                    } else {
                        triggerTest = false;
                    }
                    break;
                }
            }
            if (triggerTest != false) {
                break;
            }
        }
        return triggerTest;
    }

    public bool GetTriggerDown() {
        return (!isTriggeredLastTime && isTriggered);
    }

    public bool GetTriggerUp() {
        return (isTriggeredLastTime && !isTriggered);
    }

    public bool GetTrigger() {
        return isTriggered;
    }

    public void AddPuzzle(Puzzle p, PuzzleType t) {
        puzzles.Add(p);
        puzzleTypes.Add(t);
    }
}
