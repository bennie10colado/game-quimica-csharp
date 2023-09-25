using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction
{
    private SubstanceCompound compound;
    private SubstanceSolvent solvent;

    public Reaction(SubstanceCompound compound, SubstanceSolvent solvent)
    {
        this.compound = compound;
        this.solvent = solvent;
    }

    public SubstanceCompound PerformReaction()
    {
        Debug.Log("Iniciando reação...\nReagentes: ");
        Debug.Log("-> Composto Orgânico: " + compound.GetCompoundName());
        Debug.Log("-> Solvente: " + solvent.GetCompoundName());

        //if (!solvent.IsSoluble(compound))
        //{
        //    Debug.Log("Composto e solvente não são solúveis entre si!"); 
		//	DensitySolution(compound, solvent);//se nao for soluvel, calcula a diferença de fases
        //}else{
        //Debug.Log("Composto e solvente são solúveis!");
		//}
		
		//produto resultado predefinido que será retornado, e posteriormente pode se tornar um gameobject instanciado no cenario	
        SubstanceCompound reactionProduct = new SubstanceCompound(1, compound.GetCompoundName(), Color.white, PhysicalState.LIQUID, 0.8f, GroupName.S1);
        
        //Debug.Log("Reação ocorreu, composto e solvente são solúveis! Produto da reação é o: " + reactionProduct.GetCompoundName());

		//uma verificacao melhor invés de null, é verificar o SolubilityResults e se o valor está dentro do conjunto solucao do enum, deve ser mais leve computacionalmente
		
		//bool density = DensitySolution(compound, solvent);
		if(reactionProduct.GetCompoundName() != null) 
		{	
	        Debug.Log("Reação ocorreu! Produto da reação é o: " + reactionProduct.GetCompoundName());
			//necessario fazer uma verificacao para os dados referentes ao SolubilityResults do objeto retornado
        	return reactionProduct;
		} 
		else 
		{
			return null; 
		}
    }

	private bool DensitySolution(SubstanceCompound compound, SubstanceSolvent solvent)
	{
    	float compoundDensity = compound.GetDensity();
    	float solventDensity = solvent.GetDensity();

    	if (compoundDensity > solventDensity)
    	{
        	Debug.Log(compound.GetCompoundName() + " ficará acima do solvente");
    	}
    	else
    	{
        	Debug.Log(compound.GetCompoundName() + " ficará abaixo do solvente");
    	}

    	return compoundDensity > solventDensity; 
		//se a densidade do composto for maior do que a densidade do solvente, retorna true, 
		//e este ficará em "I↓ - insolúvel/fase mais densa"
		//caso contrário retorna false e "I↑ - insolúvel/fase menos densa"
	}
	
}
