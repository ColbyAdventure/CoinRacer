using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelManager : MonoBehaviour
{

    public GameObject[] TireModels;

    public static int currentMeshID;



    private void Awake()
    {
        for (int i = 0; i < TireModels.Length; i++)
        {
            TireModels[i].SetActive(false);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        SelectMesh();
    }

    private void SelectMesh()
    {
        for (int i = 0; i < TireModels.Length; i++)
        {
            TireModels[i].SetActive(i == currentMeshID);
        }

        currentMeshID++;

        if (currentMeshID > (TireModels.Length-1))
        {
            currentMeshID = 0;
        }
    }

}
