using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace rouge2024
{
    public class PlayerController : MonoBehaviour
    {
        private Player player;
        private PlayerData playerData;

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Vector2 screenPosition = Mouse.current.position.ReadValue();
                Ray ray = Camera.main.ScreenPointToRay(screenPosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    player.Move(hit.point);
                }
            }
        }

        public void OnSkill1(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                SkillManager.Instance.DoSkill(0);
            }
        }

        public void OnSkill2(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                SkillManager.Instance.DoSkill(1);
            }
        }

        public void OnSkill3(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                SkillManager.Instance.DoSkill(2);
            }
        }

        public void OnSkill4(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                SkillManager.Instance.DoSkill(3);
            }
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Normal Attack");
            }
        }

        #region -----------------lifecycle-----------------
        void Awake()
        {
            player = GetComponent<Player>();
            playerData = player.playerData;
        }


        #endregion

    }
}