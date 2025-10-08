using System;
using System.Collections.Generic;
using UnityEngine;

public class ClothSwitchControl : MonoBehaviour
{
    [Serializable]
    public class ClothData
    { 
        public ClothType type;
        public GameObject clothMesh;
    }

    [SerializeField] public List<ClothData> clothDataList;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Cloth cloth))
        {
            foreach (var clothData in clothDataList)
            {
                if (clothData.type == cloth.type)
                {
                    clothData.clothMesh.SetActive(true);
                    cloth.DestroySelf();
                    return;
                }
            }
        }
    }
}
