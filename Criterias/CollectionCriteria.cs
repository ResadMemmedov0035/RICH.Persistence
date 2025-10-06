namespace RICH.Persistence.Criterias;

public class CollectionCriteria<T>(IEnumerable<Criteria<T>> criterias) : Criteria<T>
    where T : class, new()
{
    public override IQueryable<T> Evaluate(IQueryable<T> query)
    {
        foreach (var criteria in criterias)
            query = criteria.Evaluate(query);
        return query;
    }
}
