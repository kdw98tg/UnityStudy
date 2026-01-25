using UnityEngine;

namespace TransformStudy
{
    public class HandBase : MonoBehaviour
    {
        [SerializeField] protected float moveSpeed = 0.1f;

        public void RaiseHand()
        {
            transform.localRotation *= Quaternion.Euler(-moveSpeed, 0f, 0f);
        }

        public void PutDownHand()
        {
            transform.localRotation *= Quaternion.Euler(moveSpeed, 0f, 0f);
        }
    }
}