using UnityEngine;
using UnityEngine.AI;

public class Registrator : ListDataBase
{
    private void Start()
    {
        Construction registrator = new Construction
        {
            Hash = gameObject.GetHashCode(),
            IsDead =false,
            Transform = gameObject.transform,
            HealtPlayer = GetComponent<HealtPlayer>(),
            HealtEnemy = GetComponent<HealtEnemy>(),
            MovePlayer = GetComponent<MoveBodyPlayer>(),
            CameraMove= GetComponent<CameraMove>(),
            CameraComponent=GetComponent<Camera>(),
            NavMeshAgent=GetComponent<NavMeshAgent>(),
            MoveEnemy=GetComponent<MoveEnemy>(),
        };
        SetData(registrator);
    }
}
