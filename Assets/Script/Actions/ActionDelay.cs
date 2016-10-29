using UnityEngine;
using System.Collections;

public class ActionDelay : Action {
    private float time;
    private float pass;

    public ActionDelay(GameObject go, float t) {
        gameObject = go;
        time = t >= 0.0f ? t : 0.0f;
        pass = 0.0f;
    }

    public override void Init() {}

    public override void Update() {
        if (pass >= time) {
            isFinished = true;
        } else {
            pass += Time.deltaTime;
        }
    }

    public override void Destroy() {}
}
