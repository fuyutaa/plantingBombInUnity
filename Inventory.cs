using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject C4;
    public GameObject Explosion;
    public GameObject player;

    public static Inventory instance;

    public ParticleSystem explosion;

    public C4Manager c4Manager;

    public bool explosionOccurring;

    // delay times for ExplosionStart()
    public float explosionStopDelay = 5f;
    public float C4ExplosionDelay; 
    public float C4DespawnDelay = 0.3f;
    public float wallDestroyDelay;

    private void Start()
    {
        explosion = Explosion.GetComponent<ParticleSystem>();
    }

    public void ConsumeItem()
    {
        if(currentItem.isExplosive == true)
        {
            Debug.Log("Item identified as explosive");
            playerCollisionManager playerCollisionManager = player.GetComponent<playerCollisionManager>();
            if (playerCollisionManager.destroyableWall == true)
            {
                explosionOccurring = true;
                StartCoroutine(ExplosionStart());
                Debug.Log("explosion started");
            }
            else 
            {
                Debug.Log("Cannot explode nearby wall");
                return;
            }
        }
    }

    public IEnumerator ExplosionStart() // blinking until it gets stopped by != explosionOccurring
    {
            // Debug.Log("spawning C4"); 
            GameObject CloneC4 = Instantiate(C4);
            CloneC4.transform.position = player.transform.position;
            CloneC4.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(C4ExplosionDelay);
            
            // Debug.Log("c4 timer finished, exploding.");
            Explosion.transform.position = CloneC4.transform.position;
            explosion.Play();

            yield return new WaitForSeconds(C4DespawnDelay); 
            CloneC4.GetComponent<SpriteRenderer>().enabled = false;

            c4Manager = CloneC4.GetComponent<C4Manager>();
            Destroy(c4Manager.wallToDestroy);
            
    }
}