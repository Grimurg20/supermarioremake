using GraphQL.Types;


namespace Veft.SuperMarioRemake.Api.Schema.InputTypes
{
    public class CharacterInput : InputObjectGraphType<CharacterInput>
    {
        public CharacterInput()
        {
            Field<StringGraphType>("id");
            Field(x => x.Name).Description("the name of the character");
            Field(x => x.Description).Description("The description of the character");
        }
    }
}