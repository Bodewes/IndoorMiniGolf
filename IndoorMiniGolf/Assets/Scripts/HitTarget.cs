using UnityEngine;

public class HitTarget : MonoBehaviour
{


    public GameObject BallsGroup { get; private set; }
    public GameObject Explosion { get; private set; }

    void Awake()
    {
        BallsGroup = GameObject.Find("Balls");
        Explosion = GameObject.Find("Explosion");
    }

    // These public fields become settable properties in the Unity editor.
    public GameObject underworld;
    public GameObject objectToHide;

    // Occurs when this object starts colliding with another object
    void OnCollisionEnter(Collision collision)
    {
        BallsGroup.BroadcastMessage("OnReset");

        var p = Explosion.GetComponent<ParticleSystem>();
        p.Play();

        // Hide the stage and show the underworld.
        //objectToHide.SetActive(false);
        //underworld.SetActive(true);

        // Disable Spatial Mapping to let the spheres enter the underworld.
        //SpatialMapping.Instance.MappingEnabled = false;
    }
}
