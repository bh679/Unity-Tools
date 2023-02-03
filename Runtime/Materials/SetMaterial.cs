//Writen by Roy @ Equal Reality 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.UnityTools
{
	public class SetMaterial : MonoBehaviour
	{
		public MeshRenderer[] meshRenderers;
		public Material[] materials;
		public Material[] FacilitatorMaterials;
		public UnityIntEvent onMatChange;
		
		bool isFacilitator = false;
		
		public bool onEnable = true;
		
		public int MaterialId {get{return materialId;}}
		int materialId;
		
		void Reset()
		{
			meshRenderers = this.GetComponentsInChildren<MeshRenderer>(true);
		}
		
		void OnEnable()
		{
			if(onEnable)
				SetRandomMaterial();
		}
		
		public void SetMaterialPlz(int x)
		{
			materialId = x;
			
			for(int i = 0; i < meshRenderers.Length; i++)
			{
				if(!isFacilitator)
					meshRenderers[i].material = materials[x % materials.Length];
					
				else
					meshRenderers[i].material = FacilitatorMaterials[x % FacilitatorMaterials.Length];
			}
			
			onMatChange.Invoke(x);
		}
		
		public void SetRandomMaterial()
		{
			//get a random material
			materialId = Random.Range(0, materials.Length);
			
			SetMaterialPlz(materialId);
		}
		
		public void enableFacilitatorMaterial()
		{
			isFacilitator = true;
			SetMaterialPlz(materialId);
		}
		
		public void disableFacilitatorMaterial()
		{
			isFacilitator = false;
			SetMaterialPlz(materialId);
		}
	}
}
