using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public Rigidbody2D rb;
    public int rockHealth;
    public Animator anim;
    public AudioSource rockBreakFX;

    private PlayerController tvPlayer;

    public GameObject rockSplosion;

    //public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        tvPlayer = FindObjectOfType<PlayerController>();

        rb.velocity = -transform.right * speed;
    }

    // Update is called once per frame
    private void Update()
    {

        transform.Translate(-transform.right * speed * Time.deltaTime);


        if(rockHealth <= 0)
        {
            DestroyProjectile();
            Instantiate(rockSplosion, this.transform.position, this.transform.rotation);
            rockBreakFX.Play();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
        //this.gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            DestroyProjectile();
        }

        if(other.tag == "AttackTrigger")
        {
            rockHealth -= 1;
            StartCoroutine(ResetAnimation());
            //DestroyProjectile();
        }
    }

    public IEnumerator ResetAnimation()
    {
        anim.SetBool("Damaged", true);
        yield return new WaitForSeconds(.1f);
        anim.SetBool("Damaged", false);
    }

}
