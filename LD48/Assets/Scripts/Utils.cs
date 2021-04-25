using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public class Pair<T, U> {
        public Pair() {
        }

        public Pair(T first, U second) {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };
    public static Vector2 Direction(Vector3 a, Vector3 b) => (b - a).normalized;
    public static float Distance(Vector3 a, Vector3 b) => Vector3.Distance(a, b);
    public static void SpawnEvenlyInCircle(Vector2 center, float radius, int n, Actor actor, System.Action<float, float, Actor> callback) {
        int[] T = { 1, 10, 20, 30, 40, 50, 60 };
        float[] R = {0.0f, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f};

        var result = new List<Pair<float, float>>();

        for (int i = 0; i < R.Length; i++) {
            for (int j = 0; j < T[i]; j++) {
                result.Add(new Pair<float, float>(R[i], j * (2 * Mathf.PI / T[i])));
            }
        }

        var time = 0;
        foreach (var p in result) {
            if (time++ == n) return;
            var r = p.First;
            var t = p.Second;
            var x = center.x + r * Mathf.Cos(t) * radius;
            var y = center.y + r * Mathf.Sin(t) * radius;
            callback(x, y, actor);
        }
    }
}
