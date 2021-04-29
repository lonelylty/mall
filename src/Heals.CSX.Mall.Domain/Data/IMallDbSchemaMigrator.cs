using System.Threading.Tasks;

namespace Heals.CSX.Mall.Data
{
    public interface IMallDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
