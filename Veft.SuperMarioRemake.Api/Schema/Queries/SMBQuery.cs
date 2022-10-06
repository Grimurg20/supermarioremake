using GraphQL.Types;
using Veft.SuperMarioRemake.Api.schema.Types;
using Veft.SuperMarioRemake.Api.Schema.Interfaces;
using Veft.SuperMarioRemake.Api.Data;
using Veft.SuperMarioRemake.Models.Interfaces;
using System;
using System.Runtime;

namespace Veft.SuperMarioRemake.Api.schema.Queries
{
    public class SMBQuery : ObjectGraphType
    {
        public SMBQuery(SMBData data)
        {
            Field<ListGraphType<EnemyInterface>>("allEnemies")
                .Resolve(context => {
                    var bosses = data.Bosses;
                    var CommonEnemies = data.Enemies;

                    return bosses.Concat<IEnemy>(CommonEnemies).Cast<IEnemy>();
                });

            Field<EnemyInterface>("Enemy")
                .Argument<StringGraphType>("id")
                .Resolve(context => 
                {
                    var bosses = data.Bosses;
                    var CommonEnemies = data.Enemies;
                    var enemies = bosses.Concat<IEnemy>(CommonEnemies).Cast<IEnemy>();
                    var idArgument = context.Arguments["id"].Value?.ToString();

                    return enemies.FirstOrDefault(e => e.Id == idArgument);
                });
            
            Field<ListGraphType<CommonEnemyType>>("allCommonEnemies")
                .Resolve(context => null);
            
            Field<ListGraphType<CharacterType>>("allCharacters")
                .Resolve(context => data.Characters);

            Field<ListGraphType<LevelType>>("allLevels")
                .ResolveAsync(async context => await data.GetLevels());
        
        }
    }
}