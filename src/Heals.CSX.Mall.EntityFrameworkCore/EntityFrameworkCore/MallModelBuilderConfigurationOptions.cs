using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Heals.CSX.Mall.EntityFrameworkCore
{
    public class MallModelBuilderConfigurationOptions
    : AbpModelBuilderConfigurationOptions
    {
        public MallModelBuilderConfigurationOptions(
            string tablePrefix = MallConsts.DbTablePrefix,
            string schema = MallConsts.DbSchema) : base(tablePrefix, schema)
        {
        }
    }
}
