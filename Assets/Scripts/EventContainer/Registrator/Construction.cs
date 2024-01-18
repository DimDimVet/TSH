using Processing;
using UnityEngine;
using UnityEngine.AI;

public struct Construction: IConstructor
{
    public int Hash { get; set; }
    public int ParentHashObject;
    public GameObject GO;
    public Transform Transform;
    public bool SetActiv { get; set; }
    public HealtPlayer HealtPlayer;
    public HealtEnemy HealtEnemy;
    public MoveBodyPlayer MovePlayer;
    public CameraMove CameraMove;
    public Camera CameraComponent;
    public NavMeshAgent NavMeshAgent;
    public MoveEnemy MoveEnemy;
}
