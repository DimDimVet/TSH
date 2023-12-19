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
}
