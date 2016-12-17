using UnityEngine;
using System.Collections;

public class Sp_D1 : MonoBehaviour {
    public Puzzle sp1,sp2,sp3,sp4;
    public Transform FinalPoint;
    public Vector3 distance;

    protected bool flag;

    private bool b1, b2, b3, b4;
	// Use this for initialization
	void Start () {
        flag = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (sp1.GetTriggerDown())
        {
            b1 = true;
            Debug.Log("1");
        }
        if (sp2.GetTriggerDown())
        {
            b2 = true;
            Debug.Log("2");
        }
        if (sp3.GetTriggerDown())
        {
            b3 = true;
            Debug.Log("3");
        }
        if (sp4.GetTriggerDown())
        {
            b4 = true;
            Debug.Log("4");
        }

        if (b1&&b2&&b3&&b4&&flag)
        {
            flag = false;
            GameKernel.inputManager.Enable = false;
            GameKernel.actionManager.RunAction(new ActionSequence(gameObject,
                new ActionDelay(gameObject, 1.0f),
                new ActionMoveBy(FinalPoint.gameObject,
                    distance,
                    1.0f),
                new ActionCallFunc(gameObject, (object obj) =>
                {
                    GameObject go = (GameObject)obj;
                    //flag = true;
                    GameKernel.inputManager.Enable = true;
                }, gameObject)
            ));
        }
    }
}
