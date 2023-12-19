using System.Collections.Generic;
using static EventManager;

public class Executor : ListDataBase
{
    private List<Construction> listData;
    private void OnEnable()
    {
        OnGetObjectHash += SetObjectHash;
        //OnIsActivObjectHash += SetIsActivObjectHash;
        OnGetList += SetList;
        OnGetPlayer += SetPlayer;
        OnGetCamera += SetCamera;
    }
    private void OnDisable()
    {
        OnGetObjectHash -= SetObjectHash;
        //OnIsActivObjectHash -= SetIsActivObjectHash;
        OnGetList -= SetList;
        OnGetPlayer -= SetPlayer;
        OnGetCamera -= SetCamera;
    }
    //Отдадим весь лист
    private List<Construction> SetList()
    {
        listData = GetData();
        return listData;
    }
    //Найдем и отдадим объект из листа по хешу
    private Construction SetObjectHash(int hash)
    {
        listData = GetData();
        for (int i = 0; i < listData.Count; i++)
        {
            if (listData[i].Hash == hash)
            {
                return listData[i];
            }
        }
        return new Construction();
    }
    //Найдем и отдадим объект-Player из листа
    private Construction SetPlayer()
    {
        listData = GetData();
        for (int i = 0; i < listData.Count; i++)
        {
            if (listData[i].HealtPlayer is HealtPlayer)
            {
                return listData[i];
            }
        }
        return new Construction();
    }
    //Найдем и отдадим объект-Camera из листа
    private Construction SetCamera()
    {
        listData = GetData();
        for (int i = 0; i < listData.Count; i++)
        {
            if (listData[i].CameraMove is CameraMove)
            {
                return listData[i];
            }
        }
        return new Construction();
    }
}
