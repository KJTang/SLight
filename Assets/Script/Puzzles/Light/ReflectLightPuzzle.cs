using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class ReflectLightPuzzle : LightPuzzle {
    void Start() {
        isTriggered = false;
    }
    
    public override void Update() {
        // base.Update();
        ShotLight();
    }

    // void FixedUpdate() {
    //     Vector2 direction = new Vector2(transform.TransformDirection(Vector3.up).x, transform.TransformDirection(Vector3.up).y);
    //     hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, raycastLayer.value);
    //     if (hit.rigidbody != null) {
    //         hitBody = hit.rigidbody;
    //         hitPoint = hit.point;
    //     } else {
    //         hitBody = null;
    //         hitPoint = new Vector2(0.0f, 0.0f);
    //     }
    // }

    // void OnDrawGizmos() {
    //     float distance = 12.0f;
    //     if (hitBody != null) {
    //         distance = Vector3.Distance(transform.position, hitPoint);
    //     }
    //     Gizmos.color = Color.red;
    //     Vector3 direction = transform.TransformDirection(Vector3.up) * distance;
    //     Gizmos.DrawRay(transform.position, direction);
    // }

    // void ShotLight() {
    //     if (hitBody != null && hitBody.gameObject.layer == LayerMask.NameToLayer("Mirror")) {
    //         hitScript = (hitBody.transform.parent.gameObject).GetComponent<MirrorPuzzle>();
    //         Assert.IsNotNull(hitScript);
    //         LightInfo info = new LightInfo();
    //         info.name = gameObject.ToString();
    //         info.eulerAngles = transform.eulerAngles;
    //         info.raycastLayer = raycastLayer;
    //         info.hitPoint = hitPoint;
    //         hitScript.AddLightPoint(gameObject, info);
    //         isHit = true;
    //     } else {
    //         RemoveLightPointInMirror();
    //     }
    // }

    // void ChangeDirection() {
    //     if (GameKernel.inputManager.GetKey(InputKey.Left)) {
    //         Vector3 angle = transform.localEulerAngles;
    //         currentEulerAngles = new Vector3(angle.x, angle.y, angle.z > 360.0f ? angle.z - 359.0f : angle.z + 1.0f);
    //     } else if (GameKernel.inputManager.GetKey(InputKey.Right)) {
    //         Vector3 angle = transform.localEulerAngles;
    //         currentEulerAngles = new Vector3(angle.x, angle.y, angle.z < 0.0f ? angle.z + 359.0f : angle.z - 1.0f);
    //     }
    //     transform.localEulerAngles = currentEulerAngles;
    // }

    // public void RemoveLightPointInMirror() {
    //     // remove light point in MirrorPuzzle
    //     if (hitScript && isHit) {
    //         hitScript.RemoveLightPoint(gameObject);
    //         isHit = false;
    //     }
    // }
}
