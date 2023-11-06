using UnityEngine;

public class Registrator : ListDataBase
{
    private void Start()
    {
        Construction registrator = new Construction
        {
            Hash = gameObject.GetHashCode(),
            Transform = gameObject.transform,
            HealtPlayer = GetComponent<HealtPlayer>(),
            MovePlayer = GetComponent<MovePlayer>(),
            CameraMove= GetComponent<CameraMove>(),
        };
        SetData(registrator);
    }
}
