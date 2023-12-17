using UnityEngine;
using UnityEngine.AI;

public struct Construction
{
    public int Hash;
    public int ParentHashObject;
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
