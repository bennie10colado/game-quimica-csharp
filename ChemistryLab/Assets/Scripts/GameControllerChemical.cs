using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameControllerChemical : MonoBehaviour
{
    public SubstanceManager substanceManager;

    public GameObject[] bottles_compounds;
    public GameObject[] bottles_solvents;

    public GameObject solutionPrefab;
    public Transform solutionParent;

    private SubstanceSolvent lastSelectedSolvent;
    private SubstanceCompound lastSelectedCompound;

    private int currentSolutionCount = 0;

    void Start()
    {
        Debug.Log("Quantidade de compounds: " + substanceManager.compoundsList.Count);
        Debug.Log("Quantidade de solvents: " + substanceManager.solventsList.Count);
        Debug.Log("Quantidade de bottles_compounds: " + bottles_compounds.Length);
        Debug.Log("Quantidade de bottles_solvents: " + bottles_solvents.Length);

        ConfiguratingCompoundBottlesInGUI();
        ConfiguratingSolventBottlesInGUI();

        //InstantiateSolutionsBottlesInGUI();
        //DebugSolutionsList();
    }

    void ConfiguratingCompoundBottlesInGUI()
    {

        for (int i = 0; i < Mathf.Min(bottles_compounds.Length, substanceManager.compoundsList.Count); i++)
        {
            BottleObjectCompound bottleComp = bottles_compounds[i].GetComponent<BottleObjectCompound>();
            if (bottleComp != null)
            {
                //Debug.Log("Configurando BottleObjectCompound com " + substanceManager.compoundsList[i].GetCompoundName());
                bottleComp.ConfigureCompound(substanceManager.compoundsList[i]);
                Debug.Log(bottleComp.GetInfo());
            }
        }
    }

    void ConfiguratingSolventBottlesInGUI()
    {
        for (int i = 0; i < Mathf.Min(bottles_solvents.Length, substanceManager.solventsList.Count); i++)
        {
            BottleObjectSolvent bottleSol = bottles_solvents[i].GetComponent<BottleObjectSolvent>();
            if (bottleSol != null)
            {
                //Debug.Log("Configurando BottleObjectSolvent com " + substanceManager.solventsList[i].GetCompoundName());
                bottleSol.ConfigureSolvent(substanceManager.solventsList[i]);
                Debug.Log(bottleSol.GetInfo());
            }
        }
    }
    void InstantiateAllSolutionsBottlesInGUI()
    {
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
                    Debug.Log(solutionObject.GetInfo());
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

    void InstantiateSolutionBottleInGUI(SubstanceSolution solution)
    {
        float offsetX = 0.7f;

        Vector3 positionOffset = new Vector3(currentSolutionCount * offsetX, 0, 0);
        GameObject newSolutionObject = Instantiate(solutionPrefab, solutionParent.position + positionOffset, Quaternion.identity, solutionParent);

        if (newSolutionObject != null)
        {
            BottleSolutionObject solutionObject = newSolutionObject.GetComponent<BottleSolutionObject>();
            if (solutionObject)
            {
                solutionObject.ConfigureSolution(solution);
                Debug.Log(solutionObject.GetInfo());
            }
            else
            {
                Debug.Log("Solution object does not have BottleSolutionObject component");
            }
            currentSolutionCount++;

        }
        else
        {
            Debug.Log("Solution object instantiation failed");
        }
    }


    private void DebugSolutionsList()
    {
        if (substanceManager && substanceManager.solutionsList != null)
        {
            foreach (var solution in substanceManager.solutionsList)
            {
                Debug.Log($"Solution: {solution.GetSolutionName()} - SolventId: {solution.GetSolventId()} - CompoundId: {solution.GetCompoundId()}");
            }
        }
        else
        {
            Debug.LogError("SubstanceManager ou solutionsList é null.");
        }
    }

    public void PerformReaction(int solventId, int compoundId)
    {
        SubstanceSolution result = FindReactionResult(solventId, compoundId);
        if (result?.GetSolutionName() != null)
        {
            Debug.Log("Reação realizada: " + result.GetSolutionName() + " E seu resultado de solubilidade é: " + result.GetSolubilityResult());

            //outras logicas p mistura

            InstantiateSolutionBottleInGUI(result);
        }
        else
        {
            Debug.Log("Reação não encontrada para solventeId: " + solventId + " e compoundId: " + compoundId);
        }
    }


    private SubstanceSolution FindReactionResult(int solventId, int compoundId)
    {
        foreach (SubstanceSolution solution in substanceManager.solutionsList)
        {
            if (solution.GetSolventId() == solventId && solution.GetCompoundId() == compoundId)
            {
                return solution;
            }
        }
        return null;
    }


}
