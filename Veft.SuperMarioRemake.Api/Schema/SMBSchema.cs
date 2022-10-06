using Veft.SuperMarioRemake.Api.schema.Queries;
using Veft.SuperMarioRemake.Api.Schema.Mutations;
using Veft.SuperMarioRemake.Api.Schema.InputTypes;
using Veft.SuperMarioRemake.Api.schema.Types;
using System.ComponentModel;
using System;

namespace Veft.SuperMarioRemake.Api.Schema
{
    public class SMBSchema : GraphQL.Types.Schema
    {
        public SMBSchema(IServiceProvider serivceProvider) : base(serivceProvider)
        {
            Query = serivceProvider.GetRequiredService<SMBQuery>();
            Mutation = serivceProvider.GetRequiredService<SMBMutation>();
            
            // RegisterType<CharacterInput>();
            RegisterType(typeof(BossEnemyType));
            RegisterType(typeof(CommonEnemyType));
        }
    }
}