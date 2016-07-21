using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaDatabase.Hasher
{
    public interface IScanAsyncResult : IAsyncResult
    {
        /// <summary>
        /// Gets the scan request identifier, or null if scan was manually started.
        /// </summary>
        int? ScanRequestId
        {
            get;
        }

        /// <summary>
        /// Gets the path being scanned.
        /// </summary>
        string Path
        {
            get;
        }

        /// <summary>
        /// Gets the date and time when the async process started.
        /// </summary>
        DateTime Started
        {
            get;
        }

        /// <summary>
        /// Gets the date and time when the async process finished, or <c>null</c> if the async process has not yet finished.
        /// </summary>
        DateTime? Finished
        {
            get;
        }

        /// <summary>
        /// Gets a <see cref="ICounter"/> object the provides progress information about files scanned by the async process.
        /// </summary>
        ICounter Scanned
        {
            get;
        }

        /// <summary>
        /// Gets the date and time when Discovery phase finished, or <c>null</c> if it has not finished yet.
        /// </summary>
        DateTime? DiscoveryFinished
        {
            get;
        }

        /// <summary>
        /// Gets the date and time when Discovery phase started, or <c>null</c> if it has not started yet.
        /// </summary>
        DateTime? DiscoveryStarted
        {
            get;
        }

        /// <summary>
        /// Gets the <see cref="TaskStatus"/> of the discovery task.
        /// </summary>
        TaskStatus DiscoveryStatus
        {
            get;
        }

        /// <summary>
        /// Gets a <see cref="ICounter"/> object the provides progress information about media files discovered by the async process.
        /// </summary>
        ICounter Discovered
        {
            get;
        }

        /// <summary>
        /// Gets the date and time when Hashing phase finished, or <c>null</c> if it has not finished yet.
        /// </summary>
        DateTime? HashingFinished
        {
            get;
        }

        /// <summary>
        /// Gets the date and time when Hashing phase started, or <c>null</c> if it has not started yet.
        /// </summary>
        DateTime? HashingStarted
        {
            get;
        }

        /// <summary>
        /// Gets the <see cref="TaskStatus"/> of the hashing task.
        /// </summary>
        TaskStatus HashingStatus
        {
            get;
        }

        /// <summary>
        /// Gets a <see cref="ICounter"/> object the provides progress information about media files hashed by the async process.
        /// </summary>
        ICounter Hashed
        {
            get;
        }

        /// <summary>
        /// Gets the hashing progress percentage.
        /// </summary>
        int HashingProgress
        {
            get;
        }

        /// <summary>
        /// Gets the date and time when Saving phase finished, or <c>null</c> if it has not finished yet.
        /// </summary>
        DateTime? SavingFinished
        {
            get;
        }

        /// <summary>
        /// Gets the date and time when Saving phase started, or <c>null</c> if it has not started yet.
        /// </summary>
        DateTime? SavingStarted
        {
            get;
        }

        /// <summary>
        /// Gets the <see cref="TaskStatus"/> of the saving task.
        /// </summary>
        TaskStatus SavingStatus
        {
            get;
        }

        /// <summary>
        /// Gets a <see cref="ICounter"/> object the provides progress information about media files saved by the async process.
        /// </summary>
        ICounter Saved
        {
            get;
        }

        /// <summary>
        /// Gets the saving progress percentage.
        /// </summary>
        int SavingProgress
        {
            get;
        }

        /// <summary>
        /// Gets a collection of warnings that occured during the async process.
        /// </summary>
        IEnumerable<string> Warnings
        {
            get;
        }

        /// <summary>
        /// Gets the collection of errors that occured during the async process.
        /// </summary>
        IEnumerable<string> Errors
        {
            get;
        }

        /// <summary>
        /// Gets a <see cref="IWorkerStats"/> object which provides worker threads statistics.
        /// </summary>
        IWorkerStats WorkerStats
        {
            get;
        }

        /// <summary>
        /// Gets the overall <see cref="TaskStatus"/>.
        /// </summary>
        TaskStatus OverallStatus
        {
            get;
        }

        /// <summary>
        /// Cancels the async process.
        /// </summary>
        void Cancel();
    }
}
