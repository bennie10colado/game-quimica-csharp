using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerChemical : MonoBehaviour
{
    public SubstanceManager substanceManager;

    public GameObject[] bottles_compounds;
    public GameObject[] bottles_solvents;

    public GameObject solutionPrefab;
    public Transform solutionParent;

    void Start()
    {
        Debug.Log("Quantidade de compounds: " + substanceManager.compoundsList.Count);
        Debug.Log("Quantidade de solvents: " + substanceManager.solventsList.Count);
        Debug.Log("Quantidade de bottles_compounds: " + bottles_compounds.Length);
        Debug.Log("Quantidade de bottles_solvents: " + bottles_solvents.Length);


        for (int i = 0; i < Mathf.Min(bottles_compounds.Length, substanceManager.compoundsList.Count); i++)
        {
            BottleObjectCompound bottleComp = bottles_compounds[i].GetComponent<BottleObjectCompound>();
            if (bottleComp != null)
            {
                Debug.Log("Configurando BottleObjectCompound com " + substanceManager.compoundsList[i].GetCompoundName());
                bottleComp.ConfigureCompound(substanceManager.compoundsList[i]);
                Debug.Log(bottleComp.GetInfo());
            }
        }

        for (int i = 0; i < Mathf.Min(bottles_solvents.Length, substanceManager.solventsList.Count); i++)
        {
            BottleObjectSolvent bottleSol = bottles_solvents[i].GetComponent<BottleObjectSolvent>();
            if (bottleSol != null)
            {
                //Debug.Log("Configurando BottleObjectSolvent com " + substanceManager.solventsList[i].GetCompoundName());
                bottleSol.ConfigureSolvent(substanceManager.solventsList[i]);
                //Debug.Log(bottleSol.GetInfo());
            }
        }

        float offsetX = 0.7f;

        for (int i = 0; i < substanceManager.solutionsList.Count; i++)
        {
            Vector3 positionOffset = new Vector3(i * offsetX, 0, 0); 
            GameObject newSolutionObject = Instantiate(solutionPrefab, solutionParent.position + positionOffset, Quaternion.identity, solutionParent);
            //Debug.Log("Instantiating solution object " + i);

            if (newSolutionObject != null)
            {
                //Debug.Log("Solution object " + i + " instantiated");
                BottleSolutionObject solutionObject = newSolutionObject.GetComponent<BottleSolutionObject>();
                if (solutionObject)
                {
                    //Debug.Log("Configuring solution object " + i);
                    solutionObject.ConfigureSolution(substanceManager.solutionsList[i]);
                    //Debug.Log(solutionObject.GetInfo());
                }
                else
                {
                    Debug.Log("Solution object " + i + " does not have BottleSolutionObject component");
                }
            }
            else
            {
                Debug.Log("Solution object " + i + " instantiation failed");
            }
        }

    }
}
