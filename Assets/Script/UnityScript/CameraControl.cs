using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public GameObject target;

	void Start () {}
	
	void Update () {
        if (target) {
            GameKernel.actionManager.RunAction(new ActionMoveTo(
                gameObject, 
                new Vector3(target.transform.position.x, target.transform.position.y, -10.0f), 
                1.0f));
        }
    }
}
