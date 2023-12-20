using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class StatisticPlayer : MonoBehaviour
{
    private Statistic[] statistics;
    private Statistic tempStat;
    private int countCost=0;
    private int thisHash;

    private void Start()
    {
        thisHash=gameObject.GetHashCode();
    }
    private void OnEnable()
    {
        OnShootStaisticPlayer += ShootStatistic;
        if (statistics != null) { Clean(statistics); }
    }
    private void OnDisable()
    {
        OnShootStaisticPlayer -= ShootStatistic;
    }
    private void ShootStatistic(int hashObjectDamagAcceptance, int costTargetObject, bool isKillObjectAcceptance)
    {
        
        tempStat =new Statistic {HashPlayer= thisHash, Hash = hashObjectDamagAcceptance,
                                 CostTargetObject= costTargetObject,IsKillObjectAcceptance= isKillObjectAcceptance};
        if (statistics == null)
        {
            countCost = CountCost(costTargetObject);
            tempStat.CountCost = countCost;
            statistics = Creat(tempStat, statistics);
            UIStaistic(tempStat);
        }
        else {
            for (int i = 0; i < statistics.Length; i++) 
            {
                if (statistics[i].Hash == tempStat.Hash) { return; }
            }
            countCost = CountCost(costTargetObject);
            tempStat.CountCost = countCost;
            statistics = Creat(tempStat, statistics);
            UIStaistic(tempStat);
        }
    }
    private int CountCost(int _countCost)
    {
        return countCost+_countCost;
    }
    //
    private void Clean(Statistic[] massivObject)
    {
        if (massivObject != null)
        {
            Array.Clear(massivObject, 0, massivObject.Length);
            return;
        }
    }
    private Statistic[] Creat(Statistic intObject, Statistic[] massivObject)
    {
        bool isStop = false;
        if (massivObject != null)
        {
            for (int i = 0; i < massivObject.Length; i++)
            {
                if (!isStop)
                {
                    if (massivObject[i].Hash == 0)
                    {
                        massivObject[i] = intObject;
                        isStop = true;
                    }
                }
            }
            if (!isStop)
            {
                int newLength = massivObject.Length + 1;
                Array.Resize(ref massivObject, newLength);
                massivObject[newLength - 1] = intObject;
                return massivObject;
            }
        }
        else
        {
            massivObject = new Statistic[] { intObject };
            return massivObject;
        }
        return massivObject;
    }
}
