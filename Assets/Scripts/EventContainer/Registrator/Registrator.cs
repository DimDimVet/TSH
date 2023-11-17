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
            MovePlayer = GetComponent<MoveBodyPlayer>(),
            CameraMove= GetComponent<CameraMove>(),
            CameraComponent=GetComponent<Camera>(),
            NavMeshAgent=GetComponent<NavMeshAgent>()
        };
        SetData(registrator);
    }
}
