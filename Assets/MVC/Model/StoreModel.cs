using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//数据模型
public class StoreModel : Singleton<StoreModel>
{
    public  Dictionary<int,Prop> PropDic=new Dictionary<int, Prop>();
    public void Add(Prop prop){
        if(PropDic.ContainsKey(prop.id))
        {
            PropDic[prop.id]=prop;
        }
    }
}

public class Prop
{
    public int id;
    public string name;
    public string describe;
    public int price;
}