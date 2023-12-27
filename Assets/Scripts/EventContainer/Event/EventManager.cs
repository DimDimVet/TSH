using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public static Action<int, bool, int> OnIsDead;
    public static void IsDead(int thisHash, bool isDead, int costObject)
    {
        OnIsDead?.Invoke(thisHash, isDead, costObject);
    }

    public static Action<int, int,int, bool, int, RaycastHit> OnIsReternBull;//возврат пули с данными об попадании
    public static void IsReternBull(int thisHash, int hashObjectDamagAcceptance, int costObject, bool isKillObjectAcceptance, int setDamage, RaycastHit hit)
    {
        OnIsReternBull?.Invoke(thisHash, hashObjectDamagAcceptance, costObject, isKillObjectAcceptance, setDamage, hit);
    }

    public static Action<int, int> OnGetDamage;
    public static void GetDamage(int getHash, int damage)
    {
        OnGetDamage?.Invoke(getHash, damage);
    }

    public static Action<int, int> OnGetUIDamage;
    public static void GetUIDamage(int getHash, int healt)
    {
        OnGetUIDamage?.Invoke(getHash, healt);
    }
    //События активности UI
    public static Action<bool> OnIsRunMainPanel;//Запуск партиклов
    public static void IsRunMainPanel(bool isRun)
    {
        OnIsRunMainPanel?.Invoke(isRun);
    }

    public static Action OnUpDateAudioParametr;//Запуск партиклов
    public static void UpDateAudioParametr()
    {
        OnUpDateAudioParametr?.Invoke();
    }

    //События активности Player
    public static Action<int, bool> OnIsActivGunPlayerShoot;//Запуск партиклов
    public static void IsActivGunPlayerShoot(int thisHash, bool isShootGunPlayer)
    {
        OnIsActivGunPlayerShoot?.Invoke(thisHash, isShootGunPlayer);
    }

    public static Action<int, bool> OnIsActivAvtoRifPlayerShoot;
    public static void IsActivAvtoRifPlayerShoot(int thisHash, bool isShootAvtoRifPlayer)
    {
        OnIsActivAvtoRifPlayerShoot?.Invoke(thisHash, isShootAvtoRifPlayer);
    }

    public static Action<int,int, bool> OnShootStaisticPlayer;
    public static void ShootStaisticPlayer(int hashObjectDamagAcceptance, int costTargetObject, bool isKillObjectAcceptance)
    {
        OnShootStaisticPlayer?.Invoke(hashObjectDamagAcceptance, costTargetObject, isKillObjectAcceptance);
    }

    public static Action<Statistic> OnUIStaistic;
    public static void UIStaistic(Statistic stat)
    {
        OnUIStaistic?.Invoke(stat);
    }
    //События активности Enemy
    //Передать группе Enemy TargetPlayer
    public static Action<Construction[], Construction[]> OnGetTargetPlayer;
    public static void GetTargetPlayer(Construction[] players, Construction[] grupEnemys)
    {
        OnGetTargetPlayer?.Invoke(players, grupEnemys);
    }

    public static Action<int, bool> OnIsReadinessShoot;
    public static void IsReadinessShoot(int thisHash, bool isReadinessShoot)
    {
        OnIsReadinessShoot?.Invoke(thisHash, isReadinessShoot);
    }

    public static Action<int, bool> OnIsActivGunEnemyShoot;
    public static void IsActivGunEnemyShoot(int thisHash, bool isShootGunEnemy)
    {
        OnIsActivGunEnemyShoot?.Invoke(thisHash, isShootGunEnemy);
    }


}
