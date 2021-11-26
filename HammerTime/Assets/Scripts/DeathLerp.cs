using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLerp : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private int zoomInDuration;

    private Vector3 offset;

    public bool tempbool;
    private void Update()
    {
        if (tempbool)
        {
            StartCoroutine(OnDeathLerpPlayer());
            tempbool = false;
        }
    }
    private IEnumerator OnDeathLerpPlayer()
    {
        float elapsed = 0;
        while (elapsed < zoomInDuration)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, Player.transform.position + offset, elapsed / zoomInDuration);
            yield return null;
        }
    }
}
