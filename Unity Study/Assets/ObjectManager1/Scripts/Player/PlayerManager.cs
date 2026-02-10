using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace ObjectManager1
{
    public class PlayerManager : MonoBehaviour
    {
        private Player player = null;

        private void Awake()
        {
            player = GetComponentInChildren<Player>();
        }

        public void Init()
        {
            player.Init();
        }

        public void MovePlayer(ObjectId objectId, Vector3 moveDirection)
        {
            player.Move(objectId, moveDirection);
        }
    }

}