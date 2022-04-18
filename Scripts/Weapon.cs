using Interfaces;
using UnityEngine;

public class Weapon: MonoBehaviour, IRotatable
{
    
    private float offset = -90f;
    public GameObject bullet;
    public Transform shotPoint;

    public float timeBtwShots;
    public float startTimeBtwShots;
    private void Update()
    {
        
        Shoot();
        Flip();
        
    }

    public void Shoot()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void Flip()
    {
        /*Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        */
        
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, rotZ + offset);
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x)
            transform.rotation = Quaternion.Euler(180, 0, -rotZ + offset);

    }
}