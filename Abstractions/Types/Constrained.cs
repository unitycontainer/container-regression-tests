
namespace Regression
{
    public interface IConstrained<TEntity>
        where TEntity : IService
    {
        TEntity Value { get; }
    }

    public class Constrained<TEntity> : IConstrained<TEntity>
        where TEntity : Service
    {
        public Constrained()
        {
        }

        public Constrained(TEntity value)
        {
            Value = value;
        }

        public TEntity Value { get; }
    }
}


