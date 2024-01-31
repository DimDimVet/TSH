using Processing.Masiv;
using System.Collections.Generic;
using static EventBus;

public class Executor : ListDataBase
{
    private List<Construction> listData;
    private Construction[] tempEnemys;
    private void OnEnable()
    {
        ClearData();
        OnGetObjectHash += SetObjectHash;
        OnGetList += SetList;
        OnGetPlayer += SetPlayer;
        OnGetCamera += SetCamera;
        OnGetEnemys += SetEnemys;
    }
    private void OnDisable()
    {
        OnGetObjectHash -= SetObjectHash;
        OnGetList -= SetList;
        OnGetPlayer -= SetPlayer;
        OnGetCamera -= SetCamera;
        OnGetEnemys -= SetEnemys;
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
    //Найдем и отдадим объекты-Enemys в списке
    private Construction[] SetEnemys()
    {
        Masiv<Construction> tempMassiv = new Masiv<Construction>();
        listData = GetData();
        for (int i = 0; i < listData.Count; i++)
        {
            if (listData[i].HealtEnemy is HealtEnemy)
            {
                tempEnemys = tempMassiv.Creat(listData[i], tempEnemys);
            }
        }
        return tempEnemys;
    }
}
