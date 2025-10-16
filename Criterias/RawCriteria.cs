
namespace RICH.Persistence.Criterias;

public class RawCriteria<T>(Func<IQueryable<T>, IQueryable<T>> queryConverter) : Criteria<T>
    where T : class, new()
{
    public override IQueryable<T> Evaluate(IQueryable<T> query)
        => queryConverter(query);
}
