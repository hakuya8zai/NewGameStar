using UnityEngine;

namespace ActionCode2D.Cameras
{
    [DisallowMultipleComponent]
    public sealed class CameraLockFollow : MonoBehaviour
    {
        public Transform target;
        public float smoothSpeed = 0.125f;
        public Vector2 offset;

        private void LateUpdate()
        {
            UpdatePosition();
        }

        private void OnValidate()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            if (target)
            {
                Vector2 desiredPosition =new Vector2(target.position.x,target.position.y) + offset;
                Vector2 pos = Vector2.Lerp(transform.position,desiredPosition,smoothSpeed);
                transform.position =new Vector3 (pos.x,pos.y,-20.0f);
                
            }
        }
    }
}