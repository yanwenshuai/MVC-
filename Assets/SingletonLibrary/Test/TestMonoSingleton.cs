using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonoSingleton : MonoSingleton<TestMonoSingleton>
{
    public TestMonoSingleton()
    {
        destroyOnLoad=true;
    }
    public void Test()
    {
        Debug.Log($"MonoSingleton.....");
    } 
    private void Start()
    {
        AddSceneChangedEvent();
    }
}
