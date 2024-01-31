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
    //������� ���� ����
    private List<Construction> SetList()
    {
        listData = GetData();
        return listData;
    }
    //������ � ������� ������ �� ����� �� ����
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
    //������ � ������� ������-Player �� �����
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
    //������ � ������� ������-Camera �� �����
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
    //������ � ������� �������-Enemys � ������
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
