using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1.Attributes
{
    public class CustomMessageHandler : DelegatingHandler
    {
        private static byte[] key;
        private static string key_str = "A4F2E002F2FB267A8F64CDC18AB389EF";
        private static byte[] iV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef }; //useless in ECB mode

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            //var oldHeaders = request.Content.Headers;
            //var requestContent = await request.Content.ReadAsStringAsync();
            //if (!String.IsNullOrWhiteSpace(requestContent)) {
            //    var decryptedRequestContent = Decrypt(requestContent);
            //    request.Content = new StringContent(decryptedRequestContent);
            //    ReplaceHeaders(request.Content.Headers, oldHeaders);
            //}

            // Call the inner handler.
            var response = await base.SendAsync(request, cancellationToken);

            //oldHeaders = response.Content.Headers;
            //var responseContent = await response.Content.ReadAsStringAsync();
            //if (!String.IsNullOrWhiteSpace(responseContent))
            //{
            //    var encryptedContent = Encrypt(responseContent);
            //    response.Content = new StringContent(encryptedContent);
            //    ReplaceHeaders(response.Content.Headers, oldHeaders);
            //}

            return response;
        }

        private void ReplaceHeaders(HttpContentHeaders currentHeaders, HttpContentHeaders oldHeaders)
        {
            currentHeaders.Clear();
            foreach (var item in oldHeaders)
                currentHeaders.Add(item.Key, item.Value);
        }

        /// <summary>
        /// Decrypts the specified string to decrypt.
        /// </summary>
        /// <param name="stringToDecrypt">The string to decrypt.</param>
        /// <param name="decryptionKey">The decryption key.</param>
        /// <returns>Return string</returns>
        public static string Decrypt(string stringToDecrypt)
        {
            ///// byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
            byte[] inputByteArray;
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(key_str.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.PKCS7;
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, iV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                return "Decrypt Error: " + e.Message;
            }
        }

        /// <summary>
        /// Encrypts the specified string to encrypt.
        /// </summary>
        /// <param name="stringToEncrypt">The string to encrypt.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <returns>Return string</returns>
        public static string Encrypt(string stringToEncrypt)
        {
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(key_str.Substring(0, 8));
                DESCryptoServiceProvider encrypt = new DESCryptoServiceProvider();
                encrypt.Mode = CipherMode.ECB;
                encrypt.Padding = PaddingMode.PKCS7;

                byte[] inputByteArrayEncrypt = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encrypt.CreateEncryptor(key, iV), CryptoStreamMode.Write);
                cryptoStream.Write(inputByteArrayEncrypt, 0, inputByteArrayEncrypt.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(memoryStream.ToArray());
            }
            catch (Exception e)
            {
                return "Encrypt Error: " + e.Message;
            }
        }
    }
}