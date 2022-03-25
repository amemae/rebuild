using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathFunctions
{
    /// <summary>
    /// Returns a vector with the same magnitude as initialVector rotated counterclockwise by angleInDegrees
    /// </summary>
    /// <param name="initialVector"></param>
    /// <param name="angleInDegrees"></param>
    /// <returns></returns>
    public static Vector2 RotateVector(Vector2 initialVector, float angleInDegrees)
    {
        angleInDegrees *= Mathf.Deg2Rad;
        float magnitude = Mathf.Sqrt(Vector2.SqrMagnitude(initialVector));
        //Create a unit vector
        Vector2 newVect = initialVector / magnitude;
        float vectorAngle = (Mathf.Atan2(newVect.y, newVect.x)) + angleInDegrees;
        //New unit vector at the wanted angle
        newVect = new Vector2(Mathf.Cos(vectorAngle), Mathf.Sin(vectorAngle));
        //At the same magnitude
        newVect *= magnitude;

        return newVect;
    }
}
