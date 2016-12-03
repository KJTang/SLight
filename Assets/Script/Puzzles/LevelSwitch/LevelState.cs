using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
public class LevelState : Puzzle {
    public int cheapter;
    public int level;
    public int levels_in_cheapter = 5;  
    public int num_of_cheapter = 5;

    public List<Vector2> savepoints = new List<Vector2>();
    static private int current_savepoints = 0;

    public Transform player;
	
    // Use this for initialization
	void Start () { 
        Assert.IsNotNull(player);
        if(savepoints.Count>0)
            player.position =new Vector3( savepoints[current_savepoints].x, savepoints[current_savepoints].y, player.position.z);
    }
	// Update is called once per frame
	public override void Update () {
        //judge
        base.Update();
        if (GetTriggerDown())
        {
            int c = cheapter + 'A' - 1;
            if (puzzles[0].isTriggered)
            {
                if (level < levels_in_cheapter)
                {
                    GameKernel.levelManager.ChangeLevel(GameKernel.levelManager.CreateCommonLevel("Level" + (char)c + (++level).ToString()), true);
                }
                else if (cheapter <= num_of_cheapter)
                {
                    GameKernel.levelManager.ChangeLevel(GameKernel.levelManager.CreateCommonLevel("Level" + (char)(c+1) + 1.ToString()), true);
                }
                else
                {
                    //gameover
                }
            }
            else if (puzzles[1].isTriggered)
            {
                GameKernel.levelManager.ChangeLevel(GameKernel.levelManager.CreateCommonLevel("Level" + (char)c + level.ToString()), true);
            }
        }

        //refresh the current_savepoint
        if (current_savepoints+1 <= savepoints.Count - 1)
        {
            if (player.position.x > savepoints[current_savepoints+1].x)
            {
                current_savepoints++;
                //Debug.Log(current_savepoints);
            }
        }
    }
    
}
