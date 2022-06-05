using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T:MonoBehaviour
{
    static T instance; //静态基于类的级别进行访问
    public static T Instance{
        get {
            if(MonoSingletonObject.go==null)
            {
                MonoSingletonObject.go=new GameObject("MonoSingletonObjecr");
            }
            if(MonoSingletonObject.go!=null)
            {
                instance=MonoSingletonObject.go.AddComponent<T>();
            }
            return instance;
        }
    }
    //所有继承MonoBehaviourd的脚本需挂载游戏游戏物体上面，才能在游戏运行生效
}

//缓存一个游戏物体
public class MonoSingletonObject
{
    public static GameObject go;
}