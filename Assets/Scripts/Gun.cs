
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage =10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;
    public Camera fpsCam;


    private float nextTimeFire = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeFire) {
            nextTimeFire = Time.time + 1f / fireRate;
            shoot();
        }
    }

    void shoot() {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {

            Debug.Log(hit.transform.name);
           Enemy enemy =  hit.transform.GetComponent<Enemy>();

            if (enemy != null) {
                enemy.takeDamage(damage);
            }

            if (hit.rigidbody) {
                hit.rigidbody.AddForce(hit.normal * impactForce);
            }
        }


    }
}
