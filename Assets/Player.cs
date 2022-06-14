using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public Text text;
	public ParticleSystem particles;
	private List<GameObject> hitList;

	int hits;

	// Start is called before the first frame update
	void Start()
	{
		hitList = new List<GameObject>();
		hits = 0;
	}

	public void Hit()
	{

		if(hitList.Count > 0)
		{
			hits++;
			text.text = hits.ToString();
			particles.Play();
			Destroy(hitList[0]);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "HitObject")
		{
			hitList.Add(col.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "HitObject")
		{
			hitList.RemoveAt(0);
		}
	}
}
