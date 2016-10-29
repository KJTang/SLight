using UnityEngine;
using System.Collections;

public class ActionMoveTo : Action {
    private Vector3 destination;
    private float speed;

    public ActionMoveTo(GameObject go, Vector3 dist, float time) {
        gameObject = go;
        speed = Vector3.Distance(go.transform.position, dist) / time;
        destination = dist;
    }

    public override void Init() {}

    public override void Update() {
        if (gameObject.transform.position == destination) {
            isFinished = true;
        } else {
            float step = speed * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, destination, step);
        }
    }

    public override void Destroy() {}
}
