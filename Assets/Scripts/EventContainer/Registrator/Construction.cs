using UnityEngine;
using UnityEngine.AI;

public struct Construction
{
    public int Hash;
    public Transform Transform;
    public bool IsDead { get; set; }
    public bool SetActiv { get; set; }
    public HealtPlayer HealtPlayer;
    public MoveBodyPlayer MovePlayer;
    public CameraMove CameraMove;
    public Camera CameraComponent;
    public NavMeshAgent NavMeshAgent;
    public LogicMoveEnemy LogicMoveEnemy;
}
