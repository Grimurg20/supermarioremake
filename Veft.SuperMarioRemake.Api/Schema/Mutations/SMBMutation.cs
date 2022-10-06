using GraphQL.Types;
using Veft.SuperMarioRemake.Api.schema.Types;
using Veft.SuperMarioRemake.Api.Schema.InputTypes;
using Veft.SuperMarioRemake.Api.Data;
using Veft.SuperMarioRemake.Models.Models;

namespace Veft.SuperMarioRemake.Api.Schema.Mutations
{
    public class SMBMutation : ObjectGraphType
    {
        public SMBMutation(SMBData data)
        {
            // Field<CharacterType>("createCharacter")
            //     .Argument<CharacterInput>("character")
            //     .Resolve(context => null);

            Field<CharacterType>("createCharacter")
                .Argument<StringGraphType>("name")
                .Argument<StringGraphType>("description")
                .Resolve(context => {
                    var name = context.Arguments["name"].Value?.ToString();
                    var description = context.Arguments["description"].Value?.ToString();
                    var id = name.Replace(" ", "-").ToLower();
                    var character = new Character 
                    {
                        Id = id,
                        Name = name,
                        Description = description
                    };

                    data.Characters.Add(character);

                    return character;
                    
                });
        
            
            Field<CharacterType>("updateCharacter")
                .Argument<StringGraphType>("id")
                .Argument<StringGraphType>("description")
                .Resolve(context => {
                    var id = context.Arguments["id"].Value?.ToString();
                    var description = context.Arguments["description"].Value?.ToString();

                    var character = data.Characters.FirstOrDefault(c => c.Id == id);

                    if(character == null) {throw new System.Exception("the Character does not exist");}

                    character.Description = description;

                    return character;
                });




            Field<BooleanGraphType>("deleteCharacter")
                .Argument<StringGraphType>("id")
                .Resolve(context => {
                    var id = context.Arguments["id"].Value?.ToString();
                    data.Characters.RemoveAll(c => c.Id == id);
                    return true;

                });
        }
    }
}