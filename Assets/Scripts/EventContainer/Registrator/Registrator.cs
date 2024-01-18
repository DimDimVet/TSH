using UnityEngine;
using UnityEngine.AI;

public class Registrator : ListDataBase
{
    public GameObject ParentObject;
    public int ParentHash;
    public int thisHash;
    private void Start()
    {
        thisHash = this.gameObject.GetHashCode();
        Collider[] childrens = GetComponentsInChildren<Collider>();

        if (childrens != null)
        {
            for (int i = 0; i < childrens.Length; i++)
            {
                if (childrens[i].gameObject.GetHashCode() != thisHash)
                {
                    Registrator tempChildren = childrens[i].gameObject.AddComponent<Registrator>();
                    tempChildren.ParentObject = this.gameObject;
                    tempChildren.ParentHash = thisHash;
                }
            }
        }

        if (ParentObject == null)
        {
            Construction registrator = new Construction
            {
                Hash = thisHash,
                ParentHashObject = thisHash,
                GO= gameObject,
                Transform = gameObject.transform,
                HealtPlayer = GetComponent<HealtPlayer>(),
                HealtEnemy = GetComponent<HealtEnemy>(),
                MovePlayer = GetComponent<MoveBodyPlayer>(),
                CameraMove = GetComponent<CameraMove>(),
                CameraComponent = GetComponent<Camera>(),
                NavMeshAgent = GetComponent<NavMeshAgent>(),
                MoveEnemy = GetComponent<MoveEnemy>(),
            };
            ParentObject = this.gameObject;
            SetData(registrator);
        }
        else
        {
            Construction registrator = new Construction
            {
                Hash = thisHash,
                ParentHashObject = ParentHash,
                Transform = gameObject.transform,
                HealtPlayer = ParentObject.GetComponent<HealtPlayer>(),
                HealtEnemy = ParentObject.GetComponent<HealtEnemy>(),
            };
            SetData(registrator);
        }
    }

}
