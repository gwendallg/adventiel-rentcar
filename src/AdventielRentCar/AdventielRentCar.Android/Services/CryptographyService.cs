using PCLCrypto;
using System.Text;
using AdventielRentCar.Droid.Services;
using AdventielRentCar.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(CryptographyService))]
namespace AdventielRentCar.Droid.Services
{
    /// <summary>
    /// implémentation du service de Cryptographie pour Android
    /// </summary>
    public class CryptographyService : ICryptographyService
    {
        /// <inheritdoc />
        public string Md5(string value)
        {
            var algoProv = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Md5);
            var dataB = Encoding.UTF8.GetBytes(value);
            var dataHash = algoProv.HashData(dataB);
            var hex = new StringBuilder(dataHash.Length * 2);
            foreach (var b in dataHash)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        /// <inheritdoc />
        public string Salt()
        {
            var dataHash = WinRTCrypto.CryptographicBuffer.GenerateRandom(16);
            var hex = new StringBuilder(dataHash.Length * 2);
            foreach (var b in dataHash)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        /// <inheritdoc />
        public string Sha256(string value)
        {
            var algoProv = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha256);
            var dataB = Encoding.UTF8.GetBytes(value);
            var dataHash = algoProv.HashData(dataB);
            var hex = new StringBuilder(dataHash.Length * 2);
            foreach (var b in dataHash)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }
    }
}
