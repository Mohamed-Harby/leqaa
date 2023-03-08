using BusinessLogic.Domain;
using ErrorOr;

namespace BusinessLogic.Application.Extensions;
public static class ValidationExtensions
{
    public static ErrorOr<TEntity> Ensure<TEntity>(this TEntity entity, Func<TEntity, bool> predicate, Error error)
    where TEntity : BaseEntity
    {
        if (!predicate(entity))
        {
            return error;
        }
        return (TEntity)entity;
    }
}