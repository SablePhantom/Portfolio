using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Camera cam;

    public void Initialize(Camera camera)
    {
        cam = camera;
    }
    public abstract void ShootBullet();
}