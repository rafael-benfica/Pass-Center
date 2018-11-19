using Paseto.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.Paseto {
    public class Token {
        private string GerarToken(string chavePublica, string chavePrivada) {

            byte[] _publicKey = HexToBytes(chavePublica);
            byte[] _privateKey = HexToBytes(chavePrivada);

            var date = DateTime.UtcNow;

            var claims = new PasetoInstance {
                Issuer = "http://auth.example.com",
                Subject = "2986689",
                Audience = "audience",
                Expiration = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Kind).AddMinutes(10),
                NotBefore = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Kind).AddMinutes(-10),
                IssuedAt = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Kind),
                AdditionalClaims = new Dictionary<string, object> {
                    ["roles"] = new[] { "Admin", "User" }
                },
            };

            return PasetoUtility.Sign(_publicKey, _privateKey, claims);
        }
        private byte[] HexToBytes(string hexString) {
            var bytes = new byte[hexString.Length / 2];
            for (int i = 0; i < bytes.Length; i++) {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return bytes;
        }

    }
}