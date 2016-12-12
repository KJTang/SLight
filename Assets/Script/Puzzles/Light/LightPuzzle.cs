using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class LightPuzzle : Puzzle {
    public LayerMask raycastLayer;

    protected bool isHit = false;
    protected Vector2 hitPoint;
    protected RaycastHit2D hit;
    protected Rigidbody2D hitBody;
    protected LightDetectorPuzzle hitScript;

    protected bool isLightSegCreated = false;
    protected GameObject lightSegPrefab;
    protected GameObject lightSegObject;

    void Start() {
        isTriggered = false;
        Debug.Log("+++++++++++++=");
        // CreateLightSeg();
    }
    
    public override void Update() {
        base.Update();
        ShotLight();
        DrawLight();
    }

    void FixedUpdate() {
        Vector2 direction = new Vector2(transform.TransformDirection(Vector3.up).x, transform.TransformDirection(Vector3.up).y);
        hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, raycastLayer.value);
        if (hit.rigidbody != null) {
            hitBody = hit.rigidbody;
            hitPoint = hit.point;
        } else {
            hitBody = null;
            hitPoint = new Vector2(0.0f, 0.0f);
        }
    }

    void OnDrawGizmos() {
        float distance = 12.0f;
        if (hitBody != null) {
            distance = Vector3.Distance(transform.position, hitPoint);
        }
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.up) * distance;
        Gizmos.DrawRay(transform.position, direction);
    }

    protected void DrawLight() {
        if (!isLightSegCreated) {
            CreateLightSeg();
        }
        float distance = 12.0f;
        if (hitBody != null) {
            distance = Vector3.Distance(transform.position, hitPoint);
        }
        // lightSegObject.transform.localScale = new 
    }

    protected void CreateLightSeg() {
        lightSegPrefab = GameKernel.resourceManager.LoadPrefab("LightSeg", "Prefabs/LightSeg");
        Assert.IsNotNull(lightSegPrefab);
        lightSegObject = Object.Instantiate(lightSegPrefab) as GameObject;
        Assert.IsNotNull(lightSegObject);
        lightSegObject.transform.parent = transform;
        lightSegObject.transform.localPosition = new Vector3(0, 0, 0);
        lightSegObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        lightSegObject.transform.localScale = new Vector3(0.1f, 0.1f, 1.0f);
        Debug.Log("+++++++++++++++++++" + lightSegObject.transform.position);

        isLightSegCreated = true;
    }

    protected void RemoveLightSeg() {
        Destroy(lightSegObject);
        lightSegObject = null;
        Debug.Log("---------------------------");

        isLightSegCreated = false;
    }

    protected void ShotLight() {
        if (hitBody != null && hitBody.gameObject.layer == LayerMask.NameToLayer("LightDetector")) {
            LightDetectorPuzzle newHitScript = (hitBody.transform.parent.gameObject).GetComponent<LightDetectorPuzzle>();
            Assert.IsNotNull(newHitScript);
            // remove last
            if (hitScript != newHitScript) {
                RemoveLightPointInDetector();
            }
            // create or update new
            hitScript = newHitScript;
            LightInfo info = new LightInfo();
            info.name = gameObject.ToString();
            info.eulerAngles = transform.eulerAngles;
            info.raycastLayer = raycastLayer;
            info.hitPoint = hitPoint;
            hitScript.AddLightPoint(gameObject, info);
            isHit = true;
        } else {
            RemoveLightPointInDetector();
        }
    }

    public void RemoveLightPointInDetector() {
        // remove light point in Detector
        if (hitScript && isHit) {
            hitScript.RemoveLightPoint(gameObject);
            RemoveLightSeg();
            isHit = false;
        }
    }
}
