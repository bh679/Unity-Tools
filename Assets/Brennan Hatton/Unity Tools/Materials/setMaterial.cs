using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.Utilities

{
	public class setMaterial : MonoBehaviour
	{
		public MeshRenderer[] meshRenderers;
		public Material[] materials;
		public Material[] FacilitatorMaterials;
		
		bool isFacilitator = false;
		
		public bool onEnable = true;
		
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
		
		public void SetMaterial(int x)
		{
			for(int i = 0; i < meshRenderers.Length; i++)
			{
				if(!isFacilitator)
					meshRenderers[i].material = materials[x];
					
				else
					meshRenderers[i].material = FacilitatorMaterials[x];
			}
		}
		
		public void SetRandomMaterial()
		{
			//get a random material
			materialId = Random.Range(0, materials.Length);
			
			SetMaterial(materialId);
		}
		
		public void enableFacilitatorMaterial()
		{
			isFacilitator = true;
			SetMaterial(materialId);
		}
		
		public void disableFacilitatorMaterial()
		{
			isFacilitator = false;
			SetMaterial(materialId);
		}
	}
}