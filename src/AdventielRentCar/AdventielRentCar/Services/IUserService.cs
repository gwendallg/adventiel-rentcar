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
        /// retourne l'utilisateur authentifié
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User Authenticate(string login, string password);

        /// <summary>
        /// retourne le dernier login enregistré 
        /// </summary>
        /// <returns></returns>
        string GetRememberLogin();

        /// <summary>
        /// affecte le dernier login enregistré
        /// </summary>
        /// <param name="login"></param>
        void SetRememberLogin(string login);
    }
}
