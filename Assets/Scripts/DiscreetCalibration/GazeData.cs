using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GazeData
{

    //public float head;
    public float roll;
    public float pitch;

    public static GazeData FromJSON(string jsonString)
    {
        return JsonUtility.FromJson<GazeData>(jsonString);
    }

    public override string ToString()
    {
        //return "head = " + head;
        return "roll = " + roll;
    }


}
