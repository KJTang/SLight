using UnityEngine;
using System.Collections;

public class LevelCho : MonoBehaviour {
    public string [] levelName;
    public Texture2D CexitButton;
    //public int num;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ChangeLevel0()
    {
        GameKernel.levelManager.ChangeLevel(
           GameKernel.levelManager.CreateCommonLevel("StartScene"),
           true
        );
    }
    public void ChangeLevelA0()
    {
        GameKernel.levelManager.ChangeLevel(
           // GameKernel.levelManager.CreateCommonLevel(levelName[0]),
           GameKernel.levelManager.CreateCommonLevel("CG1"),
           true
        );
    }
  
    public void ChangeLevelA1()
    {
        GameKernel.levelManager.ChangeLevel(
           GameKernel.levelManager.CreateCommonLevel(levelName[1]),
           true
        );
    }

    public void ChangeLevelA2()
    {
        GameKernel.levelManager.ChangeLevel(
           GameKernel.levelManager.CreateCommonLevel(levelName[2]),
           true
        );
    }

    public void ChangeLevelB0()
    {
        GameKernel.levelManager.ChangeLevel(
           // GameKernel.levelManager.CreateCommonLevel(levelName[3]),
           GameKernel.levelManager.CreateCommonLevel("CG2-1"),
           true
        );
    }
    public void ChangeLevelB1()
    {
        GameKernel.levelManager.ChangeLevel(
           GameKernel.levelManager.CreateCommonLevel(levelName[4]),
           true
        );
    }
    public void ChangeLevelB2()
    {
        GameKernel.levelManager.ChangeLevel(
           GameKernel.levelManager.CreateCommonLevel(levelName[5]),
           true
        );
    }

    public void ChangeLevelC0()
    {
        GameKernel.levelManager.ChangeLevel(
           GameKernel.levelManager.CreateCommonLevel(levelName[6]),
           true
        );
    }
    public void ChangeLevelC1()
    {
        GameKernel.levelManager.ChangeLevel(
           GameKernel.levelManager.CreateCommonLevel(levelName[7]),
           true
        );
    }
    public void ChangeLevelC2()
    {
        GameKernel.levelManager.ChangeLevel(
           GameKernel.levelManager.CreateCommonLevel(levelName[8]),
           true
        );
    }

    public void ChangeLevelD0()
    {
        GameKernel.levelManager.ChangeLevel(
           // GameKernel.levelManager.CreateCommonLevel(levelName[9]),
           GameKernel.levelManager.CreateCommonLevel("CG4"),
           true
        );
    }
    public void ChangeLevelD1()
    {
        GameKernel.levelManager.ChangeLevel(
           GameKernel.levelManager.CreateCommonLevel(levelName[10]),
           true
        );
    }
    public void ChangeLevelD2()
    {
        GameKernel.levelManager.ChangeLevel(
           GameKernel.levelManager.CreateCommonLevel(levelName[11]),
           true
        );
    }
}
