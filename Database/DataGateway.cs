using MediaDatabase.Database.Entities;

using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace MediaDatabase.Database
{
    public class DataGateway : IDisposable
    {
        MediaDatabaseContext _context = new MediaDatabaseContext();

        #region CRUD

        public IQueryable<TEntity> Set<TEntity>() where TEntity : class
        {
            ThrowIfDisposed();

            return _context.Set<TEntity>();
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            ThrowIfDisposed();

            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            ThrowIfDisposed();

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        #endregion

        #region Functions

        public int? DequeueScanRequestId()
        {
            ThrowIfDisposed();

            return _context.spDequeueScanRequest().SingleOrDefault();
        }

        public int EnsureVolume(string mediumCaption, long? mediumSize, string mediumSerialNumber, string mediumTypeName, string partitionCaption, int? partitionDiskIndex, int? partitionIndex, string volumeCaption, string volumeFileSystem, string volumeName, string volumeSerialNumber)
        {
            ThrowIfDisposed();

            var volumeIdParameter = new System.Data.Entity.Core.Objects.ObjectParameter("VolumeId", typeof(int));
            _context.spEnsureVolume(mediumCaption, mediumSize, mediumSerialNumber, mediumTypeName, partitionCaption, partitionDiskIndex, partitionIndex, volumeCaption, volumeFileSystem, volumeName, volumeSerialNumber, volumeIdParameter);
            return (int)volumeIdParameter.Value;
        }

        public int PurgeContentFiles(int? volumeId, string path, DateTimeOffset? lastUpdatedBefore)
        {
            ThrowIfDisposed();

            return _context.spPurgeContentFiles(volumeId, path, lastUpdatedBefore);
        }

        #endregion

        public IDbCommand CreateCommand(CommandType commandType, string commandText)
        {
            ThrowIfDisposed();

            var cmd = _context.Database.Connection.CreateCommand();
            try
            {
                cmd.CommandType = commandType;
                cmd.CommandText = commandText;
                return cmd;
            }
            catch
            {
                cmd.Dispose();
                throw;
            }
        }

        #region IDisposable

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(typeof(DataGateway).Name);
        }

        ~DataGateway()
        {
            Dispose(false);
        }

        #endregion

        #region SqlProvider Hack

        [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields",
            Justification = "Required due to a bug in EntityFramework")]
        SqlProviderServices instance = SqlProviderServices.Instance;

        #endregion
    }
}
