using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerTwo : MonoBehaviour
{
    [SerializeField] private GameObject waterObject; //utilizado
    [SerializeField] private GameObject eterObject; //utilizado
    
	[SerializeField] private GameObject etanoatoObject; //utilizado
    [SerializeField] private GameObject propanoicAcidObject;
    [SerializeField] private GameObject butanaminaObject;
    [SerializeField] private GameObject butanoatoSodiumObject; //utilizado
   
	private SubstanceSolvent distilledWater;
    private SubstanceSolvent eterDietilico;

    private SubstanceCompound etanoato;
    private SubstanceCompound propanoicAcid;
    private SubstanceCompound butanamina;
	private SubstanceCompound butanoatoSodium;

    private void Start()
    {
        distilledWater = waterObject.GetComponent<SubstanceSolvent>();
        eterDietilico = eterObject.GetComponent<SubstanceSolvent>();

        etanoato = etanoatoObject.GetComponent<SubstanceCompound>();
		butanoatoSodium = butanoatoSodiumObject.GetComponent<SubstanceCompound>();

        if (distilledWater == null || etanoato == null || butanoatoSodium == null || eterDietilico == null)
        {
            Debug.LogError("Componente não encontrado em algum dos objetos!");
            return;
        }

	    //marcando solubilidadade dos solventes com os compostos organicos
        distilledWater.SetSolubility(etanoato, true);
        distilledWater.SetSolubility(butanoatoSodium, true);

		eterDietilico.SetSolubility(etanoato, true);
		eterDietilico.SetSolubility(butanoatoSodium, false);

		//reacao entre o composto e solvente
        Reaction reaction_between_water_etanoato = new Reaction(etanoato, distilledWater);
        SubstanceCompound reactionProduct = reaction_between_water_etanoato.PerformReaction();

        Reaction reaction_between_eter_butanoatoSodium = new Reaction(butanoatoSodium, eterDietilico);
        SubstanceCompound reactionProduct2 = reaction_between_eter_butanoatoSodium.PerformReaction();

        //reactionProduct != null não funcionava, e por algum motivo mesmo o objeto totalmente preenchido com seus valores, ele entrava no if de == null
        if (reactionProduct.GetCompoundName() != null && reactionProduct2.GetCompoundName() != null)
        {
		Debug.Log("Produto da reação 1: " + reactionProduct.GetCompoundName());
		Debug.Log("Produto da reação 2: " + reactionProduct2.GetCompoundName());
		}else if (reactionProduct == null){
   		Debug.Log("Reação não ocorreu");
		}
    }
}
