using System.Threading.Tasks;
using AdventielRentCar.Models;

namespace AdventielRentCar.Services
{
    /// <summary>
    /// interface de service de gestion d'utilisateur
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// ajoute un nouvel utilisateur
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newPassword"></param>
        void AddUser(User user, string newPassword);

        /// <summary>
        /// connecte l'utilisateur
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="remember"></param>
        /// <returns></returns>
        Task LoginAsync(string login, string password, bool remember);

        /// <summary>
        /// retourne le dernier utilisateur enregistré qui s'est connecté
        /// </summary>
        /// <returns></returns>
        string GetRememberLogin();

        /// <summary>
        /// deconnecte l'utilisateur
        /// </summary>
        /// <returns></returns>
        Task LogoutAsync();
    }
}
