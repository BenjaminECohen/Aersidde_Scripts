using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTrigger : MonoBehaviour
{
    public List<ParticleSystem> pSystems;
    public List<Light> lights;
    public float yOverride = -1f;
    public bool activated = false;

    void Start()
    {
        
    }

    public void Activate()
    {
        foreach(ParticleSystem p in pSystems)
        {
            p.Play();
        }
        foreach(Light l in lights)
        {
            l.enabled = true;
        }
        activated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (pSystems[0].isStopped)
        {
            foreach(Light l in lights)
            {
                l.enabled = false;
            }
        }

        bool destroy = true;

        foreach (ParticleSystem p in pSystems)
        {
            if (!p.isStopped)
            {
                destroy = false;
                break;
            }
        }
        if (destroy && activated)
        {
            Destroy(this.gameObject);
        }
    }
}
