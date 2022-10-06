using GraphQL.Types;
using Veft.SuperMarioRemake.Models.Models;

namespace Veft.SuperMarioRemake.Api.schema.Types
{
    public class CharacterType : ObjectGraphType<Character>
    {
        public CharacterType()
        {
            Field(x=> x.Id).Description("The id of the character ");
            Field(x=> x.Name).Description("The name of the character ");

            Field(x=> x.Description).Description("The description of the character ");


        }
    }
}