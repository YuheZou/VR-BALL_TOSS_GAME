using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera fpsCam;
    [SerializeField] private float distance = 1000f;
    [SerializeField] private int damage = 20;


    public GameManager GameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }

    private void shoot()
    {
        Ray ray = new Ray(fpsCam.transform.position, fpsCam.transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            if (hitInfo.collider.tag == "Enemy")
            {
                EnemyControl enemy = hitInfo.collider.GetComponent<EnemyControl>();
                if (!enemy.isDead)
                {
                    enemy.getHurt(damage);
                }
            
            }

            if (hitInfo.collider.tag == "Health")
            {
                Destroy(hitInfo.collider.gameObject);
                GameManagerScript.heal();
            }

            if (hitInfo.collider.tag == "Strength")
            {
                Destroy(hitInfo.collider.gameObject);
                damage *= 2;
                StartCoroutine(powerupTime());
            }
        }
    }

    IEnumerator powerupTime()
    {
        yield return new WaitForSeconds(5);
        damage /= 2;
    }
}
