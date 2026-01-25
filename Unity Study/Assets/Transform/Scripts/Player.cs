using System;
using UnityEngine;

namespace TransformStudy
{
    public class Player : MonoBehaviour
    {
        private RightHand rightHand = null;
        private LeftHand leftHand = null;

        private float moveSpeed = 0.01f;

        private void Awake()
        {
            rightHand = GetComponentInChildren<RightHand>();
            leftHand = GetComponentInChildren<LeftHand>();
        }

        private void Update()
        {
            //손 움직임 제어
            HandleHands();
            //플레이어 움직임 제어
            MovePlayer();
        }

        private void MovePlayer()
        {
            if (Input.GetKey(KeyCode.W))
                MoveForward();

            if (Input.GetKey(KeyCode.A))
                MoveLeft();

            if (Input.GetKey(KeyCode.S))
                MoveBackward();

            if (Input.GetKey(KeyCode.D))
                MoveRight();
        }

        private void HandleHands()
        {
            //오른손 올리는 키
            if (Input.GetKey(KeyCode.E))
            {
                rightHand.RaiseHand();
            }
            //오른손 내리는 키
            if (Input.GetKey(KeyCode.C))
            {
                rightHand.PutDownHand();
            }
            //왼손 올리는 키
            if (Input.GetKey(KeyCode.Q))
            {
                leftHand.RaiseHand();
            }
            //왼손 내리는 키
            if (Input.GetKey(KeyCode.Z))
            {
                leftHand.PutDownHand();
            }
        }

        private void MoveRight()
        {
            transform.position += new Vector3(moveSpeed, 0, 0);
        }

        private void MoveBackward()
        {
            transform.position += new Vector3(0, 0, -moveSpeed);
        }

        private void MoveLeft()
        {
            transform.position += new Vector3(-moveSpeed, 0, 0);
        }

        private void MoveForward()
        {
            transform.position += new Vector3(0, 0, moveSpeed);
        }


    }
}