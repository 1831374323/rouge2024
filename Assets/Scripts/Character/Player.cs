using SyTool;
using UnityEngine;

namespace rouge2024
{

    public class Player : SingletonMono<Player>
    {
        public PlayerData playerData;
        public PlayerController controller;

        private bool isMoving;
        private Vector3 targetPosition;
        public void Move(Vector3 _targetPosition)
        {
            isMoving = true;
            targetPosition = _targetPosition;
        }

        public void Update()
        {
            if (isMoving)
            {
                float step = playerData.speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    isMoving = false;
                }
            }

        }

    }
}
