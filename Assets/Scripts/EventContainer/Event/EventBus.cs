using System;
using System.Collections.Generic;
using UnityEngine;

public class EventBus
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

    //Запрос Enemys
    public static Func<Construction[]> OnGetEnemys;
    public static Construction[] GetEnemys()
    {
        return (Construction[])OnGetEnemys?.Invoke();
    }

    //Запрос Camera
    public static Func<Construction> OnGetCamera;
    public static Construction GetCamera()
    {
        return (Construction)OnGetCamera?.Invoke();
    }

    //SelectCursor
    public static Action<bool> OnSelectCursor;
    public static void SelectCursor(bool isActivCursor)
    {
        OnSelectCursor?.Invoke(isActivCursor);
    }
    //Особые события
    public static Action<int, bool, int> OnIsDead;
    public static void IsDead(int thisHash, bool isDead, int costObject)//kill person
    {
        OnIsDead?.Invoke(thisHash, isDead, costObject);
    }

    public static Action<int, bool> OnIsVictory;
    public static void IsVictory(int thisHash, bool isVictory)//Победа игрока
    {
        OnIsVictory?.Invoke(thisHash, isVictory);
    }

    public static Action<bool> OnEnableUIElement;//отключение элементов интерфейса
    public static void EnableUIElement(bool isOffUIElement)
    {
        OnEnableUIElement?.Invoke(isOffUIElement);
    }

    public static Action<int, int, int, bool, int, RaycastHit> OnIsReternBull;//возврат пули с данными об попадании
    public static void IsReternBull(int thisHash, int hashObjectDamagAcceptance, int costObject, bool isKillObjectAcceptance, int setDamage, RaycastHit hit)
    {
        OnIsReternBull?.Invoke(thisHash, hashObjectDamagAcceptance, costObject, isKillObjectAcceptance, setDamage, hit);
    }

    public static Action<int, int, TypeBullet> OnGetDamage;//отправим дамаг
    public static void GetDamage(int getHash, int damage, TypeBullet typeBullet)
    {
        OnGetDamage?.Invoke(getHash, damage, typeBullet);
    }

    public static Action<int> OnControlHashDamage;//проверим по хешу дамаг в пули
    public static void ControlHashDamage(int contorlHash)
    {
        OnControlHashDamage?.Invoke(contorlHash);
    }

    public static Func<int, float, bool> OnGetEssence;
    public static bool GetHealtLoot(int getHash, float essence)
    {
        return (bool)OnGetEssence?.Invoke(getHash, essence);
    }

    public static Action<int> OnIsReternLoot;//возврат loot
    public static void IsReternLoot(int thisHash)
    {
        OnIsReternLoot?.Invoke(thisHash);
    }

    public static Action<int, int> OnGetUIDamage;
    public static void GetUIDamage(int getHash, int healt)
    {
        OnGetUIDamage?.Invoke(getHash, healt);
    }
    //События активности UI
    public static Action<bool> OnIsRunMainPanel;
    public static void IsRunMainPanel(bool isRun)
    {
        OnIsRunMainPanel?.Invoke(isRun);
    }

    public static Action OnUpDateAudioParametr;
    public static void UpDateAudioParametr()
    {
        OnUpDateAudioParametr?.Invoke();
    }

    public static Action<Mode> OnSelectParametr;
    public static void SelectParametr(Mode currentMode)
    {
        OnSelectParametr?.Invoke(currentMode);
    }

    public static Action<Mode, bool, int> OnChargingParametr;
    public static void ChargingParametr(Mode mode, bool isClipReLoad, int countBull)
    {
        OnChargingParametr?.Invoke(mode, isClipReLoad, countBull);
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

    public static Action<int, int, bool> OnShootStaisticPlayer;
    public static void ShootStaisticPlayer(int hashObjectDamagAcceptance, int costTargetObject, bool isKillObjectAcceptance)
    {
        OnShootStaisticPlayer?.Invoke(hashObjectDamagAcceptance, costTargetObject, isKillObjectAcceptance);
    }

    public static Action<Statistic> OnUIStaistic;
    public static void UIStaistic(Statistic stat)
    {
        OnUIStaistic?.Invoke(stat);
    }
    //счетчик врагов
    public static Action<int> OnUICountEnemys;
    public static void UICountEnemys(int enemys)
    {
        OnUICountEnemys?.Invoke(enemys);
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
