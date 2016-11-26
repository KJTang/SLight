using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;
using System.Collections.Generic;

public class MirrorPuzzle : LightDetectorPuzzle {
    private bool isLightShootingOn = false;
    private Dictionary<GameObject, GameObject> reflectLights;

    void Start() {
        reflectLights = new Dictionary<GameObject, GameObject>();
    }
    
    public override void Update() {
        base.Update();
        if (GetTrigger()) {
            // create reflect
            isLightShootingOn = true;
        }
        if (GetTriggerUp()) {
            // clear
            isLightShootingOn = false;
        }
    }

    void LateUpdate() {
        if (isLightShootingOn) {
            CreateReflectLight();
        }
    }

    void CreateReflectLight() {
        foreach (KeyValuePair<GameObject, LightInfo> kvp in lights) {
            if (reflectLights.ContainsKey(kvp.Key) == false) {
                GameObject reflect = new GameObject();
                reflect.transform.parent = transform;
                ReflectLightPuzzle script = reflect.AddComponent<ReflectLightPuzzle>();
                Assert.IsNotNull(script);
                script.raycastLayer = kvp.Value.raycastLayer;
                reflectLights.Add(kvp.Key, reflect);
            } else {
                GameObject reflect = reflectLights[kvp.Key];
                Assert.IsNotNull(reflect);
                LightInfo lightInfo = kvp.Value;
                Vector3 point = new Vector3(lightInfo.hitPoint.x, lightInfo.hitPoint.y, transform.position.z);
                Vector3 offset = transform.TransformDirection(Vector3.up) * 0.1f;
                point -= offset;
                reflect.transform.position = point;
                float normalizeMirrorAngle = transform.eulerAngles.z > 0.0f ? transform.eulerAngles.z : transform.eulerAngles.z + 360.0f;
                float normalizeLightAngle = lightInfo.eulerAngles.z > 0.0f ? lightInfo.eulerAngles.z : lightInfo.eulerAngles.z + 360.0f;
                float angleOffset = normalizeMirrorAngle - normalizeLightAngle;
                float angles = 0.0f;
                angles = -180.0f + angleOffset;
                angles = angles > 0.0f ? angles : angles + 360.0f;
                reflect.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angles);
            }
        }
    }

    public override void RemoveLightPoint(GameObject light) {
        GameObject reflect = reflectLights[light];
        // remove recursively reflected lights
        reflect.GetComponent<ReflectLightPuzzle>().RemoveLightPointInDetector();
        Destroy(reflect);
        reflect = null;
        reflectLights.Remove(light);
        base.RemoveLightPoint(light);
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Vector3 direction = transform.TransformDirection(Vector3.up) * 12;
        Gizmos.DrawRay(transform.position, direction);
    }
}
