using GraphQL.Types;
using Veft.SuperMarioRemake.Models.Interfaces;

namespace Veft.SuperMarioRemake.Api.Schema.Interfaces
{
    public class EnemyInterface : InterfaceGraphType<IEnemy>
    {
        public EnemyInterface()
        {
            Field(x => x.Id).Description("the id of the enemy");
            Field(x => x.Name).Description("the Name of the enemy");
            Field(x => x.Health).Description("the Health of the enemy");
        }
    }
}