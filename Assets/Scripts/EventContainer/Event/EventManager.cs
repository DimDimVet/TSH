using System;
using System.Collections.Generic;

public class EventManager
{
    //Запрос листа
    public static Func<List<Construction>> OnGetList;
    public static List<Construction> GetList()
    {
        return (List<Construction>)OnGetList?.Invoke();
    }

    //Запрос по hash
    public static Func<int, bool> OnIsActivObjectHash;
    public static bool IsActivObjectHash(int hash)
    {
        return (bool)OnIsActivObjectHash?.Invoke(hash);
    }

    //Запрос по hash
    public static Func<int, Construction> OnGetObjectHash;
    public static Construction GetObjectHash(int hash)
    {
        return (Construction)OnGetObjectHash?.Invoke(hash);
    }

    //Запрос Player
    public static Func<Construction> OnGetPlayer;
    public static Construction GetPlayer()
    {
        return (Construction)OnGetPlayer?.Invoke();
    }

    //Запрос Camera
    public static Func<Construction> OnGetCamera;
    public static Construction GetCamera()
    {
        return (Construction)OnGetCamera?.Invoke();
    }

    //Особые события
    //События активности Player
    public static Action<bool> OnIsActivGunPlayerShoot;
    public static void IsActivGunPlayerShoot(bool isShootGunPlayer)
    {
        OnIsActivGunPlayerShoot?.Invoke(isShootGunPlayer);
    }

    public static Action<bool> OnIsActivAvtoRifPlayerShoot;
    public static void IsActivAvtoRifPlayerShoot(bool isShootAvtoRifPlayer)
    {
        OnIsActivAvtoRifPlayerShoot?.Invoke(isShootAvtoRifPlayer);
    }
    //События активности Enemy
    //Передать группе Enemy TargetPlayer
    public static Action<Construction[], Construction[]> OnGetTargetPlayer;
    public static void GetTargetPlayer(Construction[] players, Construction[] grupEnemys)
    {
        OnGetTargetPlayer?.Invoke(players, grupEnemys);
    }
}
