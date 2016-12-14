using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;
using System.Collections.Generic;

public class RangeLightPuzzle : LightDetectorPuzzle {
    public GameObject rangeLight;

    private bool acting = false;

    void Start() {
        isTriggered = false;
        Assert.IsNotNull(rangeLight);
        rangeLight.SetActive(false);
    }
    
    public override void Update() {
        base.Update();
        if (GetTrigger() && !acting) {
            OnTriggerDown();
            acting = true;
        }
        if (!GetTrigger() && acting) {
            OnTriggerUp();
            acting = false;
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Vector3 direction = transform.TransformDirection(Vector3.up) * 12;
        Gizmos.DrawRay(transform.position, direction);
    }

    void OnTriggerDown() {
        rangeLight.SetActive(true);
    }

    void OnTriggerUp() {
        rangeLight.SetActive(false);
    }
}
