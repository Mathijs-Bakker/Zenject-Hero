using UnityEngine;

namespace Code
{
	// Spider:
	// IS-A Enemy
	// HAS health
	// HAS-A Collider2D
	// kills player when colliding
	// HAS-A Animating behaviour

		public abstract class Killable : MonoBehaviour
		{
			public abstract void ReceiveDamage(int damage);

			public abstract void Die();
		}
	
	public class SpiderModel : Killable
	{
		
	}
}
