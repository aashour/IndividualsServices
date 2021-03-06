﻿using Tamkeen.IndividualsServices.Core.Data;
using System;

namespace Tamkeen.IndividualsServices.Data
{
    public partial class EfDataProviderManager : BaseDataProviderManager
    {
        public EfDataProviderManager(DataSettings settings)
            : base(settings)
        {
        }

        public override IDataProvider LoadDataProvider()
        {

            var providerName = Settings.DataProvider;
            if (String.IsNullOrWhiteSpace(providerName))
                throw new InvalidOperationException("Data Settings doesn't contain a providerName");

            switch (providerName.ToLowerInvariant())
            {
                case "sqlserver":
                    return new SqlServerDataProvider();
                default:
                    throw new InvalidOperationException(string.Format("Not supported dataprovider name: {0}", providerName));
            }
        }

    }
}
