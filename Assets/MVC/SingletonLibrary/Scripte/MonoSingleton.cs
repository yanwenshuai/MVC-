using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MonoSingleton<T> : MonoBehaviour where T:MonoBehaviour
{
    static T instance; //静态基于类的级别进行访问
    public static T Instance{
        get {
            if(MonoSingletonObject.go==null)
            {
                MonoSingletonObject.go=new GameObject("MonoSingletonObjecr");
                DontDestroyOnLoad(MonoSingletonObject.go);
            }
            if(MonoSingletonObject.go!=null&&instance==null)
            {
                instance=MonoSingletonObject.go.AddComponent<T>();
            }
            return instance;
        }
    }
    //所有继承MonoBehaviourd的脚本需挂载游戏游戏物体上面，才能在游戏运行生效


    //有的时候有的组件场景切换时回收
    public static bool destroyOnLoad=false;
    //添加场景切换时候的事件
    public void AddSceneChangedEvent()
    {
        SceneManager.activeSceneChanged+=OnSceneChanged;
    }

    private void OnSceneChanged(Scene arg0,Scene arg1)
    {
       if(destroyOnLoad==true)
       {
           if(instance!=null)
           {
               DestroyImmediate(instance);//立即销毁
               Debug.Log(instance==null);
           }
       }
    }
}



//缓存一个游戏物体
public class MonoSingletonObject
{
    public static GameObject go;
}