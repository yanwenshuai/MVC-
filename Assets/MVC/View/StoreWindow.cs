using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreWindow : BaseWindow
{
    public StoreWindow()
    {
        resName="UI/Window/StoreWindow";
        resident=true;
        selfType=WindowType.StoreWindow;
        sceneType=SceneType.Login;
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnAddListener()
    {
        base.OnAddListener();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnRemoveListener()
    {
        base.OnRemoveListener();
    }

    protected override void RegisterUIEvent()
    {
        base.RegisterUIEvent();
        foreach(var button in buttonList) {
            switch(button.name)
            {
                case "BuyButton":
                button.onClick.AddListener(OnBuyButtonClick);
                break;
            }
        }
        
    }

    public  override void Update(float deltatime)
    {
        base.Update(deltatime);
        if(Input.GetKeyDown(KeyCode.A))
        {
           Close();
        }
    }
       private void OnBuyButtonClick()
    {
        Debug.Log("BuyButton 点击了");
    }

}
