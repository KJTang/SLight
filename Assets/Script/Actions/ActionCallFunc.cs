using UnityEngine;
using System.Collections;

// usage example: 
// CallFuncDelegate func = (object obj) => {
//     Debug.Log("message: " + (string)obj);
// };
// GameKernel.actionManager.RunAction(new ActionCallFunc(gameObject, func, "this is a msg."));

public delegate void CallFuncDelegate(object obj);

public class ActionCallFunc : Action {
    private CallFuncDelegate delFunc;
    private object data;

    public ActionCallFunc(GameObject go, CallFuncDelegate func, object d = null) {
        gameObject = go;
        delFunc = func;
        data = d;
    }

    public override void Init() {}

    public override void Update() {
        delFunc(data);
        isFinished = true;
    }

    public override void Destroy() {}
}