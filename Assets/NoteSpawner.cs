using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NoteSpawner : MonoBehaviour
{
    public float AR;
    public float BPM;
	public GameObject hitObject;

    public TextAsset text;

    public AudioSource song;

    List<int[]> beats;

	float startTime;
    int beat;

    // Start is called before the first frame update
    void Start()
    {
        beats = new List<int[]>();

        string[] lines = text.text.Split(new char[]{'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        foreach(string line in lines)
        {
            string[] fields = line.Split(',');
            beats.Add(new int[]{int.Parse(fields[0]), int.Parse(fields[1])});
        }
        
        BPM *= 4;
        beat = beats[0][0];
		song.Play();
    }

    void FixedUpdate()
    {
        if(beats.Count > 0)
        {
            if(song.time + 0.2f >= (((float)beat * 60 / BPM) - AR))
            {
                Instantiate(hitObject, Vector3.zero, Quaternion.identity);

                beats.RemoveAt(0);
                
                if(beats.Count > 0)
                {
                    beat = beats[0][0];
                }
            }
        }
    }
}
