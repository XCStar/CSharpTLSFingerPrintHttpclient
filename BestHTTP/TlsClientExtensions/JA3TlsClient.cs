using BestHTTP.Connections.TLS;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Tls;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BestHTTP.TlsClientExtensions
{
    public class JA3TlsClient : DefaultTls13Client
    {
        private Ja3Settings ja3Settings;
        public JA3TlsClient(HTTPRequest request, List<ServerName> sniServerNames, List<ProtocolName> protocols,Ja3Settings ja3Settings)
            : base(request, sniServerNames, protocols)
        {
            this.ja3Settings = ja3Settings;
        }
        public override IDictionary<int, byte[]> GetClientExtensions()
        {
            var extensions = base.GetClientExtensions();
            extensions.Add(17513,Array.Empty<byte>());
            // extensions.Add(65281,Array.Empty<byte>());
            // extensions.Add(ExtensionType.psk_key_exchange_modes, Array.Empty<byte>());//45
            //extensions.Add(ExtensionType.psk_key_exchange_modes,new byte[] { 1});//18
           // extensions.Add(ExtensionType.compress_certificate, Array.Empty<byte>());//27
            TlsExtensionsUtilities.AddPaddingExtension(extensions, 0);//21
            return extensions;
        }
        public override IDictionary<int, byte[]> ExtensionSorted(IDictionary<int, byte[]> extensions)
        {
            var baseExtensions = base.ExtensionSorted(extensions);
            if (ja3Settings.RandomExtensions)
            {
                var listDictionary = new ListDictionary();
                foreach (var extension in extensions) 
                {
                    listDictionary.Add(extension);
                }
                listDictionary.Shuffle();
                return listDictionary;
            }
            return baseExtensions;
        }
        protected override IList<int> GetSupportedGroups(IList<int> namedGroupRoles)
        {
            var supports= base.GetSupportedGroups(namedGroupRoles);
            var ellSupports= Ja3StringConverter.ParseSupportedGroups(ja3Settings.EllipticCurves);
            foreach (var item in ellSupports)
            {
                if (!supports.Contains(item))
                {
                    throw new System.Exception("当前系统不支持该算法");
                }
            }
            return ellSupports.ToArray();
        }
        public override int[] GetCipherSuites()
        {
            var c = base.GetCipherSuites();
            var ciphers= Ja3StringConverter.ParseCiphers(ja3Settings.Ciphers).ToArray();
            return ciphers;
        }
        

    }
}
