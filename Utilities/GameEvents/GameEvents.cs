using System;
using UnityEngine;

public static class GameEvents
{
    /// <summary>
    /// Example Events
    /// Just Invoke and Subscribe them on your MonoBehaviour 
    /// </summary>
    public static readonly Evt SampleEvent = new Evt();   
    public static readonly Evt<int> SampleEventInt = new Evt<int>();   

}
