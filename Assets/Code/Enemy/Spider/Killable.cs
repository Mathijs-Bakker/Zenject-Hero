namespace Code
{
    public abstract class Killable
    {
        public abstract void ReceiveDamage(int damage);

        public abstract void Die();
    }
}