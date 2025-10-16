namespace RICH.Persistence.Criterias;

public abstract class CriteriaBuilder<T>
    where T : class, new()
{
    private readonly List<Criteria<T>> _criterias = [];

    protected void With(Func<IQueryable<T>, IQueryable<T>> querySelector)
        => _criterias.Add(Criteria<T>.From(querySelector));

    protected void With(Criteria<T> criteria)
        => _criterias.Add(criteria);

    public Criteria<T> Build() => new CollectionCriteria<T>(_criterias);
}
