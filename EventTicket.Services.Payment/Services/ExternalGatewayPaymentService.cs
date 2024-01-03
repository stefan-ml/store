﻿using EventTicket.Services.Payment.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace EventTicket.Services.Payment.Services
{
    public class ExternalGatewayPaymentService : IExternalGatewayPaymentService
    {
        private readonly HttpClient client;
        private readonly IConfiguration configuration;


        public ExternalGatewayPaymentService(HttpClient client, IConfiguration configuration)
        {
            this.client = client;
            this.configuration = configuration;
        }

        public async Task<bool> PerformPayment(PaymentInfo paymentInfo)
        {
            var dataAsString = JsonSerializer.Serialize(paymentInfo);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(configuration.GetValue<string>("ApiConfigs:ExternalPaymentGateway:Uri") + "/api/paymentapprover", content);

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<bool>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        }
    }
}
