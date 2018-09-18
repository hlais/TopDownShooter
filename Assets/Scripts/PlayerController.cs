using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Vector3 m_velocity;
    Rigidbody m_rigidBody;

    public void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_rigidBody.freezeRotation = true;

    }

    public void Move(Vector3 velocity)
    {
        m_velocity = velocity;
        
    }
    public void FixedUpdate()
    {
        m_rigidBody.MovePosition(m_rigidBody.position + m_velocity * Time.fixedDeltaTime);
    }
    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }
}