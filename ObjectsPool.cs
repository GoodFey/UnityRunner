using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void CreateObjectsInPools(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawnOne = Instantiate(prefab, _container.transform);
            spawnOne.SetActive(false);
            _pool.Add(spawnOne);
        }
    }
    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result;
    }
}
