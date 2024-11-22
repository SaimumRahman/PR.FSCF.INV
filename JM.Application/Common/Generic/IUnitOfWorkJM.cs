
using JM.Middleware.Http;
using JM.Application.Interfaces.I_Common;
using JM.Infrastructure.Base;
using System;
using System.Threading.Tasks;
using JM.Application.Interfaces.I_Supplier;



namespace JM.Application.Common.Generic
{
    public interface IUnitOfWorkJM: IDisposable 
    {
        public IBaseDapperRepository dapperRepo { get; }
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        public IDbContextCore _dbContex { get; }


        public ICommonLibRepository Common { get; }


        #region Supplier
        public ISupplierRepo SupplierRepo { get; }
        #endregion

        Task<int> SaveChangesAsync();

        void BeginTransaction();

        void Commit();

        void Rollback();

    }
}
