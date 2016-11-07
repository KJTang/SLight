using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class UntouchablePuzzle : MonoBehaviour {
    public Transform player;
	// Use this for initialization
	void Start () {
        Assert.IsNotNull(player);
	}
	
	// Update is called once per frame
	void Update () {
        // 
	}
    void OnTriggerEnter(Collider other)
    {
        //if(other = )//另一物体是player
        //{
        //    //加载死亡flash
            
        //    //重新加载关卡

        //}
    }
}
