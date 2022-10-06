using GraphQL.Types;
using Veft.SuperMarioRemake.Models.Models;

namespace Veft.SuperMarioRemake.Api.schema.Types
{
    public class LevelType: ObjectGraphType<Level>
    {
        public LevelType()
        {
            Field(x => x.Id).Description("The id of level");
        }


    }
}