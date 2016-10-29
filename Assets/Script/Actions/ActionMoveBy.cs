using UnityEngine;
using System.Collections;

public class ActionMoveBy : Action {
    private Vector3 offset;
    private float distance;
    private float speed;
    private float pass;

    public ActionMoveBy(GameObject go, Vector3 of, float time) {
        gameObject = go;
        offset = of;
        distance = offset.magnitude;
        speed = distance / time;
        pass = 0.0f;
    }

    public override void Init() {}

    public override void Update() {
        if (pass == distance) {
            isFinished = true;
        } else {
            float step = speed * Time.deltaTime;
            if (step + pass > distance) {
                step = distance - pass;
            }
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, gameObject.transform.position + offset, step);
            pass += step;
        }
    }

    public override void Destroy() {}
}
