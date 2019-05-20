using Paseto.Authentication;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace API_PassCenter.Models.PasetoToken {
    public static class Token {
        public static string GerarToken(DataSet info) {

            byte[] _publicKey = HexToBytes(ConfigurationManager.AppSettings["chavePublica"]);
            byte[] _privateKey = HexToBytes(ConfigurationManager.AppSettings["chavePrivada"]);

            var date = DateTime.UtcNow;



            var claims = new PasetoInstance {
                Issuer = "http://api.passcenter.com.br",
                Subject = "Token de autenticacao",
                Audience = "http://passcenter.com.br",
                Expiration = date.AddMinutes(30),
                NotBefore = date.AddMinutes(-30),
                IssuedAt = date,
                AdditionalClaims = new Dictionary<string, object> {
                    ["usu_codigo"] = new object[] { Convert.ToInt32(info.Tables[0].Rows[0]["usu_codigo"]) },
                    ["pes_codigo"] = new object[] { Convert.ToInt32(info.Tables[0].Rows[0]["pes_codigo"]) },
                    ["end_codigo"] = new object[] { Convert.ToInt32(info.Tables[0].Rows[0]["end_codigo"]) },
                    ["ins_codigo"] = new object[] { Convert.ToInt32(info.Tables[0].Rows[0]["ins_codigo"]) },
                    ["tus_codigo"] = new object[] { Convert.ToInt32(info.Tables[0].Rows[0]["tus_codigo"]) }
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

            ident.Usu_codigo = converteObjStr(tokenDescodificado.AdditionalClaims["usu_codigo"]);
            ident.Pes_codigo = converteObjStr(tokenDescodificado.AdditionalClaims["pes_codigo"]);
            ident.End_codigo = converteObjStr(tokenDescodificado.AdditionalClaims["end_codigo"]);
            ident.Ins_codigo = converteObjStr(tokenDescodificado.AdditionalClaims["ins_codigo"]);
            ident.Tus_codigo = Convert.ToInt32(converteObjStr(tokenDescodificado.AdditionalClaims["tus_codigo"]));

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