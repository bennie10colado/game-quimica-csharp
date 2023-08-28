using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerTwo : MonoBehaviour
{
    [SerializeField] private GameObject waterObject;
    [SerializeField] private GameObject etanoatoObject;

    private SubstanceSolvent aguaDestilada;
    private SubstanceCompound etanoato;

    private void Start()
    {
        aguaDestilada = waterObject.GetComponent<SubstanceSolvent>();

        if (aguaDestilada == null)
        {
            Debug.LogError("Componente SubstanceSolvent não encontrado no objeto da água destilada!");
        }

        etanoato = etanoatoObject.GetComponent<SubstanceCompound>();

        if (etanoato == null)
        {
            Debug.LogError("Componente SubstanceCompound não encontrado no objeto do etanoato!");
        }

        aguaDestilada.SetSolubility(etanoato, true);

        bool isEtanoatoSoluble = aguaDestilada.IsSoluble(etanoato);

        if (isEtanoatoSoluble)
        {
            Debug.Log("O etanoato é solúvel na água.");
        }
        else
        {
            Debug.Log("O etanoato não é solúvel na água.");
        }
    }
}
