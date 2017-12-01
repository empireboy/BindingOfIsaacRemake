using UnityEngine;

public class MathFunctions
{
    /* Sample: 
     * float speed = 0;
     * float maxSpeed = 5;
     * float time = 0;
     * 
     * void Update() {
     *  MatchFunctions.smoothInterpolation(speed, maxSpeed, time, 0, 100, 10);
     *  time++
     * }
     */
    public static float smoothInterpolation(float min, float max, int time, float startPersentage, float maxPersentage, float increasingPersentage)
    {
        float t = Mathf.Clamp((startPersentage / 100) + (increasingPersentage / 100) * time * Time.deltaTime, startPersentage, maxPersentage);
        return Mathf.Lerp(min, max, t);
    }
}