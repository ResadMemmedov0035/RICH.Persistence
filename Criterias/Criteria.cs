﻿namespace RICH.Persistence.Criterias;

public abstract class Criteria<T>
    where T : class, new()
{
    public abstract IQueryable<T> Evaluate(IQueryable<T> query);

    public static CollectionCriteria<T> Collect(params Criteria<T>[] criterias)
        => new(criterias);
}
