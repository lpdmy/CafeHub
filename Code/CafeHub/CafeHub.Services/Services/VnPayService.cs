﻿using Azure.Core;
using CafeHub.Commons.Models;
using CafeHub.Services.Interfaces;
using CafeHub.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Services.Services
{
    public class VnPayService : IVnPayService
    {
        private readonly IConfiguration _configuration;
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly INotificationService _notificationService;

        public VnPayService(
            IConfiguration configuration,
            IOrderService orderService,
            IPaymentService paymentService,
            IHttpContextAccessor httpContextAccessor,
            INotificationService notificationService)
        {
            _configuration = configuration;
            _orderService = orderService;
            _paymentService = paymentService;
            _httpContextAccessor = httpContextAccessor;
            _notificationService = notificationService;
        }

        public async Task<string> GetPaymentUrl(int orderId)
        {
            var order = await _orderService.GetOrderDetailsAsync(orderId);
            if (order == null) throw new Exception("Order not found");

            string vnp_Url = _configuration["VNPay:vnp_Url"];
            string vnp_HashSecret = _configuration["VNPay:vnp_HashSecret"];
            string vnp_TmnCode = _configuration["VNPay:vnp_TmnCode"];
            string vnp_Returnurl = _configuration["VNPay:vnp_Returnurl"];

            VnPayLibrary vnpay = new VnPayLibrary();
            vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", ((int)(order.TotalAmount * 100)).ToString());
            vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(_httpContextAccessor));
            vnpay.AddRequestData("vnp_Locale", "vn");
            vnpay.AddRequestData("vnp_OrderInfo", $"Thanh toan don hang: {orderId}");
            vnpay.AddRequestData("vnp_OrderType", "other");
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_TxnRef", orderId.ToString());

            return vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
        }

        public async Task<string> ProcessPaymentResponse(IQueryCollection queryCollection, string returnUrl)
        {
            VnPayLibrary vnpay = new VnPayLibrary();
            foreach (var key in queryCollection.Keys)
            {
                vnpay.AddResponseData(key, queryCollection[key]);
            }

            string vnp_HashSecret = _configuration["VNPay:vnp_HashSecret"];
            string vnp_TxnRef = vnpay.GetResponseData("vnp_TxnRef");
            string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            string vnp_SecureHash = vnpay.GetResponseData("vnp_SecureHash");

            if (!vnpay.ValidateSignature(vnp_SecureHash, vnp_HashSecret))
            {
                return "Invalid signature!";
            }

            var order = await _orderService.GetOrderDetailsAsync(int.Parse(vnp_TxnRef));
            if (order == null)
            {
                return "Order not found!";
            }

            if (vnp_ResponseCode == "00")
            {
                order.Status = "Paid";

                await _paymentService.CreatePaymentAsync(new Payment
                {
                    OrderId = order.Id,
                    AmountPaid = order.TotalAmount,
                    PaymentMethod = "VNPAY",
                    PaymentDate = DateTime.UtcNow
                });

                // Notify staff when payment is successful
                await _notificationService.SendNotificationToStaff(
                    "New Order Payment",
                    $"Order #{order.Id} has been successfully paid via VNPay.",
                    returnUrl
                );

                return "Payment successful!";
            }
            else
            {
                order.Status = "Failed";

                // Notify staff when payment fails
                await _notificationService.SendNotificationToStaff(
                    "Payment Failed",
                    $"Order #{order.Id} payment via VNPay failed. Please check and contact the customer if necessary.",
                    returnUrl
                );

                return "Payment failed. Please try again.";
            }

        }
    }
}




