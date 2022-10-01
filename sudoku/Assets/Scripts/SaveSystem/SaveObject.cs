using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveObject
{
    public int score = 0;
    public int timeMin = 0;
    public int timeSec = 0;

    public int[][] board;
}
