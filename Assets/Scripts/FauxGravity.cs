using UnityEngine;

public class FauxGravity : MonoBehaviour
{
    [SerializeField] private float GravityForce = 9.8f;

    public void Attract(GameObject body)
    {
        var bodyRigidBody = body.GetComponent<Rigidbody>();

        Vector3 gravity = (body.transform.position - transform.position).normalized;
        Vector3 bodyUp = body.transform.up;

        bodyRigidBody.AddForce(gravity * -GravityForce);

        /**
         * Quaternion.FromToRotation => creates a quaternion with the rotation between vectors
         * * operator merges difference with current rotation
         * 
         * this line calculates the new rotation based on the new body position
         */
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravity) * body.transform.rotation;
        body.transform.rotation = Quaternion.Slerp(body.transform.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
