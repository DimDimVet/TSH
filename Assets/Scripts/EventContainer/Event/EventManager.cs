using System;
using System.Collections.Generic;

public class EventManager
{
    //������ ����� �������
    public static Func<List<Construction>> OnGetList;
    public static List<Construction> GetList()
    {
        return (List<Construction>)OnGetList?.Invoke();//�������� �� ������������ ����
    }

    //������ ����� ������� �� hash
    public static Func<int, Construction> OnGetObjectHash;
    public static Construction GetObjectHash(int hash)
    {
        return (Construction)OnGetObjectHash?.Invoke(hash);//�������� �� ������������ ����
    }

    //������ ����� Player
    public static Func<Construction> OnGetPlayer;//�������� �� ������������ ����
    public static Construction GetPlayer()
    {
        return (Construction)OnGetPlayer?.Invoke();//�������� �� ������������ ����
    }

    //������ ����� Camera
    public static Func<Construction> OnGetCamera;//�������� �� ������������ ����
    public static Construction GetCamera()
    {
        return (Construction)OnGetCamera?.Invoke();//�������� �� ������������ ����
    }


}
