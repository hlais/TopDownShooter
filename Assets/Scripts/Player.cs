using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (PlayerController))]
public class Player: MonoBehaviour
{
    public float moveSpeed = 50;
    PlayerController controller;
    Camera viewCamera;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
        viewCamera = Camera.main;
    }
    private void Update()
    {

        Vector3 moveInput = new Vector3(CrossPlatformInputManager.GetAxisRaw("Horizontal"), 0, CrossPlatformInputManager.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, 0f);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 pointOfIntersection = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, pointOfIntersection, Color.red);
            controller.LookAt(pointOfIntersection);
        }
    }

}