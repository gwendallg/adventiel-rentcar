using PCLCrypto;
using System.Text;
using AdventielRentCar.iOS.Services;
using AdventielRentCar.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(CryptographyService))]
namespace AdventielRentCar.iOS.Services
{
    /// <summary>
    /// implémentation du service de Cryptographie pour iOS
    /// </summary>
    public class CryptographyService : ICryptographyService
    {
        /// <inheritdoc />
        public string Md5(string value)
        {
            IHashAlgorithmProvider algoProv = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Md5);
            byte[] dataB = Encoding.UTF8.GetBytes(value);
            byte[] dataHash = algoProv.HashData(dataB);
            var hex = new StringBuilder(dataHash.Length * 2);
            foreach (byte b in dataHash)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        /// <inheritdoc />
        public string Salt()
        {
            return Encoding.UTF8.GetString(WinRTCrypto.CryptographicBuffer.GenerateRandom(16));
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
