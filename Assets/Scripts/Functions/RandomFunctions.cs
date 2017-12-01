using UnityEngine;

[System.Serializable]
public class RandomFunctions {

    public static float RandomRange(float x1, float x2)
    {
        return Random.Range(x1, x2);
    }
}
