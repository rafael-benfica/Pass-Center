using Paseto.Authentication;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.PasetoToken {
    public static class Token {
        public static string GerarToken() {

            byte[] _publicKey = HexToBytes(ConfigurationManager.AppSettings["chavePublica"]);
            byte[] _privateKey = HexToBytes(ConfigurationManager.AppSettings["chavePrivada"]);

            var date = DateTime.UtcNow;

            var claims = new PasetoInstance {
                Issuer = "http://api.passcenter.com.br",
                Subject = "Token de autenticacao",
                Audience = "http://passcenter.com.br",
                Expiration = date.AddMinutes(10),
                NotBefore = date.AddMinutes(-10),
                IssuedAt = date,
                AdditionalClaims = new Dictionary<string, object> {
                    ["instituicao"] = new object[] { 0 },
                    ["turma"] = new object[] { 2 },
                    ["usuario"] = new object[] { 3 }
                },
            };

            return PasetoUtility.Sign(_publicKey, _privateKey, claims);
        }

        public static Indentificacao ValidarToken(string token) {

            byte[] _publicKey = HexToBytes(ConfigurationManager.AppSettings["chavePublica"]);

            var tokenDescodificado = PasetoUtility.Parse(_publicKey, token, validateTimes: true);

            if (Object.Equals(tokenDescodificado, null)) {
                return null;
            }

            Indentificacao ident = new Indentificacao();

            ident.Institiuicao = converteObjStr(tokenDescodificado.AdditionalClaims["instituicao"]);
            ident.Turma = converteObjStr(tokenDescodificado.AdditionalClaims["turma"]);
            ident.usuario = converteObjStr(tokenDescodificado.AdditionalClaims["usuario"]);

            return ident;
        }

        private static byte[] HexToBytes(string hexString) {
            var bytes = new byte[hexString.Length / 2];
            for (int i = 0; i < bytes.Length; i++) {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return bytes;
        }

        private static string converteObjStr(object original) {
            return original.ToString().Replace("[", "").Replace("]", "");
        }

    }
}