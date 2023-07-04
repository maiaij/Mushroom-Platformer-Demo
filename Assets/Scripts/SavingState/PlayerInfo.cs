using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class PlayerInfo 
{
    public Vector3 position;
    public int shroomCount;
    public GameObject theShrooms;
    public GameObject checkpoint;
    
    public PlayerInfo()
    {
        this.position = new Vector3();
        this.shroomCount = 0;
        this.theShrooms = null;
    }
    public PlayerInfo(Vector3 trans, int shrooms, GameObject remaining, GameObject check)
    {
        this.position = trans;
        this.shroomCount = shrooms;
        this.theShrooms = remaining;
    }
}
