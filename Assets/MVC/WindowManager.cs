using System.Collections;
using System.Collections.Generic;
using Game.View;
using UnityEngine;

public class WindowManager : MonoSingleton<WindowManager>
{
    Dictionary<WindowType,BaseWindow> windowDic=new Dictionary<WindowType, BaseWindow>();
    //构造函数 初始化
    public WindowManager()
    {
        //商店
        windowDic.Add(WindowType.StoreWindow,new StoreWindow());
    }
    public void Update()
    {
        foreach(var window in windowDic.Values) {
            if(window.IsVisable())
            {
                window.Update(Time.deltaTime);
            }
        }
    }
    //打开窗口
    public BaseWindow OpenWindow(WindowType type)
    {
        BaseWindow window;
        if(windowDic.TryGetValue(type,out window))
        {
            window.Open();
           return window;
        }
        Debug.Log($"Open Error:{type}");
        return null;
    }
    //关闭窗口
    public void CloseWindow(WindowType type)
    {
        BaseWindow window;
        if(windowDic.TryGetValue(type,out window))
        {
            window.Close();
        }
        else
        {
            Debug.Log($"Close Error:{type}");
        }
    }
    //预加载
    public void PreLoadWindow(SceneType type)
    {
       foreach(var item in windowDic.Values)
       {
           if(item.GetScenesType()==type)
           {
               item.PreLoad();
           }
       }
    }
    //隐藏掉某个类型的所有窗口
    public void HideAllWindow(SceneType type,bool isDestory=false)
    {
        foreach(var item in windowDic.Values) {
            item.Close(isDestory);
        }
    }
}
