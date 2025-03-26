using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Stripe;

namespace BusinessLayer.Service.Payment
{
  public  class PaymentManager
    {

        //private readonly StripeSettings _stripeSettings;

        //public PaymentManager(IOptions<StripeSettings> stripeSettings)
        //{
        //    _stripeSettings = stripeSettings.Value;
        //    StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
        //}

        //public string ProcessPayment(string stripeToken)
        //{
        //    var options = new ChargeCreateOptions
        //    {
        //        Amount = 50,
        //        Currency = "usd",
        //        Description = "Sample Charge",
        //        Source = stripeToken,
        //    };

        //    var service = new ChargeService();
        //    Charge charge = service.Create(options);

        //    return charge.Id;
        //}

        public async Task<PaymentResult> ProcessPayment(string paymentToken, int amount =20)
        {
            // Step 1: Configure Stripe
            StripeConfiguration.ApiKey = "sk_test_51R40K2K0i4ouTtOMJUqnSovmijOjGf5hVnxNY6FtCil3Dv5zx6kPwbaR7II6AMeNFlMZhVQAWqdFNR3zn59D7cDP001EwLibdN";

            // Step 2: Create the payment charge options
            var options = new ChargeCreateOptions
            {
                Amount = 2000, // Payment amount in cents
                Currency = "usd",
                Description = "Order Payment",
                Source = paymentToken, // Stripe token from the client
            };

            // Step 3: Execute the payment
            var service = new ChargeService();
            try
            {
                var charge = await service.CreateAsync(options);

                // Return success if payment is successful
                return new PaymentResult
                {
                    Success = charge.Status == "succeeded",
                    ChargeId = charge.Id
                };
            }
            catch (Exception ex)
            {
                // Log the exception and return failure
                Console.WriteLine(ex.Message);
                return new PaymentResult { Success = false };
            }
        }

    }

    }
