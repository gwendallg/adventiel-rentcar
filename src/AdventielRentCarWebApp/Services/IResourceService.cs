using System.Collections.Generic;

namespace AdventielRentCarWebApp.Services
{
    public interface IResourceService
    {
        IList<T> Load<T>(string resourceName);
    }
}
