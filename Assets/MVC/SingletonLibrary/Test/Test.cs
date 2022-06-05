using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestSingleton.Instance.MYFUNC();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class TestSingleton:Singleton<TestSingleton>
{
    public void MYFUNC()
    {
        Debug.Log("Singleton.....");
    }
}