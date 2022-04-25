using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class MicrobesView : MonoBehaviour
{
    // this is mission 2
    //what we see here is my version of code that the junior developer wrote.
    [SerializeField] bool useDebug = true;

    [Space]

    private Dictionary<string, Microbe> _microbes = new Dictionary<string, Microbe>();
    [SerializeField] private Text totalAndAvgMicrobes;

    private float totalHealth = 0f;

    void LateUpdate()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        foreach (var kvp in _microbes)
        {
            totalHealth += kvp.Value != null ? kvp.Value.health : 0f;
        }
        sw.Stop();
        string text = $"Total microbes: {_microbes.Count} Avg health {_microbes.Count / totalHealth}";
        totalAndAvgMicrobes.text = text;

        if (useDebug)
        {
            Debug.Log(text);
            Debug.Log(sw.ElapsedMilliseconds); // how much time in ms the execution took
        }
    }
}

public class Microbe
{
    public float health;
}

