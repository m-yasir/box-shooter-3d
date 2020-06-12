using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnGameObjectsCustom : MonoBehaviour {

	public float delayInSeconds = 1.0f;
	public GameObject spawnPrefab;
	public int maxSpawnCount = 0;
	public int initialDelayInSeconds = 0;
	public Transform chaseTarget;

	private List<GameObject> spawnList = new List<GameObject>();
	private float timer = 1.0f;	
	// Use this for initialization
	void Start () {
		if (delayInSeconds < 0) {
			delayInSeconds = 1;
		}
		timer = Mathf.Max(initialDelayInSeconds, delayInSeconds);
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnList.Count >= maxSpawnCount) return;
		
		timer = Mathf.Max(timer- Time.deltaTime, 0f);
		if (timer == 0) // is it time and is there vacancy to spawn again?
		{
			timer = delayInSeconds;
			MakeThingToSpawn();
		}
	}

	void LateUpdate()
     	{
          	spawnList.RemoveAll( o => (o == null || o.Equals(null)) );
     	}

	void MakeThingToSpawn()
	{
		// create a new gameObject
		GameObject clone = Instantiate(spawnPrefab, transform.position, transform.rotation) as GameObject;
		spawnList.Add(clone);
		// set chaseTarget if specified
		if ((chaseTarget != null) && (clone.gameObject.GetComponent<Chaser> () != null))
		{
			clone.gameObject.GetComponent<Chaser>().SetTarget(chaseTarget);
		}
	}
}
