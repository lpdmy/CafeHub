﻿using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace CafeHub.Services.Models
{
    //public class VnPayLibrary
    //{
    //    private readonly SortedList<string, string> _requestData = new();
    //    private readonly SortedList<string, string> _responseData = new();

    //    public void AddRequestData(string key, string value)
    //    {
    //        if (!string.IsNullOrEmpty(value))
    //            _requestData.Add(key, value);
    //    }

    //    public void AddResponseData(string key, string value)
    //    {
    //        if (!string.IsNullOrEmpty(value))
    //            _responseData.Add(key, value);
    //    }
    //    private string BuildData(SortedList<string, string> data)
    //    {
    //        var query = new StringBuilder();
    //        foreach (var kv in data)
    //        {
    //            query.Append($"{kv.Key}={kv.Value}&");
    //        }
    //        return query.ToString().TrimEnd('&');
    //    }

    //    private string BuildQuery(SortedList<string, string> data)
    //    {
    //        var query = new StringBuilder();
    //        foreach (var kv in data)
    //        {
    //            query.Append($"{WebUtility.UrlEncode(kv.Key)}={WebUtility.UrlEncode(kv.Value)}&");
    //        }
    //        return query.ToString().TrimEnd('&');
    //    }


    //    public string CreateRequestUrl(string baseUrl, string hashSecret)
    //    {
    //        var signData = BuildData(_requestData);
    //        var signature = HmacSHA512(hashSecret, signData);
    //        var query = BuildQuery(_requestData);
    //        return $"{baseUrl}?{query}&vnp_SecureHash={signature}";
    //    }

    //    public bool ValidateSignature(string hashSecret)
    //    {
    //        if (!_responseData.ContainsKey("vnp_SecureHash"))
    //            return false;

    //        var secureHash = _responseData["vnp_SecureHash"];
    //        _responseData.Remove("vnp_SecureHash");
    //        _responseData.Remove("vnp_SecureHashType"); // Bạn đã thêm rồi

    //        var signData = BuildData(_responseData);
    //        var checkHash = HmacSHA512(hashSecret, signData);

    //        return secureHash.Equals(checkHash, StringComparison.OrdinalIgnoreCase);
    //    }


    //    private string HmacSHA512(string key, string inputData)
    //    {
    //        using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(key));
    //        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(inputData));
    //        return BitConverter.ToString(hash).Replace("-", "").ToLower();
    //    }
    //}

    public class VnPayLibrary
    {
        public const string VERSION = "2.1.0";
        private SortedList<String, String> _requestData = new SortedList<String, String>(new VnPayCompare());
        private SortedList<String, String> _responseData = new SortedList<String, String>(new VnPayCompare());
      

        public void AddRequestData(string key, string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                _requestData.Add(key, value);
            }
        }

        public void AddResponseData(string key, string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                _responseData.Add(key, value);
            }
        }

        public string GetResponseData(string key)
        {
            string retValue;
            if (_responseData.TryGetValue(key, out retValue))
            {
                return retValue;
            }
            else
            {
                return string.Empty;
            }
        }

        #region Request

        public string CreateRequestUrl(string baseUrl, string vnp_HashSecret)
        {
            StringBuilder data = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in _requestData)
            {
                if (!String.IsNullOrEmpty(kv.Value))
                {
                    data.Append(WebUtility.UrlEncode(kv.Key) + "=" + WebUtility.UrlEncode(kv.Value) + "&");
                }
            }
            string queryString = data.ToString();

            baseUrl += "?" + queryString;
            String signData = queryString;
            if (signData.Length > 0)
            {

                signData = signData.Remove(data.Length - 1, 1);
            }
            string vnp_SecureHash = Utils.HmacSHA512(vnp_HashSecret, signData);
            baseUrl += "vnp_SecureHash=" + vnp_SecureHash;

            return baseUrl;
        }



        #endregion

        #region Response process

        public bool ValidateSignature(string inputHash, string secretKey)
        {
            string rspRaw = GetResponseData();
            string myChecksum = Utils.HmacSHA512(secretKey, rspRaw);
            return myChecksum.Equals(inputHash, StringComparison.InvariantCultureIgnoreCase);
        }
        private string GetResponseData()
        {

            StringBuilder data = new StringBuilder();
            if (_responseData.ContainsKey("vnp_SecureHashType"))
            {
                _responseData.Remove("vnp_SecureHashType");
            }
            if (_responseData.ContainsKey("vnp_SecureHash"))
            {
                _responseData.Remove("vnp_SecureHash");
            }
            foreach (KeyValuePair<string, string> kv in _responseData)
            {
                if (!String.IsNullOrEmpty(kv.Value))
                {
                    data.Append(WebUtility.UrlEncode(kv.Key) + "=" + WebUtility.UrlEncode(kv.Value) + "&");
                }
            }
            //remove last '&'
            if (data.Length > 0)
            {
                data.Remove(data.Length - 1, 1);
            }
            return data.ToString();
        }

        #endregion
    }

    public static class Utils
    {
        public static string HmacSHA512(string key, string inputData)
        {
            var hash = new StringBuilder();
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputData);
            using (var hmac = new HMACSHA512(keyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(inputBytes);
                foreach (var theByte in hashValue)
                {
                    hash.Append(theByte.ToString("x2"));
                }
            }
            return hash.ToString();
        }

        public static string GetIpAddress(IHttpContextAccessor httpContextAccessor)
        {
            try
            {
                var context = httpContextAccessor.HttpContext;
                if (context == null)
                    return "Unknown IP";

                var ipAddress = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();

                if (string.IsNullOrEmpty(ipAddress) || ipAddress.Equals("unknown", StringComparison.OrdinalIgnoreCase))
                    ipAddress = context.Connection.RemoteIpAddress?.ToString();

                return ipAddress ?? "Unknown IP";
            }
            catch (Exception ex)
            {
                return "Invalid IP: " + ex.Message;
            }
        }
    }


    public class VnPayCompare : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == y) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            var vnpCompare = CompareInfo.GetCompareInfo("en-US");
            return vnpCompare.Compare(x, y, CompareOptions.Ordinal);
        }
    }
}
