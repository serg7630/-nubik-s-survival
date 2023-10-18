using System;
using UnityEngine;

namespace RakibJahan
{
    public class MovingPlayer : MonoBehaviour
    {
        [SerializeField] private float maxDisplacement = 0.2f;
        [SerializeField] private float maxPositionX = 2f;
        private Vector2 _anchorPosition;


        private void Update()
        {
            float inputX = GetInput();

            float displacementX = GetDisplacement(inputX);

            displacementX = SmoothOutDisplacement(displacementX);

            Vector3 newPosition = GetNewLocalPosition(displacementX);

            newPosition = GetLimitedLocalPosition(newPosition);

            transform.localPosition = newPosition;
        }

        private Vector3 GetLimitedLocalPosition(Vector3 position)
        {
            position.x = Mathf.Clamp(position.x, -maxPositionX, maxPositionX);
            return position;
        }
        private Vector3 GetNewLocalPosition(float displacementX)
        {
            Vector3 lastPosition = transform.localPosition;
            float newPositionX = lastPosition.x + displacementX;
            Vector3 newPosition = new Vector3(newPositionX, lastPosition.y, lastPosition.z);
            return newPosition;
        }
        private float GetInput()
        {
            float inputX = 0f;
            if (Input.GetMouseButtonDown(0))
            {
                _anchorPosition = Input.mousePosition;
            }

            else if (Input.GetMouseButton(0))
            {
                inputX = (Input.mousePosition.x - _anchorPosition.x);
                _anchorPosition = Input.mousePosition;
            }
            return inputX;
        }
        private float GetDisplacement(float inputX)
        {
            float displacementX = 0f;
            displacementX = inputX * Time.deltaTime;
            return displacementX;
        }
        private float SmoothOutDisplacement(float displacementX)
        {
            return Mathf.Clamp(displacementX, -maxDisplacement, maxDisplacement);
        }
    }
}
