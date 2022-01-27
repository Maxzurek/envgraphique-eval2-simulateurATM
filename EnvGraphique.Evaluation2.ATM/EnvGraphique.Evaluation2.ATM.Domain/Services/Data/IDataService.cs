using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services
{
    public interface IDataService<T>
    {
        Task<ObservableCollection<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
