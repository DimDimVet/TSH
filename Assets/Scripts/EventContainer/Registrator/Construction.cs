using UnityEngine;

public struct Construction
{
    public int Hash;
    public Transform Transform;
    public bool IsDestroy { get; set; }
    public bool SetActiv { get; set; }
    public HealtPlayer HealtPlayer;
    public MovePlayer MovePlayer;
    public CameraMove CameraMove;
}
