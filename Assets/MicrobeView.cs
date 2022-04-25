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

    [SerializeField] private Text totalAndAvgMicrobes; // save this instead of "getcomponent

    private Dictionary<string, Microbe> _microbes = new Dictionary<string, Microbe>(); // for better perforence, list will take much longer

    private float totalHealth = 0f;
    private float avgHealth = 0f;

    void LateUpdate()
    {
        totalHealth = 0f;
        avgHealth = 0f;

        Stopwatch sw = new Stopwatch();
        sw.Start();

        foreach (var kvp in _microbes)
        {
            totalHealth += kvp.Value != null ? kvp.Value.health : 0f;
        }
        sw.Stop();
        avgHealth = totalHealth / _microbes.Count; // the avg health is stored in a var, the initial code didnt calculate it right



        string text = $"Total microbes: {_microbes.Count} Avg health {avgHealth}";
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

