using UnityEngine;
using System.Collections;
/*
 * Description: Hitter
 * Author:      JiangShu
 * Create Time: 2015/7/9 17:16:23
 */
public class Hitter : MonoBehaviour
{
    #region Properties
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    public GameObject enemyExplosion;


    public uint destroyAddScore = 5;
    private GameController gameController;
    #endregion Properties

    #region Functions
    void Awake()
    {
    }
    void Start()
    {
        gameController = GameObject.FindWithTag(Tags.GAME_CONTROLLER).GetComponent<GameController>();
    }
    void Update()
    {
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.BOUND) return;

        Destroy(gameObject);
        if (tag == Tags.ASTEROID)
        {
            Instantiate(asteroidExplosion, transform.position, transform.rotation);
            gameController.AddScore(destroyAddScore);
        }

        Destroy(other.gameObject);
        if(other.tag == Tags.PLAYER)
        {
            Destroy(other.transform.parent.gameObject);
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
    }
    #endregion Functions

    
}
