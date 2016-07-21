using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MediaDatabase.Database
{
    public static class QueryableExtensions
    {
        //
        // Summary:
        //     Asynchronously determines whether all the elements of a sequence satisfy a condition.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 whose elements to test for a condition.
        //
        //   predicate:
        //     A function to test each element for a condition.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains true
        //     if every element of the source sequence passes the test in the specified predicate;
        //     otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or predicate is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<bool> AllAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
        {
            return System.Data.Entity.QueryableExtensions.AllAsync(source, predicate);
        }

        //
        // Summary:
        //     Asynchronously determines whether all the elements of a sequence satisfy a condition.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 whose elements to test for a condition.
        //
        //   predicate:
        //     A function to test each element for a condition.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains true
        //     if every element of the source sequence passes the test in the specified predicate;
        //     otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or predicate is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<bool> AllAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AllAsync(source, predicate, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously determines whether a sequence contains any elements.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to check for being empty.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains true
        //     if the source sequence contains any elements; otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<bool> AnyAsync<TSource>(this IQueryable<TSource> source)
        {
            return System.Data.Entity.QueryableExtensions.AnyAsync(source);
        }

        //
        // Summary:
        //     Asynchronously determines whether any element of a sequence satisfies a condition.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 whose elements to test for a condition.
        //
        //   predicate:
        //     A function to test each element for a condition.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains true
        //     if any elements in the source sequence pass the test in the specified predicate;
        //     otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or predicate is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<bool> AnyAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
        {
            return System.Data.Entity.QueryableExtensions.AnyAsync(source, predicate);
        }

        //
        // Summary:
        //     Asynchronously determines whether a sequence contains any elements.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to check for being empty.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains true
        //     if the source sequence contains any elements; otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<bool> AnyAsync<TSource>(this IQueryable<TSource> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AnyAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously determines whether any element of a sequence satisfies a condition.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 whose elements to test for a condition.
        //
        //   predicate:
        //     A function to test each element for a condition.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains true
        //     if any elements in the source sequence pass the test in the specified predicate;
        //     otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or predicate is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<bool> AnyAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AnyAsync(source, predicate, cancellationToken);
        }

        //
        // Summary:
        //     Returns a new query where the entities returned will not be cached in the System.Data.Entity.DbContext
        //     or System.Data.Entity.Core.Objects.ObjectContext. This method works by calling
        //     the AsNoTracking method of the underlying query object. If the underlying query
        //     object does not have an AsNoTracking method, then calling this method will have
        //     no affect.
        //
        // Parameters:
        //   source:
        //     The source query.
        //
        // Returns:
        //     A new query with NoTracking applied, or the source query if NoTracking is not
        //     supported.
        public static IQueryable AsNoTracking(this IQueryable source)
        {
            return System.Data.Entity.QueryableExtensions.AsNoTracking(source);
        }

        //
        // Summary:
        //     Returns a new query where the entities returned will not be cached in the System.Data.Entity.DbContext
        //     or System.Data.Entity.Core.Objects.ObjectContext. This method works by calling
        //     the AsNoTracking method of the underlying query object. If the underlying query
        //     object does not have an AsNoTracking method, then calling this method will have
        //     no affect.
        //
        // Parameters:
        //   source:
        //     The source query.
        //
        // Type parameters:
        //   T:
        //     The element type.
        //
        // Returns:
        //     A new query with NoTracking applied, or the source query if NoTracking is not
        //     supported.
        public static IQueryable<T> AsNoTracking<T>(this IQueryable<T> source) where T : class
        {
            return System.Data.Entity.QueryableExtensions.AsNoTracking(source);
        }

        //
        // Summary:
        //     Returns a new query that will stream the results instead of buffering. This method
        //     works by calling the AsStreaming method of the underlying query object. If the
        //     underlying query object does not have an AsStreaming method, then calling this
        //     method will have no affect.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable to apply AsStreaming to.
        //
        // Returns:
        //     A new query with AsStreaming applied, or the source query if AsStreaming is not
        //     supported.
        [Obsolete("LINQ queries are now streaming by default unless a retrying ExecutionStrategy is used. Calling this method will have no effect.")]
        public static IQueryable AsStreaming(this IQueryable source)
        {
            return System.Data.Entity.QueryableExtensions.AsStreaming(source);
        }

        //
        // Summary:
        //     Returns a new query that will stream the results instead of buffering. This method
        //     works by calling the AsStreaming method of the underlying query object. If the
        //     underlying query object does not have an AsStreaming method, then calling this
        //     method will have no affect.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to apply AsStreaming to.
        //
        // Type parameters:
        //   T:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A new query with AsStreaming applied, or the source query if AsStreaming is not
        //     supported.
        [Obsolete("LINQ queries are now streaming by default unless a retrying ExecutionStrategy is used. Calling this method will have no effect.")]
        public static IQueryable<T> AsStreaming<T>(this IQueryable<T> source)
        {
            return System.Data.Entity.QueryableExtensions.AsStreaming(source);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int64 values to calculate the average of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double?> AverageAsync(this IQueryable<long?> source)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Single values to calculate the average of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<float> AverageAsync(this IQueryable<float> source)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Double values to calculate the average of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<double> AverageAsync(this IQueryable<double> source)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Double values to calculate the average of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double?> AverageAsync(this IQueryable<double?> source)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Decimal values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Decimal values to calculate the average of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<decimal> AverageAsync(this IQueryable<decimal> source)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Decimal
        //     values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Decimal values to calculate the average of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<decimal?> AverageAsync(this IQueryable<decimal?> source)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int64 values to calculate the average of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<double> AverageAsync(this IQueryable<long> source)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int32 values to calculate the average of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double?> AverageAsync(this IQueryable<int?> source)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Single values to calculate the average of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<float?> AverageAsync(this IQueryable<float?> source)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int32 values to calculate the average of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<double> AverageAsync(this IQueryable<int> source)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Decimal
        //     values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Decimal values to calculate the average of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<decimal?> AverageAsync(this IQueryable<decimal?> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int32 values to calculate the average of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double?> AverageAsync(this IQueryable<int?> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Single values to calculate the average of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<float> AverageAsync(this IQueryable<float> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Single values to calculate the average of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<float?> AverageAsync(this IQueryable<float?> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Double values to calculate the average of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double?> AverageAsync(this IQueryable<double?> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Decimal values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Decimal values to calculate the average of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<decimal> AverageAsync(this IQueryable<decimal> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int64 values to calculate the average of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<double> AverageAsync(this IQueryable<long> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int64 values to calculate the average of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double?> AverageAsync(this IQueryable<long?> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int32 values to calculate the average of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<double> AverageAsync(this IQueryable<int> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Double values to calculate the average of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<double> AverageAsync(this IQueryable<double> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Int32 values that
        //     is obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, int>> selector)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Single values that
        //     is obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<float> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, float>> selector)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Int32 values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double?> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, int?>> selector)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Int64 values that
        //     is obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, long>> selector)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Single values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<float?> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, float?>> selector)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Decimal
        //     values that is obtained by invoking a projection function on each element of
        //     the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<decimal?> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal?>> selector)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Decimal values that
        //     is obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<decimal> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal>> selector)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Double values that
        //     is obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, double>> selector)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Int64 values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double?> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, long?>> selector)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Double values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double?> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, double?>> selector)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Double values that
        //     is obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, double>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Decimal
        //     values that is obtained by invoking a projection function on each element of
        //     the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<decimal?> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal?>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Int32 values that
        //     is obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, int>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Int32 values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static Task<double?> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, int?>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Decimal values that
        //     is obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<decimal> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Double values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static Task<double?> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, double?>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Int64 values that
        //     is obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static Task<double> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, long>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Single values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<float?> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, float?>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of System.Single values that
        //     is obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source contains no elements.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<float> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, float>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the average of a sequence of nullable System.Int64 values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values to calculate the average of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     average of the sequence of values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double?> AverageAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, long?>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.AverageAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously determines whether a sequence contains a specified element by
        //     using the default equality comparer.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the single element of.
        //
        //   item:
        //     The object to locate in the sequence.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains true
        //     if the input sequence contains the specified value; otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<bool> ContainsAsync<TSource>(this IQueryable<TSource> source, TSource item)
        {
            return System.Data.Entity.QueryableExtensions.ContainsAsync(source, item);
        }

        //
        // Summary:
        //     Asynchronously determines whether a sequence contains a specified element by
        //     using the default equality comparer.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the single element of.
        //
        //   item:
        //     The object to locate in the sequence.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains true
        //     if the input sequence contains the specified value; otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<bool> ContainsAsync<TSource>(this IQueryable<TSource> source, TSource item, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.ContainsAsync(source, item, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously returns the number of elements in a sequence.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 that contains the elements to be counted.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     number of elements in the input sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int32.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<int> CountAsync<TSource>(this IQueryable<TSource> source)
        {
            return System.Data.Entity.QueryableExtensions.CountAsync(source);
        }

        //
        // Summary:
        //     Asynchronously returns the number of elements in a sequence.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 that contains the elements to be counted.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     number of elements in the input sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int32.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<int> CountAsync<TSource>(this IQueryable<TSource> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.CountAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously returns the number of elements in a sequence that satisfy a condition.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 that contains the elements to be counted.
        //
        //   predicate:
        //     A function to test each element for a condition.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     number of elements in the sequence that satisfy the condition in the predicate
        //     function.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or predicate is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source that satisfy the condition in the predicate
        //     function is larger than System.Int32.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<int> CountAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
        {
            return System.Data.Entity.QueryableExtensions.CountAsync(source, predicate);
        }

        //
        // Summary:
        //     Asynchronously returns the number of elements in a sequence that satisfy a condition.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 that contains the elements to be counted.
        //
        //   predicate:
        //     A function to test each element for a condition.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     number of elements in the sequence that satisfy the condition in the predicate
        //     function.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or predicate is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source that satisfy the condition in the predicate
        //     function is larger than System.Int32.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<int> CountAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.CountAsync(source, predicate, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously returns the first element of a sequence.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the first element of.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     first element in System.Data.Entity.QueryableExtensions.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null.
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider.
        //
        //   T:System.InvalidOperationException:
        //     The source sequence is empty.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<TSource> FirstAsync<TSource>(this IQueryable<TSource> source)
        {
            return System.Data.Entity.QueryableExtensions.FirstAsync(source);
        }

        //
        // Summary:
        //     Asynchronously returns the first element of a sequence.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the first element of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     first element in System.Data.Entity.QueryableExtensions.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     The source sequence is empty.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<TSource> FirstAsync<TSource>(this IQueryable<TSource> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.FirstAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously returns the first element of a sequence that satisfies a specified
        //     condition.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the first element of.
        //
        //   predicate:
        //     A function to test each element for a condition.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     first element in source that passes the test in predicate.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or predicate is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     No element satisfies the condition in predicate .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<TSource> FirstAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
        {
            return System.Data.Entity.QueryableExtensions.FirstAsync(source, predicate);
        }

        //
        // Summary:
        //     Asynchronously returns the first element of a sequence that satisfies a specified
        //     condition.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the first element of.
        //
        //   predicate:
        //     A function to test each element for a condition.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     first element in source that passes the test in predicate.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or predicate is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     No element satisfies the condition in predicate .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<TSource> FirstAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.FirstAsync(source, predicate, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously returns the first element of a sequence, or a default value if
        //     the sequence contains no elements.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the first element of.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains default
        //     ( TSource ) if source is empty; otherwise, the first element in System.Data.Entity.QueryableExtensions.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<TSource> FirstOrDefaultAsync<TSource>(this IQueryable<TSource> source)
        {
            return System.Data.Entity.QueryableExtensions.FirstOrDefaultAsync(source);
        }

        //
        // Summary:
        //     Asynchronously returns the first element of a sequence, or a default value if
        //     the sequence contains no elements.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the first element of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains default
        //     ( TSource ) if source is empty; otherwise, the first element in System.Data.Entity.QueryableExtensions.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<TSource> FirstOrDefaultAsync<TSource>(this IQueryable<TSource> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.FirstOrDefaultAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously returns the first element of a sequence that satisfies a specified
        //     condition or a default value if no such element is found.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the first element of.
        //
        //   predicate:
        //     A function to test each element for a condition.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains default
        //     ( TSource ) if source is empty or if no element passes the test specified by
        //     predicate ; otherwise, the first element in source that passes the test specified
        //     by predicate.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or predicate is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<TSource> FirstOrDefaultAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
        {
            return System.Data.Entity.QueryableExtensions.FirstOrDefaultAsync(source, predicate);
        }

        //
        // Summary:
        //     Asynchronously returns the first element of a sequence that satisfies a specified
        //     condition or a default value if no such element is found.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the first element of.
        //
        //   predicate:
        //     A function to test each element for a condition.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains default
        //     ( TSource ) if source is empty or if no element passes the test specified by
        //     predicate ; otherwise, the first element in source that passes the test specified
        //     by predicate.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or predicate is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source has more than one element.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<TSource> FirstOrDefaultAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.FirstOrDefaultAsync(source, predicate, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously enumerates the query results and performs the specified action
        //     on each element.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable to enumerate.
        //
        //   action:
        //     The action to perform on each element.
        //
        // Returns:
        //     A task that represents the asynchronous operation.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task ForEachAsync(this IQueryable source, Action<object> action)
        {
            return System.Data.Entity.QueryableExtensions.ForEachAsync(source, action);
        }

        //
        // Summary:
        //     Asynchronously enumerates the query results and performs the specified action
        //     on each element.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable to enumerate.
        //
        //   action:
        //     The action to perform on each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task ForEachAsync(this IQueryable source, Action<object> action, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.ForEachAsync(source, action, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously enumerates the query results and performs the specified action
        //     on each element.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to enumerate.
        //
        //   action:
        //     The action to perform on each element.
        //
        // Type parameters:
        //   T:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task ForEachAsync<T>(this IQueryable<T> source, Action<T> action)
        {
            return System.Data.Entity.QueryableExtensions.ForEachAsync(source, action);
        }

        //
        // Summary:
        //     Asynchronously enumerates the query results and performs the specified action
        //     on each element.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to enumerate.
        //
        //   action:
        //     The action to perform on each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   T:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task ForEachAsync<T>(this IQueryable<T> source, Action<T> action, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.ForEachAsync(source, action, cancellationToken);
        }

        //
        // Summary:
        //     Specifies the related objects to include in the query results.
        //
        // Parameters:
        //   source:
        //     The source System.Linq.IQueryable on which to call Include.
        //
        //   path:
        //     The dot-separated list of related objects to return in the query results.
        //
        // Returns:
        //     A new System.Linq.IQueryable with the defined query path.
        //
        // Remarks:
        //     This extension method calls the Include(String) method of the source System.Linq.IQueryable
        //     object, if such a method exists. If the source System.Linq.IQueryable does not
        //     have a matching method, then this method does nothing. The System.Data.Entity.Core.Objects.ObjectQuery,
        //     System.Data.Entity.Core.Objects.ObjectSet`1, System.Data.Entity.Infrastructure.DbQuery
        //     and System.Data.Entity.DbSet types all have an appropriate Include method to
        //     call. Paths are all-inclusive. For example, if an include call indicates Include("Orders.OrderLines"),
        //     not only will OrderLines be included, but also Orders. When you call the Include
        //     method, the query path is only valid on the returned instance of the System.Linq.IQueryable.
        //     Other instances of System.Linq.IQueryable and the object context itself are not
        //     affected. Because the Include method returns the query object, you can call this
        //     method multiple times on an System.Linq.IQueryable to specify multiple paths
        //     for the query.
        public static IQueryable Include(this IQueryable source, string path)
        {
            return System.Data.Entity.QueryableExtensions.Include(source, path);
        }

        //
        // Summary:
        //     Specifies the related objects to include in the query results.
        //
        // Parameters:
        //   source:
        //     The source System.Linq.IQueryable`1 on which to call Include.
        //
        //   path:
        //     The dot-separated list of related objects to return in the query results.
        //
        // Type parameters:
        //   T:
        //     The type of entity being queried.
        //
        // Returns:
        //     A new System.Linq.IQueryable`1 with the defined query path.
        //
        // Remarks:
        //     This extension method calls the Include(String) method of the source System.Linq.IQueryable`1
        //     object, if such a method exists. If the source System.Linq.IQueryable`1 does
        //     not have a matching method, then this method does nothing. The System.Data.Entity.Core.Objects.ObjectQuery`1,
        //     System.Data.Entity.Core.Objects.ObjectSet`1, System.Data.Entity.Infrastructure.DbQuery`1
        //     and System.Data.Entity.DbSet`1 types all have an appropriate Include method to
        //     call. Paths are all-inclusive. For example, if an include call indicates Include("Orders.OrderLines"),
        //     not only will OrderLines be included, but also Orders. When you call the Include
        //     method, the query path is only valid on the returned instance of the System.Linq.IQueryable`1.
        //     Other instances of System.Linq.IQueryable`1 and the object context itself are
        //     not affected. Because the Include method returns the query object, you can call
        //     this method multiple times on an System.Linq.IQueryable`1 to specify multiple
        //     paths for the query.
        public static IQueryable<T> Include<T>(this IQueryable<T> source, string path)
        {
            return System.Data.Entity.QueryableExtensions.Include(source, path);
        }

        //
        // Summary:
        //     Specifies the related objects to include in the query results.
        //
        // Parameters:
        //   source:
        //     The source IQueryable on which to call Include.
        //
        //   path:
        //     A lambda expression representing the path to include.
        //
        // Type parameters:
        //   T:
        //     The type of entity being queried.
        //
        //   TProperty:
        //     The type of navigation property being included.
        //
        // Returns:
        //     A new IQueryable<T> with the defined query path.
        //
        // Remarks:
        //     The path expression must be composed of simple property access expressions together
        //     with calls to Select for composing additional includes after including a collection
        //     proprty. Examples of possible include paths are: To include a single reference:
        //     query.Include(e => e.Level1Reference) To include a single collection: query.Include(e
        //     => e.Level1Collection) To include a reference and then a reference one level
        //     down: query.Include(e => e.Level1Reference.Level2Reference) To include a reference
        //     and then a collection one level down: query.Include(e => e.Level1Reference.Level2Collection)
        //     To include a collection and then a reference one level down: query.Include(e
        //     => e.Level1Collection.Select(l1 => l1.Level2Reference)) To include a collection
        //     and then a collection one level down: query.Include(e => e.Level1Collection.Select(l1
        //     => l1.Level2Collection)) To include a collection and then a reference one level
        //     down: query.Include(e => e.Level1Collection.Select(l1 => l1.Level2Reference))
        //     To include a collection and then a collection one level down: query.Include(e
        //     => e.Level1Collection.Select(l1 => l1.Level2Collection)) To include a collection,
        //     a reference, and a reference two levels down: query.Include(e => e.Level1Collection.Select(l1
        //     => l1.Level2Reference.Level3Reference)) To include a collection, a collection,
        //     and a reference two levels down: query.Include(e => e.Level1Collection.Select(l1
        //     => l1.Level2Collection.Select(l2 => l2.Level3Reference))) This extension method
        //     calls the Include(String) method of the source IQueryable object, if such a method
        //     exists. If the source IQueryable does not have a matching method, then this method
        //     does nothing. The Entity Framework ObjectQuery, ObjectSet, DbQuery, and DbSet
        //     types all have an appropriate Include method to call. When you call the Include
        //     method, the query path is only valid on the returned instance of the IQueryable<T>.
        //     Other instances of IQueryable<T> and the object context itself are not affected.
        //     Because the Include method returns the query object, you can call this method
        //     multiple times on an IQueryable<T> to specify multiple paths for the query.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> source, Expression<Func<T, TProperty>> path)
        {
            return System.Data.Entity.QueryableExtensions.Include(source, path);
        }

        //
        // Summary:
        //     Enumerates the query such that for server queries such as those of System.Data.Entity.DbSet`1,
        //     System.Data.Entity.Core.Objects.ObjectSet`1 , System.Data.Entity.Core.Objects.ObjectQuery`1,
        //     and others the results of the query will be loaded into the associated System.Data.Entity.DbContext
        //     , System.Data.Entity.Core.Objects.ObjectContext or other cache on the client.
        //     This is equivalent to calling ToList and then throwing away the list without
        //     the overhead of actually creating the list.
        //
        // Parameters:
        //   source:
        //     The source query.
        public static void Load(this IQueryable source)
        {
            System.Data.Entity.QueryableExtensions.Load(source);
        }

        //
        // Summary:
        //     Asynchronously enumerates the query such that for server queries such as those
        //     of System.Data.Entity.DbSet`1, System.Data.Entity.Core.Objects.ObjectSet`1 ,
        //     System.Data.Entity.Core.Objects.ObjectQuery`1, and others the results of the
        //     query will be loaded into the associated System.Data.Entity.DbContext , System.Data.Entity.Core.Objects.ObjectContext
        //     or other cache on the client. This is equivalent to calling ToList and then throwing
        //     away the list without the overhead of actually creating the list.
        //
        // Parameters:
        //   source:
        //     The source query.
        //
        // Returns:
        //     A task that represents the asynchronous operation.
        public static Task LoadAsync(this IQueryable source)
        {
            return System.Data.Entity.QueryableExtensions.LoadAsync(source);
        }

        //
        // Summary:
        //     Asynchronously enumerates the query such that for server queries such as those
        //     of System.Data.Entity.DbSet`1, System.Data.Entity.Core.Objects.ObjectSet`1 ,
        //     System.Data.Entity.Core.Objects.ObjectQuery`1, and others the results of the
        //     query will be loaded into the associated System.Data.Entity.DbContext , System.Data.Entity.Core.Objects.ObjectContext
        //     or other cache on the client. This is equivalent to calling ToList and then throwing
        //     away the list without the overhead of actually creating the list.
        //
        // Parameters:
        //   source:
        //     The source query.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation.
        public static Task LoadAsync(this IQueryable source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.LoadAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously returns an System.Int64 that represents the total number of elements
        //     in a sequence.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 that contains the elements to be counted.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     number of elements in the input sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int64.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<long> LongCountAsync<TSource>(this IQueryable<TSource> source)
        {
            return System.Data.Entity.QueryableExtensions.LongCountAsync(source);
        }

        //
        // Summary:
        //     Asynchronously returns an System.Int64 that represents the total number of elements
        //     in a sequence.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 that contains the elements to be counted.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     number of elements in the input sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int64.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<long> LongCountAsync<TSource>(this IQueryable<TSource> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.LongCountAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously returns an System.Int64 that represents the number of elements
        //     in a sequence that satisfy a condition.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 that contains the elements to be counted.
        //
        //   predicate:
        //     A function to test each element for a condition.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     number of elements in the sequence that satisfy the condition in the predicate
        //     function.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or predicate is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source that satisfy the condition in the predicate
        //     function is larger than System.Int64.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<long> LongCountAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
        {
            return System.Data.Entity.QueryableExtensions.LongCountAsync(source, predicate);
        }

        //
        // Summary:
        //     Asynchronously returns an System.Int64 that represents the number of elements
        //     in a sequence that satisfy a condition.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 that contains the elements to be counted.
        //
        //   predicate:
        //     A function to test each element for a condition.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     number of elements in the sequence that satisfy the condition in the predicate
        //     function.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or predicate is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source that satisfy the condition in the predicate
        //     function is larger than System.Int64.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static Task<long> LongCountAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.LongCountAsync(source, predicate, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously returns the maximum value of a sequence.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 that contains the elements to determine the maximum
        //     of.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     maximum value in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<TSource> MaxAsync<TSource>(this IQueryable<TSource> source)
        {
            return System.Data.Entity.QueryableExtensions.MaxAsync(source);
        }

        //
        // Summary:
        //     Asynchronously returns the maximum value of a sequence.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 that contains the elements to determine the maximum
        //     of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     maximum value in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<TSource> MaxAsync<TSource>(this IQueryable<TSource> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.MaxAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously invokes a projection function on each element of a sequence and
        //     returns the maximum resulting value.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 that contains the elements to determine the maximum
        //     of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        //   TResult:
        //     The type of the value returned by the function represented by selector .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     maximum value in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<TResult> MaxAsync<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)
        {
            return System.Data.Entity.QueryableExtensions.MaxAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously invokes a projection function on each element of a sequence and
        //     returns the maximum resulting value.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 that contains the elements to determine the maximum
        //     of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        //   TResult:
        //     The type of the value returned by the function represented by selector .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     maximum value in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<TResult> MaxAsync<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.MaxAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously returns the minimum value of a sequence.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 that contains the elements to determine the minimum
        //     of.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     minimum value in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<TSource> MinAsync<TSource>(this IQueryable<TSource> source)
        {
            return System.Data.Entity.QueryableExtensions.MinAsync(source);
        }

        //
        // Summary:
        //     Asynchronously returns the minimum value of a sequence.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 that contains the elements to determine the minimum
        //     of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     minimum value in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<TSource> MinAsync<TSource>(this IQueryable<TSource> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.MinAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously invokes a projection function on each element of a sequence and
        //     returns the minimum resulting value.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 that contains the elements to determine the minimum
        //     of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        //   TResult:
        //     The type of the value returned by the function represented by selector .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     minimum value in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<TResult> MinAsync<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)
        {
            return System.Data.Entity.QueryableExtensions.MinAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously invokes a projection function on each element of a sequence and
        //     returns the minimum resulting value.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 that contains the elements to determine the minimum
        //     of.
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        //   TResult:
        //     The type of the value returned by the function represented by selector .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     minimum value in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static Task<TResult> MinAsync<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.MinAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously returns the only element of a sequence, and throws an exception
        //     if there is not exactly one element in the sequence.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the single element of.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     single element of the input sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     The source sequence is empty.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<TSource> SingleAsync<TSource>(this IQueryable<TSource> source)
        {
            return System.Data.Entity.QueryableExtensions.SingleAsync(source);
        }

        //
        // Summary:
        //     Asynchronously returns the only element of a sequence that satisfies a specified
        //     condition, and throws an exception if more than one such element exists.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the the single element of.
        //
        //   predicate:
        //     A function to test an element for a condition.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     single element of the input sequence that satisfies the condition in predicate.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or predicate is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     No element satisfies the condition in predicate .
        //
        //   T:System.InvalidOperationException:
        //     More than one element satisfies the condition in predicate .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<TSource> SingleAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
        {
            return System.Data.Entity.QueryableExtensions.SingleAsync(source, predicate);
        }

        //
        // Summary:
        //     Asynchronously returns the only element of a sequence, and throws an exception
        //     if there is not exactly one element in the sequence.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the single element of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     single element of the input sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source has more than one element.
        //
        //   T:System.InvalidOperationException:
        //     The source sequence is empty.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<TSource> SingleAsync<TSource>(this IQueryable<TSource> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SingleAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously returns the only element of a sequence that satisfies a specified
        //     condition, and throws an exception if more than one such element exists.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the single element of.
        //
        //   predicate:
        //     A function to test an element for a condition.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     single element of the input sequence that satisfies the condition in predicate.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or predicate is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     No element satisfies the condition in predicate .
        //
        //   T:System.InvalidOperationException:
        //     More than one element satisfies the condition in predicate .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<TSource> SingleAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SingleAsync(source, predicate, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously returns the only element of a sequence, or a default value if
        //     the sequence is empty; this method throws an exception if there is more than
        //     one element in the sequence.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the single element of.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     single element of the input sequence, or default (TSource) if the sequence contains
        //     no elements.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source has more than one element.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<TSource> SingleOrDefaultAsync<TSource>(this IQueryable<TSource> source)
        {
            return System.Data.Entity.QueryableExtensions.SingleOrDefaultAsync(source);
        }

        //
        // Summary:
        //     Asynchronously returns the only element of a sequence, or a default value if
        //     the sequence is empty; this method throws an exception if there is more than
        //     one element in the sequence.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the single element of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     single element of the input sequence, or default (TSource) if the sequence contains
        //     no elements.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.InvalidOperationException:
        //     source has more than one element.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<TSource> SingleOrDefaultAsync<TSource>(this IQueryable<TSource> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SingleOrDefaultAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously returns the only element of a sequence that satisfies a specified
        //     condition or a default value if no such element exists; this method throws an
        //     exception if more than one element satisfies the condition.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the single element of.
        //
        //   predicate:
        //     A function to test an element for a condition.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     single element of the input sequence that satisfies the condition in predicate,
        //     or default ( TSource ) if no such element is found.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or predicate is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<TSource> SingleOrDefaultAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
        {
            return System.Data.Entity.QueryableExtensions.SingleOrDefaultAsync(source, predicate);
        }

        //
        // Summary:
        //     Asynchronously returns the only element of a sequence that satisfies a specified
        //     condition or a default value if no such element exists; this method throws an
        //     exception if more than one element satisfies the condition.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to return the single element of.
        //
        //   predicate:
        //     A function to test an element for a condition.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     single element of the input sequence that satisfies the condition in predicate,
        //     or default ( TSource ) if no such element is found.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or predicate is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static Task<TSource> SingleOrDefaultAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SingleOrDefaultAsync(source, predicate, cancellationToken);
        }

        //
        // Summary:
        //     Bypasses a specified number of elements in a sequence and then returns the remaining
        //     elements.
        //
        // Parameters:
        //   source:
        //     A sequence to return elements from.
        //
        //   countAccessor:
        //     An expression that evaluates to the number of elements to skip.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A sequence that contains elements that occur after the specified index in the
        //     input sequence.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static IQueryable<TSource> Skip<TSource>(this IQueryable<TSource> source, Expression<Func<int>> countAccessor)
        {
            return System.Data.Entity.QueryableExtensions.Skip(source, countAccessor);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of nullable System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int64 values to calculate the sum of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int64.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<long?> SumAsync(this IQueryable<long?> source)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Double values to calculate the sum of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<double> SumAsync(this IQueryable<double> source)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int32 values to calculate the sum of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int32.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<int> SumAsync(this IQueryable<int> source)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of nullable System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int32 values to calculate the sum of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int32.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<int?> SumAsync(this IQueryable<int?> source)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of System.Decimal values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Decimal values to calculate the sum of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<decimal> SumAsync(this IQueryable<decimal> source)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int64 values to calculate the sum of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int64.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<long> SumAsync(this IQueryable<long> source)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of nullable System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Double values to calculate the sum of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double?> SumAsync(this IQueryable<double?> source)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Single values to calculate the sum of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<float> SumAsync(this IQueryable<float> source)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of nullable System.Decimal values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Decimal values to calculate the sum of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<decimal?> SumAsync(this IQueryable<decimal?> source)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of nullable System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Single values to calculate the sum of.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<float?> SumAsync(this IQueryable<float?> source)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of System.Decimal values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Decimal values to calculate the sum of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<decimal> SumAsync(this IQueryable<decimal> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of nullable System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Double values to calculate the sum of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double?> SumAsync(this IQueryable<double?> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of System.Double values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Double values to calculate the sum of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<double> SumAsync(this IQueryable<double> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Single values to calculate the sum of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<float> SumAsync(this IQueryable<float> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of nullable System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int64 values to calculate the sum of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int64.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<long?> SumAsync(this IQueryable<long?> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of System.Int64 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int64 values to calculate the sum of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int64.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<long> SumAsync(this IQueryable<long> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of nullable System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Int32 values to calculate the sum of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int32.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<int?> SumAsync(this IQueryable<int?> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of System.Int32 values.
        //
        // Parameters:
        //   source:
        //     A sequence of System.Int32 values to calculate the sum of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int32.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        public static Task<int> SumAsync(this IQueryable<int> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of nullable System.Single values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Single values to calculate the sum of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<float?> SumAsync(this IQueryable<float?> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of a sequence of nullable System.Decimal values.
        //
        // Parameters:
        //   source:
        //     A sequence of nullable System.Decimal values to calculate the sum of.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the values in the sequence.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Decimal.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<decimal?> SumAsync(this IQueryable<decimal?> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of System.Single values that
        //     is obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<float> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, float>> selector)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of nullable System.Single values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<float?> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, float?>> selector)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of nullable System.Int32 values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int32.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<int?> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, int?>> selector)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of System.Int64 values that is
        //     obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int64.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<long> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, long>> selector)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of System.Int32 values that is
        //     obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int32.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<int> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, int>> selector)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of nullable System.Int64 values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int64.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<long?> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, long?>> selector)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of System.Double values that
        //     is obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, double>> selector)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of nullable System.Decimal values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Decimal.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<decimal?> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal?>> selector)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of System.Decimal values that
        //     is obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Decimal.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<decimal> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal>> selector)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of nullable System.Double values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double?> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, double?>> selector)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of System.Single values that
        //     is obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static Task<float> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, float>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of nullable System.Single values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<float?> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, float?>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of System.Double values that
        //     is obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, double>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of System.Int32 values that is
        //     obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int32.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<int> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, int>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of System.Decimal values that
        //     is obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Decimal.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static Task<decimal> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of nullable System.Decimal values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Decimal.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<decimal?> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal?>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of nullable System.Int64 values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int64.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static Task<long?> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, long?>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of System.Int64 values that is
        //     obtained by invoking a projection function on each element of the input sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int64.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static Task<long> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, long>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of nullable System.Int32 values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        //   T:System.OverflowException:
        //     The number of elements in source is larger than System.Int32.MaxValue .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<int?> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, int?>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Asynchronously computes the sum of the sequence of nullable System.Double values
        //     that is obtained by invoking a projection function on each element of the input
        //     sequence.
        //
        // Parameters:
        //   source:
        //     A sequence of values of type TSource .
        //
        //   selector:
        //     A projection function to apply to each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of source .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains the
        //     sum of the projected values.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null .
        //
        //   T:System.InvalidOperationException:
        //     source doesn't implement System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
        //     .
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<double?> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, double?>> selector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.SumAsync(source, selector, cancellationToken);
        }

        //
        // Summary:
        //     Returns a specified number of contiguous elements from the start of a sequence.
        //
        // Parameters:
        //   source:
        //     The sequence to return elements from.
        //
        //   countAccessor:
        //     An expression that evaluates to the number of elements to return.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A sequence that contains the specified number of elements from the start of the
        //     input sequence.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static IQueryable<TSource> Take<TSource>(this IQueryable<TSource> source, Expression<Func<int>> countAccessor)
        {
            return System.Data.Entity.QueryableExtensions.Take(source, countAccessor);
        }
        //
        // Summary:
        //     Creates an array from an System.Linq.IQueryable`1 by enumerating it asynchronously.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to create an array from.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains an
        //     array that contains elements from the input sequence.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<TSource[]> ToArrayAsync<TSource>(this IQueryable<TSource> source)
        {
            return System.Data.Entity.QueryableExtensions.ToArrayAsync(source);
        }

        //
        // Summary:
        //     Creates an array from an System.Linq.IQueryable`1 by enumerating it asynchronously.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to create an array from.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains an
        //     array that contains elements from the input sequence.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<TSource[]> ToArrayAsync<TSource>(this IQueryable<TSource> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.ToArrayAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Creates a System.Collections.Generic.Dictionary`2 from an System.Linq.IQueryable`1
        //     by enumerating it asynchronously according to a specified key selector function.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to create a System.Collections.Generic.Dictionary`2
        //     from.
        //
        //   keySelector:
        //     A function to extract a key from each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        //   TKey:
        //     The type of the key returned by keySelector .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains a
        //     System.Collections.Generic.Dictionary`2 that contains selected keys and values.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IQueryable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return System.Data.Entity.QueryableExtensions.ToDictionaryAsync(source, keySelector);
        }

        //
        // Summary:
        //     Creates a System.Collections.Generic.Dictionary`2 from an System.Linq.IQueryable`1
        //     by enumerating it asynchronously according to a specified key selector function.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to create a System.Collections.Generic.Dictionary`2
        //     from.
        //
        //   keySelector:
        //     A function to extract a key from each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        //   TKey:
        //     The type of the key returned by keySelector .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains a
        //     System.Collections.Generic.Dictionary`2 that contains selected keys and values.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IQueryable<TSource> source, Func<TSource, TKey> keySelector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.ToDictionaryAsync(source, keySelector, cancellationToken);
        }
        //
        // Summary:
        //     Creates a System.Collections.Generic.Dictionary`2 from an System.Linq.IQueryable`1
        //     by enumerating it asynchronously according to a specified key selector function
        //     and a comparer.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to create a System.Collections.Generic.Dictionary`2
        //     from.
        //
        //   keySelector:
        //     A function to extract a key from each element.
        //
        //   comparer:
        //     An System.Collections.Generic.IEqualityComparer`1 to compare keys.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        //   TKey:
        //     The type of the key returned by keySelector .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains a
        //     System.Collections.Generic.Dictionary`2 that contains selected keys and values.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IQueryable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return System.Data.Entity.QueryableExtensions.ToDictionaryAsync(source, keySelector, comparer);
        }

        //
        // Summary:
        //     Creates a System.Collections.Generic.Dictionary`2 from an System.Linq.IQueryable`1
        //     by enumerating it asynchronously according to a specified key selector function
        //     and a comparer.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to create a System.Collections.Generic.Dictionary`2
        //     from.
        //
        //   keySelector:
        //     A function to extract a key from each element.
        //
        //   comparer:
        //     An System.Collections.Generic.IEqualityComparer`1 to compare keys.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        //   TKey:
        //     The type of the key returned by keySelector .
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains a
        //     System.Collections.Generic.Dictionary`2 that contains selected keys and values.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(this IQueryable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.ToDictionaryAsync(source, keySelector, comparer, cancellationToken);
        }

        //
        // Summary:
        //     Creates a System.Collections.Generic.Dictionary`2 from an System.Linq.IQueryable`1
        //     by enumerating it asynchronously according to a specified key selector and an
        //     element selector function.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to create a System.Collections.Generic.Dictionary`2
        //     from.
        //
        //   keySelector:
        //     A function to extract a key from each element.
        //
        //   elementSelector:
        //     A transform function to produce a result element value from each element.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        //   TKey:
        //     The type of the key returned by keySelector .
        //
        //   TElement:
        //     The type of the value returned by elementSelector.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains a
        //     System.Collections.Generic.Dictionary`2 that contains values of type TElement
        //     selected from the input sequence.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IQueryable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            return System.Data.Entity.QueryableExtensions.ToDictionaryAsync(source, keySelector, elementSelector);
        }

        //
        // Summary:
        //     Creates a System.Collections.Generic.Dictionary`2 from an System.Linq.IQueryable`1
        //     by enumerating it asynchronously according to a specified key selector and an
        //     element selector function.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to create a System.Collections.Generic.Dictionary`2
        //     from.
        //
        //   keySelector:
        //     A function to extract a key from each element.
        //
        //   elementSelector:
        //     A transform function to produce a result element value from each element.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        //   TKey:
        //     The type of the key returned by keySelector .
        //
        //   TElement:
        //     The type of the value returned by elementSelector.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains a
        //     System.Collections.Generic.Dictionary`2 that contains values of type TElement
        //     selected from the input sequence.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IQueryable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.ToDictionaryAsync(source, keySelector, elementSelector, cancellationToken);
        }

        //
        // Summary:
        //     Creates a System.Collections.Generic.Dictionary`2 from an System.Linq.IQueryable`1
        //     by enumerating it asynchronously according to a specified key selector function,
        //     a comparer, and an element selector function.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to create a System.Collections.Generic.Dictionary`2
        //     from.
        //
        //   keySelector:
        //     A function to extract a key from each element.
        //
        //   elementSelector:
        //     A transform function to produce a result element value from each element.
        //
        //   comparer:
        //     An System.Collections.Generic.IEqualityComparer`1 to compare keys.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        //   TKey:
        //     The type of the key returned by keySelector .
        //
        //   TElement:
        //     The type of the value returned by elementSelector.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains a
        //     System.Collections.Generic.Dictionary`2 that contains values of type TElement
        //     selected from the input sequence.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IQueryable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            return System.Data.Entity.QueryableExtensions.ToDictionaryAsync(source, keySelector, elementSelector, comparer);
        }

        //
        // Summary:
        //     Creates a System.Collections.Generic.Dictionary`2 from an System.Linq.IQueryable`1
        //     by enumerating it asynchronously according to a specified key selector function,
        //     a comparer, and an element selector function.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to create a System.Collections.Generic.Dictionary`2
        //     from.
        //
        //   keySelector:
        //     A function to extract a key from each element.
        //
        //   elementSelector:
        //     A transform function to produce a result element value from each element.
        //
        //   comparer:
        //     An System.Collections.Generic.IEqualityComparer`1 to compare keys.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        //   TKey:
        //     The type of the key returned by keySelector .
        //
        //   TElement:
        //     The type of the value returned by elementSelector.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains a
        //     System.Collections.Generic.Dictionary`2 that contains values of type TElement
        //     selected from the input sequence.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(this IQueryable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.ToDictionaryAsync(source, keySelector, elementSelector, comparer, cancellationToken);
        }

        //
        // Summary:
        //     Creates a System.Collections.Generic.List`1 from an System.Linq.IQueryable by
        //     enumerating it asynchronously.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable to create a System.Collections.Generic.List`1 from.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains a
        //     System.Collections.Generic.List`1 that contains elements from the input sequence.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<List<object>> ToListAsync(this IQueryable source)
        {
            return System.Data.Entity.QueryableExtensions.ToListAsync(source);
        }

        //
        // Summary:
        //     Creates a System.Collections.Generic.List`1 from an System.Linq.IQueryable by
        //     enumerating it asynchronously.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable to create a System.Collections.Generic.List`1 from.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains a
        //     System.Collections.Generic.List`1 that contains elements from the input sequence.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<List<object>> ToListAsync(this IQueryable source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.ToListAsync(source, cancellationToken);
        }

        //
        // Summary:
        //     Creates a System.Collections.Generic.List`1 from an System.Linq.IQueryable`1
        //     by enumerating it asynchronously.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to create a System.Collections.Generic.List`1 from.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains a
        //     System.Collections.Generic.List`1 that contains elements from the input sequence.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<List<TSource>> ToListAsync<TSource>(this IQueryable<TSource> source)
        {
            return System.Data.Entity.QueryableExtensions.ToListAsync(source);
        }

        //
        // Summary:
        //     Creates a System.Collections.Generic.List`1 from an System.Linq.IQueryable`1
        //     by enumerating it asynchronously.
        //
        // Parameters:
        //   source:
        //     An System.Linq.IQueryable`1 to create a list from.
        //
        //   cancellationToken:
        //     A System.Threading.CancellationToken to observe while waiting for the task to
        //     complete.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements of System.Data.Entity.QueryableExtensions.
        //
        // Returns:
        //     A task that represents the asynchronous operation. The task result contains a
        //     System.Collections.Generic.List`1 that contains elements from the input sequence.
        //
        // Remarks:
        //     Multiple active operations on the same context instance are not supported. Use
        //     'await' to ensure that any asynchronous operations have completed before calling
        //     another method on this context.
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Task<List<TSource>> ToListAsync<TSource>(this IQueryable<TSource> source, CancellationToken cancellationToken)
        {
            return System.Data.Entity.QueryableExtensions.ToListAsync(source, cancellationToken);
        }
    }
}
