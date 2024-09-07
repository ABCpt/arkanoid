using System;
using Core.Bricks.Data;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public class LevelData
{
    public TextAsset Json;

    public LevelGrid GetLevelGrid()
    {
        return JsonConvert.DeserializeObject<LevelGrid>(Json.text);
    }
}

[Serializable]
public class LevelGrid
{
    public int Width;
    public int Height;
    public BrickType[][] BricksArray;
}
