using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    private GameObject _clone;

    private void Update()
    {
        if (Input.anyKey)
        {
            _clone = Instantiate(projectile, transform.position, transform.rotation);
            _clone.GetComponent<Rigidbody>().AddForce(_clone.transform.forward * 400);
        }
    }

}