using System;
using System.Collections.Generic;

public class EventManager
{
    //запрос листа объекта
    public static Func<List<Construction>> OnGetList;
    public static List<Construction> GetList()
    {
        return (List<Construction>)OnGetList?.Invoke();//запросим из пространства лист
    }

    //запрос листа объекта по hash
    public static Func<int, Construction> OnGetObjectHash;
    public static Construction GetObjectHash(int hash)
    {
        return (Construction)OnGetObjectHash?.Invoke(hash);//запросим из пространства лист
    }

    //запрос листа Player
    public static Func<Construction> OnGetPlayer;//запросим из пространства лист
    public static Construction GetPlayer()
    {
        return (Construction)OnGetPlayer?.Invoke();//запросим из пространства лист
    }

    //запрос листа Camera
    public static Func<Construction> OnGetCamera;//запросим из пространства лист
    public static Construction GetCamera()
    {
        return (Construction)OnGetCamera?.Invoke();//запросим из пространства лист
    }


}
