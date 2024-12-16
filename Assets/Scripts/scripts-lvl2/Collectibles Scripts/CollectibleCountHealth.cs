using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCountHealth : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;

    void Awake()
    {
        text = GameObject.FindWithTag("MushHealth").GetComponent<TMPro.TMP_Text>();
    }

    void OnEnable() => CollectibleHealth.OnCollected += OnCollectibleCollected;
    void OnDisable() => CollectibleHealth.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        text.text = (++count).ToString();
    }

}
