using System.Collections.Generic;
using UnityEngine;

public class InitiateIsland : MonoBehaviour
{
    public GameObject[] islandPrefab;
    public Transform[] islandPlaceholder;
    [SerializeField]
    private CameraControl cameraControlScript;
    public Portal currentPortalExit;
    public Transform currentPortalEnter;
    public Transform firstPortalEnter;
    private EnemySpawningSystem enemySpawnSystem;
    public List<Transform> enemyWaypoints;
    //private Transform spawnPosition;
    
    void Start()
    {
        StartIslandSpawning();
    }

    public void StartIslandSpawning(){
        Time.timeScale = 1;
        cameraControlScript.targetFocus = new Transform[4];
        enemySpawnSystem = this.GetComponent<EnemySpawningSystem>();
        
        for(int i = 0; i < 4; i++){
            //Generate Island
            GameObject newIsland = Instantiate(islandPrefab[Random.Range(0, islandPrefab.Length)], islandPlaceholder[i].position, islandPlaceholder[i].rotation);
            newIsland.transform.parent = GameObject.Find("Island Parent").transform;
            newIsland.name = "Island " + (i+1);
            cameraControlScript.targetFocus[i] = newIsland.transform.Find("Lookat");
            
            
            // Portal System
            if(i != 0){
                currentPortalEnter = newIsland.transform.Find("Portal Enter");
                currentPortalExit.nextPortal = currentPortalEnter;
            } else{
                firstPortalEnter = newIsland.transform.Find("Portal Enter");
            }

            currentPortalExit = newIsland.transform.Find("Portal Exit").GetComponent<Portal>();

            // Get Waypoints
            Transform waypointsParent = newIsland.transform.Find("Waypoint Parent");
            int waypointsCount = waypointsParent.childCount;
            if(waypointsParent!= null){
                for(int j = 0; j < waypointsCount; j++){
                    enemyWaypoints.Add(waypointsParent.GetChild(j));
                }
            }
        }

        Enemy.waypoints = enemyWaypoints;
        Portal.portalOffset = enemySpawnSystem.offset;
        Portal.gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        enemySpawnSystem.spawnPos = firstPortalEnter;
    }
}
