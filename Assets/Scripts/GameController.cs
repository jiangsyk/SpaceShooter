using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Author:Luna
public class GameController : MonoBehaviour {

    public GameObject[] asteroids;

    public Vector3 asteroidPos;
    public float startWait = 2.5f;
    public float waveInterval = 5f;//每一波间隔
    public float spawnInterval = 1f;//每个陨石间隔
    public float spawnNum = 10;//每一次发射多少个
    public uint score = 0;

    public bool gameover = false;
    public GameObject gameOverText;
    public Text scoreText;

	void Start () {
        gameover = false;
        gameOverText.SetActive(false);
        scoreText.text = "Score: " + score;

        StartCoroutine(SpawnAsteroidWave());
	}
	
	void Update () {
        if(gameover && Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
	}

    public IEnumerator SpawnAsteroidWave()
    {
        yield return new WaitForSeconds(startWait);

        while(true)
        {
            for (int i = 0; i < spawnNum;i++ )
            {
                SpawnAsteroid();

                yield return new WaitForSeconds(spawnInterval);

                if(gameover)
                {
                    break;
                }
            }
            yield return new WaitForSeconds(waveInterval);
        }
    }
    public void SpawnAsteroid()
    {
        GameObject o = asteroids[Random.Range(0,asteroids.Length)];
        Vector3 p = new Vector3(Random.Range(-asteroidPos.x,asteroidPos.x),asteroidPos.y,asteroidPos.z);
        Quaternion q = Quaternion.identity;
        Instantiate(o, p, q);
    }
    public void AddScore(uint addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameover = true;
        gameOverText.SetActive(true);
    }
}
