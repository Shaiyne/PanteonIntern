using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] GameObject character;
    float destroyCounter=0f;
    private void Awake()
    {
        Instantiate(character);
        character.gameObject.transform.SetParent(null);
        character.transform.position = new Vector3(0, 0, 0);
    }
    
    void Update()
    {
        destroyCounter += Time.deltaTime;
        if (destroyCounter > 0.7f)
        {
            Destroy(this.gameObject);
        }
    }
}
