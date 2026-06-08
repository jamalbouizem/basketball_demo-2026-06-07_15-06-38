using UnityEngine;

public class BallLogic : MonoBehaviour
{
    private Vector3 playerPositionOnLaunch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPositionOnLaunch = GameObject.FindGameObjectWithTag("Player").transform.position;
        Invoke("AutoDestroy", 2.5f);
    }

    // Update is called once per frame
    void Update()
    {       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hoop"))
        {
            float dst = Vector3.Distance(playerPositionOnLaunch, collision.gameObject.transform.position);
            TimerManager.PlayerScore += 1 + ((int)dst);
        }
    }

    void AutoDestroy ()
    {
        Destroy(gameObject);
    }
}
