namespace AdventielRentCar.Services
{
    /// <summary>
    /// interface de cryptographie
    /// </summary>
    public interface ICryptographyService
    {
        /// <summary>
        /// calcule la valeur MD5 de la chaîne passée en paramètre
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string Md5(string value);

        /// <summary>
        /// calcul un chiffrement
        /// </summary>
        /// <returns></returns>
        string Salt();

        /// <summary>
        /// calcule la valeur SHA256
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string Sha256(string value);
    }
}
