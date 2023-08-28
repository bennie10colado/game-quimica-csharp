using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerTwo : MonoBehaviour
{
    [SerializeField] private GameObject waterObject;
    [SerializeField] private GameObject eterObject;

    [SerializeField] private GameObject etanoatoObject;
    [SerializeField] private GameObject propanoicAcidObject;
    [SerializeField] private GameObject butanaminaObject;

    private SubstanceSolvent distilledWater;
    private SubstanceSolvent eterDietilico;

    private SubstanceCompound etanoato;
    private SubstanceCompound propanoicAcid;
    private SubstanceCompound butanamina;

    private void Start()
    {
        distilledWater = waterObject.GetComponent<SubstanceSolvent>();
        eterDietilico = eterObject.GetComponent<SubstanceSolvent>();

        if (distilledWater == null || eterDietilico == null)
        {
            Debug.LogError("Componente de 'SubstanceSolvent' não foi encontrado em algum dos objetos!");
            return;
        }

        etanoato = etanoatoObject.GetComponent<SubstanceCompound>();
        propanoicAcid = propanoicAcidObject.GetComponent<SubstanceCompound>();
        butanamina = butanaminaObject.GetComponent<SubstanceCompound>();


		if (etanoato == null || propanoicAcid == null || butanamina == null)
        {
            Debug.LogError("Componente de 'SubstanceCompound' não encontrado em algum dos objetos!");
            return;
        }

        distilledWater.SetSolubility(etanoato, true);
        distilledWater.SetSolubility(propanoicAcid, true);
        distilledWater.SetSolubility(butanamina, true);

        eterDietilico.SetSolubility(etanoato, true);
        eterDietilico.SetSolubility(propanoicAcid, true);
        eterDietilico.SetSolubility(butanamina, true);

        bool isEtanoatoSolubleInWater = distilledWater.IsSoluble(etanoato);
        bool isPropanoicAcidSolubleInWater = distilledWater.IsSoluble(propanoicAcid);
        bool isButanaminaSolubleInWater = distilledWater.IsSoluble(butanamina);

        bool isEtanoatoSolubleInEter = eterDietilico.IsSoluble(etanoato);
        bool isPropanoicAcidSolubleInEter = eterDietilico.IsSoluble(propanoicAcid);
        bool isButanaminaSolubleInEter = eterDietilico.IsSoluble(butanamina);

        Debug.Log("Etanoato é solúvel em água: " + isEtanoatoSolubleInWater);
        Debug.Log("Ácido propanoico é solúvel em água: " + isPropanoicAcidSolubleInWater);
        Debug.Log("Butan-1-amina é solúvel em água: " + isButanaminaSolubleInWater);

        Debug.Log("Etanoato é solúvel em éter: " + isEtanoatoSolubleInEter);
        Debug.Log("Ácido propanoico é solúvel em éter: " + isPropanoicAcidSolubleInEter);
        Debug.Log("Butan-1-amina é solúvel em éter: " + isButanaminaSolubleInEter);
    }
}
