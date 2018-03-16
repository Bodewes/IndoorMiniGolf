using UnityEngine;

public class SphereCommands : MonoBehaviour
{
    Vector3 originalPosition;

    // Use this for initialization
    void Start()
    {
        // Grab the original local position of the sphere when the app starts.
        originalPosition = this.transform.localPosition;
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect(string focusedObject)
    {
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.mass = 0.1f;
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
        else
        {

            var direction = Camera.main.transform.forward * -1f;
            direction.y *= -1.0f;
            // Hit it!
            var rigidbody = this.GetComponent<Rigidbody>();
            rigidbody.AddExplosionForce(25,rigidbody.transform.position+direction,2,1);

        }
    }

    // Called by SpeechManager when the user says the "Reset world" commands
    void OnReset()
    {
        // If the sphere has a Rigidbody component, remove it to disable physics.
        var rigidbody = this.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.isKinematic = true;
            Destroy(rigidbody);
        }

        // Put the sphere back into its original local position.
        this.transform.localPosition = originalPosition;
    }

    // Called by SpeechManager when the user says the "Drop sphere" command
    void OnDrop()
    {
        // Just do the same logic as a Select gesture.
        OnSelect("SpeechCommand");
    }
}