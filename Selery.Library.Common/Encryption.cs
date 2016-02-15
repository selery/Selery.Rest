using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLCrypto;

namespace Selery.Library.Common
{
    public class Encryption
    {
        public static string EncryptToBase64String(string strPassword)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] bytEncPassword = encoding.GetBytes(strPassword);
            var hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha1);
            byte[] hash = hasher.HashData(bytEncPassword);
            return Convert.ToBase64String(hash);
        }

        public static byte[] EncryptToByteArray(string strPassword)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] bytEncPassword = encoding.GetBytes(strPassword);
            var hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha1);
            return  hasher.HashData(bytEncPassword);            
        } 

    }
}
