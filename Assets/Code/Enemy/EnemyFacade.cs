using UnityEngine;
using Zenject;

namespace Code
{
	public class EnemyFacade : MonoBehaviour 
	{
		
		public class Factory : Factory<EnemyFacade>
		{
			
		}
	}
}
