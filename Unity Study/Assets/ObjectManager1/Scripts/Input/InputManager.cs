using System.Collections;
using NUnit.Framework.Constraints;
using ObjectManager1;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public void Init()
    {
        StartCoroutine(HandlePlayerInput());
    }
    private IEnumerator HandlePlayerInput()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                CommandInvoker<MovePlayerParam>.Execute(new MovePlayerParam()
                {
                    ObjectId = ObjectId.Player,
                    MoveDirection = new Vector3(0f, 0f, 1f),
                });
            }
            if (Input.GetKey(KeyCode.A))
            {
                CommandInvoker<MovePlayerParam>.Execute(new MovePlayerParam()
                {
                    ObjectId = ObjectId.Player,
                    MoveDirection = new Vector3(-1f, 0f, 0f),
                });
            }
            if (Input.GetKey(KeyCode.S))
            {
                CommandInvoker<MovePlayerParam>.Execute(new MovePlayerParam()
                {
                    ObjectId = ObjectId.Player,
                    MoveDirection = new Vector3(0f, 0f, -1f),
                });
            }
            if (Input.GetKey(KeyCode.D))
            {
                CommandInvoker<MovePlayerParam>.Execute(new MovePlayerParam()
                {
                    ObjectId = ObjectId.Player,
                    MoveDirection = new Vector3(1f, 0f, 0f),
                });
            }
            yield return null;
        }
    }
}
