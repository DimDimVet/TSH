using UnityEngine;
using static EventManager;

public class TargetRotateEnemy : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;
    //���
    private Transform defaultTransform;
    public Transform DefaultTransform { get { return defaultTransform; } }

    private Vector3 target;
    public Vector3 Target { get { return target; } }

    private int thisHash;
    public int ThisHash { get { return thisHash; } }
    private Construction thisObject;
    public Construction ThisObject { get { return thisObject; } }

    private void OnEnable()
    {
        OnGetTargetPlayer += GetTarget;
    }
    private void OnDisable()
    {
        OnGetTargetPlayer -= GetTarget;
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
        target = objectTarget.Transform.position;
    }
    private void ClearTarget()
    {
        target = Vector3.zero;
    }
}
