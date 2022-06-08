using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseWindow 
{
    protected  Transform transfrom;//UI窗体
    protected string resName;//资源名称
    protected bool resident;//是否常驻
    protected bool visible;//是否可见
    protected WindowType selfType;//窗体类型
    protected SceneType sceneType;//场景类型

    //UI控件 按钮
    protected Button[] buttonList;//按钮列表

    //需要给子类提供的接口：
    //初始化
    protected virtual void Awake()
    {
        //ture表示隐藏的物体也会查找
        buttonList=transfrom.GetComponentsInChildren<Button>(true);
    }
    //UI事件的注册
    protected virtual void RegisterUIEvent()
    {

    }
    //添加监听游戏事件
    protected  virtual void OnAddListener()
    {

    }
    //移除游戏事件
    protected virtual void OnRemoveListener()
    {

    }
    //每次打开
    protected virtual void OnEnable()
    {

    }
    //每次关闭
    protected virtual void OnDisable()
    {

    }
    //每帧更新
    protected virtual void Update()
    {
        
    }

    //--------------------------WindowManager服务
    public void Open()
    {
       if(transfrom==null)
       {
           if(Create())
           {
               Awake();
           }
       }
    }
    public void Close()
    {

    }
    public void PreLoad()
    {

    }

    //----内部----根据资源名称创建UI物体
    private bool Create()
    {
       if(string.IsNullOrEmpty(resName))
       {
           return false;
       }
       if(transfrom==null)
       {
           var obj=Resources.Load<GameObject>(resName);
           if(obj==null)
           {
               Debug.Log($"未找到UI预制体{selfType}");
           }
           transfrom=GameObject.Instantiate(obj).transform;

           transfrom.gameObject.SetActive(false);

           UiRoot.SetParent(transfrom,false,selfType==WindowType.TipsWindow);
       }
       return true;
    }
}

/// <summary>
/// 窗体类型
/// </summary>
public enum WindowType
{ 
    LoginWindow,
    StoreWindow,
    TipsWindow,//提示窗口
}
/// <summary>
/// 场景类型，目的：提供根据场景类型进行预加载
/// </summary>
public enum SceneType
{
    None,
    Login,
    Battle,
}