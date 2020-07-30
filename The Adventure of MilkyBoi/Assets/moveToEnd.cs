using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToEnd 
{
    // Update is called once per frame
    public Vector2 Lerp(Vector2 startPos,Vector2 endPos,float startTime, float Lerptime  = 5f ){

        float timeSinceStarted = Time.time - startTime;
        float percentageComplete = timeSinceStarted / Lerptime;
        return Vector3.Lerp(startPos,endPos,percentageComplete);
    }
}
