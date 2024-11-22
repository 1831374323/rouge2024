using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace rouge2024
{
    [CreateAssetMenu(fileName = "createCube", menuName = "Custom/Skills/createCube")]
    public class createCube : SkillData_Base
    {
        public float _coolDown = 10;
        public GameObject cube;
        public override float coolDown
        {
            get { return _coolDown; }
        }

        public override void DoSkill()
        {
            Vector2 screenPosition = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Instantiate(cube, hit.point, Quaternion.identity);
            }
            Debug.Log("createCube");
        }
    }
}