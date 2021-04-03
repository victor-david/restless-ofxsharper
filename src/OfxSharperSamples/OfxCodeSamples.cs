using Restless.OfxSharper.Builder;
using Restless.OfxSharper.Core;
using Restless.OfxSharper.Profile;
using Restless.OfxSharper.Statement;
using System;

namespace Restless.OfxSharper.Samples
{
    /// <summary>
    /// Provides example code on using the Ofx library. Included here to ensure they compile correctly.
    /// </summary>
    public class OfxCodeSamples
    {
        public void OfxProfileExample()
        {
            // You need to get your own bank details into an IBank object.
            IBank bank = GetMyBankInfo();

            var builder = OfxFactory.Builder.Create();

            builder.BuildOfxRequest(() =>
            {
                builder.Signon.BuildMessageSet(bank);
                builder.Profile.BuildMessageSet();
            });

            // Send request to the bank and get the response
            string response = GetResponseFromBank(builder.RequestText);
            // Transform response string. Ready to go.
            OfxProfileResponse profile = OfxFactory.ProfileResponse.Create(response);
            // Do something.
            if (profile.BillPay.CanAddPayee)
            {
            }
        }

        public void BankStatementDownload()
        {
            // You need to get your own bank details into an IBank object.
            IBank bank = GetMyBankInfo();
            // You need to get your own account details into an IAccount object.
            IAccount account = GetMyAccountInfo();

            OfxRequestBuilder builder = OfxFactory.Builder.Create();
            builder.BuildOfxRequest(() =>
            {
                builder.Signon.BuildMessageSet(bank);

                builder.Bank.BuildMessageSet(() =>
                {
                    // in your app, you'd have to determine an appropiate date to start with.
                    DateTime fromDate = new DateTime(2018, 1, 1);
                    builder.Bank.BuildStatementRequest(account, fromDate, null, true);
                    // add another statement request if you've got another account at the same bank
                });
            });

            // Send request to the bank and get the response
            string response = GetResponseFromBank(builder.RequestText);

            // Transform response string. Ready to go.
            OfxResponse ofx = OfxFactory.Response.Create(response);
        }

        public void CreditCardStatementDownload()
        {
            // You need to get your own bank details into an IBank object.
            IBank bank = GetMyBankInfo();
            // You need to get your own account details into an IAccount object.
            IAccount account = GetMyAccountInfo();

            OfxRequestBuilder builder = OfxFactory.Builder.Create();
            builder.BuildOfxRequest(() =>
            {
                builder.Signon.BuildMessageSet(bank);

                builder.CreditCard.BuildMessageSet(() =>
                {
                    // in your app, you'd have to determine an appropiate date to start with
                    DateTime dateStart = new DateTime(2018, 1, 1);
                    builder.CreditCard.BuildStatementRequest(account, dateStart, null, true);
                    // Not using a start date or an end date. Bank will deliver whatever they've got.
                    builder.CreditCard.BuildClosingStatementRequest(account, null, null);
                });
            });

            // Send request to the bank and get the response
            string response = GetResponseFromBank(builder.RequestText);

            // Transform response string. Ready to go.
            OfxResponse ofx = OfxFactory.Response.Create(response);
            if (ofx.Bank.Statements.Count == 1)
            {
                foreach (var closingPeriod in ((CreditCardStatement)ofx.Bank.Statements[0]).Closing.Periods)
                {
                    // do something
                }
            }
        }

        public void BankAndCreditCardStatementDownload()
        {
            // You need to get your own bank details into an IBank object.
            IBank bank = GetMyBankInfo();
            // You need to get your own account details into an IAccount object.
            IAccount bankAccount = GetMyAccountInfo();
            IAccount creditCardAccount = GetMyAccountInfo();

            OfxRequestBuilder builder = OfxFactory.Builder.Create();
            builder.BuildOfxRequest(() =>
            {
                builder.Signon.BuildMessageSet(bank);

                builder.Bank.BuildMessageSet(() =>
                {
                    // in your app, you'd have to determine an appropiate date to start with.
                    DateTime fromDate = new DateTime(2018, 1, 1);
                    builder.Bank.BuildStatementRequest(bankAccount, fromDate, null, true);
                });

                builder.CreditCard.BuildMessageSet(() =>
                {
                    // in your app, you'd have to determine an appropiate date to start with
                    DateTime dateStart = new DateTime(2018, 1, 1);
                    builder.CreditCard.BuildStatementRequest(creditCardAccount, dateStart, null, true);
                    // Not using a start date or an end date. Bank will deliver whatever they've got.
                    builder.CreditCard.BuildClosingStatementRequest(creditCardAccount, null, null);
                });
            });

            // Send request to the bank and get the response
            string response = GetResponseFromBank(builder.RequestText);

            // Transform response string. Ready to go.
            OfxResponse ofx = OfxFactory.Response.Create(response);
            foreach (var statement in ofx.Bank.Statements)
            {
                if (statement.StatementType == StatementType.Bank)
                {
                    // do something
                }
                if (statement.StatementType == StatementType.CreditCard)
                {
                    // do something
                }
            }
        }

        public IBank GetMyBankInfo()
        {
            return null;
        }

        public IAccount GetMyAccountInfo()
        {
            return null;
        }

        public string GetResponseFromBank(string request)
        {
            return String.Empty;
        }
    }
}
