using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static Vector3 Direction(Vector3 a, Vector3 b) => (b - a).normalized;
    public static float Distance(Vector3 a, Vector3 b) => Vector3.Distance(a, b);
}
