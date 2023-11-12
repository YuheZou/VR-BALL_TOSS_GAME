using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private float HP = 100;
    private Transform player;
    private Animator enemyAni;
    public bool isDead;

    public GameManager GameManagerScript;


    // Start is called before the first frame update
    private void Start()
    {
        isDead = false;
        enemyAni = GetComponent<Animator>();
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        transform.LookAt(new Vector3(0, 0, 0));
    }


    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            moveForward();
        }
        if ((transform.position.x < 2 && transform.position.x > -2) || (transform.position.z < 2 && transform.position.z > -2))
        {
            Destroy(gameObject);
            GameManagerScript.getHurt();
        }
    }
    

    void moveForward()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void getHurt(int damage)
    {
        enemyAni.SetTrigger("GotHit");
        HP -= damage;
        if(HP <= 0)
        {
            isDead = true;
            enemyAni.SetTrigger("Dead");
            GameManagerScript.updateScore(5);
            //StartCoroutine(deathFadeOut());
        }
    }

    IEnumerator deathFadeOut()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
