using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseWindow
{
    protected Transform transfrom;//UI窗体
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
        buttonList = transfrom.GetComponentsInChildren<Button>(true);
    }
    //UI事件的注册
    protected virtual void RegisterUIEvent()
    {

    }
    //添加监听游戏事件
    protected virtual void OnAddListener()
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
    public virtual void Update(float deltatime)
    {

    }

    //--------------------------WindowManager服务
    public void Open()
    {
        if (transfrom == null)
        {
            if (Create())
            {
                Awake();// 初始化
            }
        }
        if (transfrom.gameObject.activeSelf == false)
        {
            UIRoot.SetParent(transfrom, true, selfType == WindowType.TipsWindow);
            transfrom.gameObject.SetActive(true);
            visible = true;
            OnEnable();//调用激活时候的事件
            OnAddListener();//添加事件
        }
    }
    public void Close(bool isDestory = false)
    {
        if (transfrom.gameObject.activeSelf == true)
        {
            OnRemoveListener();//移除游戏事件
            OnDisable();//隐藏时候触发的事件
            if (isDestory == false)
            {
                if (resident)
                {
                    transfrom.gameObject.SetActive(false);
                    UIRoot.SetParent(transfrom,false,false);
                }
                else
                {
                    GameObject.Destroy(transfrom.gameObject);
                    transfrom = null;
                }
            }
            else
            {
                GameObject.Destroy(transfrom.gameObject);
                transfrom = null;
            }

        }
    }
    public void PreLoad()
    {
        if (Create())
        {
            Awake();//初始化
        }
    }
    //场景类型
    public SceneType GetScenesType()
    {
        return sceneType;
    }
    //窗体类型
    public WindowType GetWindowType()
    {
        return selfType;
    }
    //获取根节点
    public Transform GetRoot()
    {
        return transfrom;
    }
    //是否可见
    public bool IsVisable()
    {
        return visible;
    }
    //是否常驻
    public bool IsResident()
    {
        return resident;
    }
    //----内部----根据资源名称创建UI物体
    private bool Create()
    {
        if (string.IsNullOrEmpty(resName))
        {
            return false;
        }
        if (transfrom == null)
        {
            var obj = Resources.Load<GameObject>(resName);
            if (obj == null)
            {
                Debug.Log($"未找到UI预制体{selfType}");
                return false;
            }
            transfrom = GameObject.Instantiate(obj).transform;

            transfrom.gameObject.SetActive(false);

            UIRoot.SetParent(transfrom, false, selfType == WindowType.TipsWindow);
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