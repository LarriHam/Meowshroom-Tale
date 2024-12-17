using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCountDMG : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;

    void Awake()
    {
        text = GameObject.FindWithTag("MushDMG").GetComponent<TMPro.TMP_Text>();
    }

    void OnEnable() => CollectibleDMG.OnCollected += OnCollectibleCollected;
    void OnDisable() => CollectibleDMG.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        text.text = (++count).ToString();
    }

    public void OnCollectibleUsed()
    {
        text.text = (--count).ToString();
    }

    public int CollectibleCount()
    {
        return count;
    }

}
