﻿namespace MyProject.Application.UseCases.GetCustomerDetails
{
    using System.Threading.Tasks;
    using MyProject.Application.Outputs;
    using MyProject.Application.Repositories;
    using MyProject.Domain.Customers;
    using MyProject.Domain.Accounts;
    using System.Collections.Generic;

    public class GetCustomerDetailsInteractor : IInputBoundary<GetCustomerDetailsInput>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IOutputBoundary<CustomerOutput> outputBoundary;
        private readonly IOutputConverter responseConverter;

        public GetCustomerDetailsInteractor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IOutputBoundary<CustomerOutput> outputBoundary,
            IOutputConverter responseConverter)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Process(GetCustomerDetailsInput input)
        {
            //
            // TODO: The following queries could be simplified
            //

            Customer customer = await customerReadOnlyRepository.Get(input.CustomerId);
			
			if (customer == null)
                throw new CustomerNotFoundException($"The customer {input.CustomerId} does not exists.");

            List<AccountOutput> accounts = new List<AccountOutput>();

            foreach (var accountId in customer.Accounts)
            {
                Account account = await accountReadOnlyRepository.Get(accountId);

                //
                // TODO: The "Accout closed state" is not propagating to the Customer Aggregate
                //

                if (account != null)
                {
                    AccountOutput accountOutput = responseConverter.Map<AccountOutput>(account);
                    accounts.Add(accountOutput);
                }
            }

            CustomerOutput output = responseConverter.Map<CustomerOutput>(customer);

            output = new CustomerOutput(
                customer.Id,
                customer.PIN.Text, 
                customer.Name.Text, 
                accounts);

            outputBoundary.Populate(output);
        }
    }
}