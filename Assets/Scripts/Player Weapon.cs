using System;
using System.Numerics;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

public class PlayerWeapon : MonoBehaviour
{
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }
    private Transform aimTransform;
    public Transform aimPointPosition;
    public GameObject bullet;
    InputAction attackAction;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    private void Update()
    {
        HandleAiming();
        HandleShooting();
    }
    private void HandleAiming()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }
    private void HandleShooting()
    {
        if (attackAction.WasPressedThisFrame())
        {
            // Instantiate the bullet at the end of the gun
            GameObject instantiatedBullet = Instantiate(
                bullet,
                aimPointPosition.position,
                aimTransform.rotation
            );
        }
    }
}
