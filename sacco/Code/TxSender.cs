﻿// 
// sacco - Base Library for Commercio Network
//
// Riccardo Costacurta
// Dec. 2, 2019
// BlockIt s.r.l.
// 
/// Broadcasts the given [stdTx] using the info contained
/// inside the given [wallet].
/// Returns the hash of the transaction once it has been send, or throws an
/// exception if an error is risen during the sending.
//
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;

namespace commercio.sacco.lib
{
    public class TxSender
    {
        #region Instance Variables

        // Use static HttpClient to avoid exhausting system resources for network connections.
        private static HttpClient client = new HttpClient();

        #endregion

        #region Properties

        #endregion

        #region Constructors

        #endregion

        #region Public Methods
        /// *** This is ported from Dart Future to C# Task<TResult> 
        /// *** The usage of the class should be mantained - to be checked
        public static async Task<TransactionResult> broadcastStdTx(Wallet wallet, StdTx stdTx, String mode = "sync")
        {
            // Get the endpoint
            String apiUrl = $"{wallet.networkInfo.lcdUrl}/txs";

            // Build the request body
            Dictionary<String, Object> requestBody = new Dictionary<String, Object>
            {
                { "tx", stdTx.toJson() },
                { "mode", mode}
            };
            String payload = JsonConvert.SerializeObject(requestBody);
            Debug.WriteLine($"****** Payload: {payload}");

            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            // Get the server response
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                System.ArgumentException argEx = new System.ArgumentException($"Expected status code OK (200) but got ${response.StatusCode} - ${response.ReasonPhrase} - ${response.Content}");
                throw argEx;
            }

            // Convert the response
            String encodedJson = await response.Content.ReadAsStringAsync();
            Debug.WriteLine($"******+++++++ encodedJson: {encodedJson}");
            Dictionary<String, Object> json = JsonConvert.DeserializeObject<Dictionary<String, Object>>(encodedJson);
            return _convertJson(json);
        }

        #endregion

        #region Helpers

        /// Converts the given [json] to a [TransactionResult] object.
        private static TransactionResult _convertJson(Dictionary<String, Object> json)
        {
            Object outValue, jsonRawLog;
            List<Object> ListRawLog;
            Dictionary<String, Object> rawlog;
            Boolean successResult;
            String message, hash, rawString;

            if (json.TryGetValue("raw_log", out jsonRawLog))
            {
                // Debug.WriteLine($"****** jsonRawLog: {jsonRawLog}");
            
                // Try to undestand the transaction result
                int errCode = 0;       // Mark an OK by default
                successResult = true;
                message = "No Message Reported";
                hash = "";
                if (json.TryGetValue("txhash", out outValue))
                    hash = outValue as String;
                if (json.TryGetValue("code", out outValue))
                {
                    errCode = Convert.ToInt32(outValue);   // 20200217 - Careful here - the errorcode returned is a 64bit integer!
                    // Be sure to report a success = false if there is an eror code
                    if (errCode != 0)
                        successResult = false;
                }
                // 20200217 - Get the details about the error
                try
                {
                    rawlog = new Dictionary<String, Object>();
                    rawString = jsonRawLog.ToString();
                    if ((rawString[0] == '{') && (rawString.IndexOf("message") != -1))
                    {
                        try
                        {
                            // First Try - Assume we have just a single rawlog
                            rawlog = JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonRawLog.ToString());
                            // Debug.WriteLine("****** Errcode != 0, Deserialize in a dictionary OK");
                        }
                        catch
                        {
                            // Second try - we have a list of rawlogs
                            ListRawLog = JsonConvert.DeserializeObject<List<Object>>(jsonRawLog as string);
                            // Get the first element of the list
                            rawlog = JsonConvert.DeserializeObject<Dictionary<String, Object>>(ListRawLog[0].ToString());
                            // Debug.WriteLine("****** Errcode != 0, Exception in deserialize a Dictionary, Deserialize in a list OK");
                        }
                        // Here we get the details of the message
                        if (rawlog.TryGetValue("message", out outValue))
                            message = outValue as String;
                        if (rawlog.TryGetValue("success", out outValue))
                            successResult = (Boolean)outValue;
                    }
                    else
                    {
                        // We have just a string - if not empty it's an error...
                        message = rawString;
                        // Keep the OK result by default
                    }
                }
                catch
                {
                    // Here if we have a failure in decoding json
                    message = $"Internal error - unable to decode message result - '${jsonRawLog.ToString()}'";
                    successResult = false;
                }
                // Debug.WriteLine($"****** Message: {message}");
                return new TransactionResult(
                    hash: hash,
                    success: successResult,
                    error: new TransactionError(
                        errorCode: errCode,
                        errorMessage: message
                    )
                );
            }
            else
            {
                // Otherwise, result OK
                hash = "";
                if (json.TryGetValue("txhash", out outValue))
                    hash = outValue as String;
                return new TransactionResult(
                    hash: hash,
                    success: true,
                    error: null
                );
            }
        }


        #endregion

    }
}
