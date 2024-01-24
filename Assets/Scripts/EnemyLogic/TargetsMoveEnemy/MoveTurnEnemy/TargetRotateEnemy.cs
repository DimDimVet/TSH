using UnityEngine;
using static EventBus;

public class TargetRotateEnemy : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;
    //êýø
    private Transform defaultTransform;
    public Transform DefaultTransform { get { return defaultTransform; } }

    private Transform target;
    public Transform Target { get { return target; } }

    private int thisHash;
    public int ThisHash { get { return thisHash; } }
    private Construction thisObject;
    public Construction ThisObject { get { return thisObject; } }
    public bool IsDead { get { return isDead; } }
    private bool isDead = false;
    private void OnEnable()
    {
        OnGetTargetPlayer += GetTarget;
        isDead = false;
        OnIsDead += StopRun;
    }
    private void OnDisable()
    {
        OnGetTargetPlayer -= GetTarget;
        OnIsDead -= StopRun;
    }
    private void StopRun(int _thisHash, bool _isDead, int costObject)
    {
        if (thisHash == _thisHash) { isDead = _isDead; }
    }
    public void SetTargetDefault()
    {
        thisHash = parentObject.GetHashCode();
        thisObject = GetObjectHash(thisHash);
        if (thisObject.Hash == 0) { return; }

        defaultTransform = parentObject.transform;
    }
    private void GetTarget(Construction[] players, Construction[] grupEnemys)
    {
        for (int i = 0; i < grupEnemys.Length; i++)
        {
            if (grupEnemys[i].Hash == thisHash)
            {
                for (int y = 0; y < players.Length; y++)
                {
                    if (players[y].Hash != 0){CreatTarget(players[y]);}
                    else{ClearTarget();}
                }
            }
        }
    }
    private void CreatTarget(Construction objectTarget)
    {
        target = objectTarget.Transform;
    }
    private void ClearTarget()
    {
        target = null;
        //target = Vector3.zero;
    }
}
