using GraphQL.Types;
using Veft.SuperMarioRemake.Models.Models;
using Veft.SuperMarioRemake.Api.Schema.Interfaces;

namespace Veft.SuperMarioRemake.Api.schema.Types
{
    public class CommonEnemyType : ObjectGraphType<CommonEnemy>
    {
       
        public CommonEnemyType()
        {
            Field(x => x.Id).Description("The id of the common enemy");
            Field(x => x.Name).Description("The Name of the common enemy");
            Field(x => x.Health).Description("The Health of the common enemy");
            Field(x => x.EnemySize).Description("The Enemy size of the common enemy");

            Interface<EnemyInterface>();
            IsTypeOf = obj => obj is CommonEnemy;


        }
        
    }
}