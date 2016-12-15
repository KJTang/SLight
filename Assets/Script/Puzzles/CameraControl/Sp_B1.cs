using UnityEngine;
using System.Collections;

public class Sp_B1 : SpeContPuzzle {
    public Puzzle sp1;
    public float sd1;
    // Use this for initialization	
	// Update is called once per frame
	public override void Update () {
        if (sp1.GetTriggerDown() && flag)
        {
            //Debug.Log("33");
            flag = false;
            GameKernel.inputManager.Enable = false;
            GameKernel.actionManager.RunAction(new ActionSequence(gameObject,
                new ActionMoveBy(gameObject,
                    new Vector3(0, -sd1, 0),
                    1.0f),
                new ActionDelay(gameObject, 1.0f),
                new ActionMoveBy(gameObject,
                    new Vector3(0, sd1, 0),
                    1.0f),
                new ActionCallFunc(gameObject, (object obj) =>
                {
                    GameObject go = (GameObject)obj;
                    flag = true;
                    Debug.Log(go.transform.position.y);
                    //Debug.Log("aa");
                    GameKernel.inputManager.Enable = true;
                }, gameObject)
            ));
        }
        base.Update();

    }
}
