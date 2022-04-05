using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadScene(IntegerVariable val)
    {
        StartCoroutine(cLoadScene(val));
    }

    IEnumerator cLoadScene(IntegerVariable val)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(val.value);
    }
}
