using GraphQL.Types;
using Veft.SuperMarioRemake.Models.Models;
using Veft.SuperMarioRemake.Api.Schema.Interfaces;
using Veft.SuperMarioRemake.Api.Data;
using System.Linq;



namespace Veft.SuperMarioRemake.Api.schema.Types
{
    public class BossEnemyType : ObjectGraphType<BossEnemy>
    {
        public BossEnemyType(SMBData data)
        {
            Field(x => x.Id).Description("the id of the boss enemy");
            Field(x => x.Name).Description("the Name of the boss enemy");
            Field(x => x.Health).Description("the Health of the boss enemy");
            Field<LevelType>("appearsInLevel")
                .ResolveAsync(async context => {
                    var levels = await data.GetLevels();

                    return levels.FirstOrDefault(l => l.Id == context.Source.AppearsInLevelId);

                });
            Field<ListGraphType<NonNullGraphType<LevelType>>>("unlocksLevels")
                .ResolveAsync(async context => {

                        var levels = await data.GetLevels();
                        var bossUnlocksLevels = data.UnlockLevels.Where(l => l.EnemyId == context.Source.Id);
                        return levels.Where(l => bossUnlocksLevels.Any(b => b.LevelId == l.Id));

    

                 });

            Interface<EnemyInterface>();
            IsTypeOf = obj => obj is BossEnemy;
        }
    }
}