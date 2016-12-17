using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
public class LevelState : Puzzle {
    public string Current_LevelName;
    public string Next_LevelName;
    public List<Vector2> savepoints = new List<Vector2>();
    static public int current_savepoints = 0;

    public Transform player;

    private bool flag = false;
    // Use this for initialization
	void Start () { 
        Assert.IsNotNull(player);
        Debug.Log(current_savepoints);
        Debug.Log(savepoints.Count);
        if(savepoints.Count>0)
            player.position =new Vector3( savepoints[current_savepoints].x, savepoints[current_savepoints].y, player.position.z);
    }
	// Update is called once per frame
	public override void Update () {
        //judge
        base.Update();
        if (GetTriggerDown())
        {
            //int c = cheapter + 'A' - 1;
            if (puzzles[0].isTriggered)
            {
                Debug.Log("+++++++++++++++++++++");
                current_savepoints = 0;
                Debug.Log(current_savepoints);
                flag = true;
                GameKernel.levelManager.ChangeLevel(GameKernel.levelManager.CreateCommonLevel(Next_LevelName), true);
            }
            else if (puzzles[1].isTriggered)
            {
    
                GameKernel.levelManager.ChangeLevel(GameKernel.levelManager.CreateCommonLevel(Current_LevelName), true);
            }
        }

        //refresh the current_savepoint
        else if (current_savepoints + 1 <= savepoints.Count - 1&&!flag)
        {
            if (player.position.x > savepoints[current_savepoints + 1].x)
            {
                current_savepoints++;
                Debug.Log(Current_LevelName);
                Debug.Log(current_savepoints+"aaa"+savepoints.Count);
                //Debug.Log(current_savepoints);
            }
        }
    }
    
}
