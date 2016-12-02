using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;
using System.Collections.Generic;

public class ShadowLightDetectorPuzzle : LightDetectorPuzzle {
    public Vector3 shadowOffset = new Vector3(0.0f, 0.0f, 0.0f);

    private GameObject shadowPrefab;
    private GameObject shadowObject;

    void Start() {
        isTriggered = true;
        shadowPrefab = GameKernel.resourceManager.LoadPrefab("PlayerShadow", "Prefabs/PlayerShadow");
        Assert.IsNotNull(shadowPrefab);
    }
    
    public override void Update() {
        // base.Update();
        if (lights.Count == 1) {
            if (shadowObject == null) {
                CreateShadow();
            } else {
                UpdateShadow();
            }
        } else {
            if (shadowObject) {
                RemoveShadow();
            }
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Vector3 direction = transform.TransformDirection(Vector3.up) * 12;
        Gizmos.DrawRay(transform.position, direction);
    }

    void CreateShadow() {
        // Debug.Log("CreateShadow");
        Assert.IsTrue(lights.Count == 1);
        shadowObject = Object.Instantiate(shadowPrefab) as GameObject;
    }

    void UpdateShadow() {
        // Debug.Log("UpdateShadow");
        LightInfo info;
        foreach (KeyValuePair<GameObject, LightInfo> kvp in lights) {
            info = kvp.Value;
            shadowObject.transform.position = new Vector3(info.hitPoint.x, info.hitPoint.y, transform.position.z) + shadowOffset;
            break;
        }
    }

    void RemoveShadow() {
        // Debug.Log("RemoveShadow");
        Destroy(shadowObject);
        shadowObject = null;
    }
}
