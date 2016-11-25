using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class LevelState : Puzzle {
    public int cheapter;
    public int level;
    public int levels_in_cheapter = 5;
    public int num_of_cheapter = 5;

    public Transform player;
	
    // Use this for initialization
	void Start () {
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
    }
    
}
