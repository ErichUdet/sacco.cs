﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sacco_test {
    using System;
    
    
    /// <summary>
    ///   Classe di risorse fortemente tipizzata per la ricerca di stringhe localizzate e così via.
    /// </summary>
    // Questa classe è stata generata automaticamente dalla classe StronglyTypedResourceBuilder.
    // tramite uno strumento quale ResGen o Visual Studio.
    // Per aggiungere o rimuovere un membro, modificare il file con estensione ResX ed eseguire nuovamente ResGen
    // con l'opzione /str oppure ricompilare il progetto VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class TestResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TestResources() {
        }
        
        /// <summary>
        ///   Restituisce l'istanza di ResourceManager nella cache utilizzata da questa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("sacco_test.TestResources", typeof(TestResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Esegue l'override della proprietà CurrentUICulture del thread corrente per tutte le
        ///   ricerche di risorse eseguite utilizzando questa classe di risorse fortemente tipizzata.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a {&quot;height&quot;:&quot;0&quot;,&quot;result&quot;:{&quot;type&quot;:&quot;cosmos-sdk/Account&quot;,&quot;value&quot;:{&quot;address&quot;:&quot;&quot;,&quot;coins&quot;:[],&quot;public_key&quot;:null,&quot;account_number&quot;:&quot;0&quot;,&quot;sequence&quot;:&quot;0&quot;}}}.
        /// </summary>
        public static string AccountDataResponse {
            get {
                return ResourceManager.GetString("AccountDataResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a {
        ///  &quot;node_info&quot;: {
        ///    &quot;protocol_version&quot;: {
        ///      &quot;p2p&quot;: &quot;7&quot;,
        ///      &quot;block&quot;: &quot;10&quot;,
        ///      &quot;app&quot;: &quot;0&quot;
        ///    },
        ///    &quot;id&quot;: &quot;1e219e6878d07ddb875fe2732811107e002e236b&quot;,
        ///    &quot;listen_addr&quot;: &quot;tcp://0.0.0.0:26656&quot;,
        ///    &quot;network&quot;: &quot;cosmos-hub2&quot;,
        ///    &quot;version&quot;: &quot;0.32.2&quot;,
        ///    &quot;channels&quot;: &quot;4020212223303800&quot;,
        ///    &quot;moniker&quot;: &quot;edge&quot;,
        ///    &quot;other&quot;: {
        ///      &quot;tx_index&quot;: &quot;on&quot;,
        ///      &quot;rpc_address&quot;: &quot;tcp://0.0.0.0:26657&quot;
        ///    }
        ///  },
        ///  &quot;application_version&quot;: {
        ///    &quot;name&quot;: &quot;&quot;,
        ///    &quot;server_name&quot;: &quot;\u003cappd\u003e&quot;, [stringa troncata]&quot;;.
        /// </summary>
        public static string NodeInfoResponse {
            get {
                return ResourceManager.GetString("NodeInfoResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a {&quot;type&quot;:&quot;cosmos-sdk/StdTx&quot;,&quot;value&quot;:{&quot;msg&quot;:[{&quot;type&quot;:&quot;cosmos-sdk/MsgSend&quot;,&quot;value&quot;:{&quot;from_address&quot;:&quot;cosmos1huydeevpz37sd9snkgul6070mstupukw00xkw9&quot;,&quot;to_address&quot;:&quot;cosmos12lla7fg3hjd2zj6uvf4pqj7atx273klc487c5k&quot;,&quot;amount&quot;:[{&quot;amount&quot;:&quot;100&quot;,&quot;denom&quot;:&quot;uatom&quot;}]}}],&quot;fee&quot;:{&quot;amount&quot;:[],&quot;gas&quot;:&quot;200000&quot;},&quot;signatures&quot;:null,&quot;memo&quot;:&quot;&quot;}}.
        /// </summary>
        public static string SendStdTx {
            get {
                return ResourceManager.GetString("SendStdTx", resourceCulture);
            }
        }
    }
}
