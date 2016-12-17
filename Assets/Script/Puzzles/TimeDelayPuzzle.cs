using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class TimeDelayPuzzle : Puzzle {
    public Puzzle timeStart;
    public float delayTime = 0.0f;

    private bool isStart = false;
    private float timer = 0.0f;

    void Start () {
        isTriggered = false;
        Assert.IsNotNull(timeStart);
    }

    public override void Update () {
        // base.Update();
        if (isTriggered) {
            return;
        }
        if (!isStart && timeStart.isTriggered) {
            isStart = true;
            timer = 0.0f;
        }
        if (isStart) {
            timer += Time.deltaTime;
        }
        if (timer >= delayTime) {
            isTriggered = true;
        }
    }
}
