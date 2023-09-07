using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using Quiz.Domain.Common;

namespace Quiz.API
{
    public static class GlobalMongoRegistration
    {
        public static void Register()
        {
            var pack = new ConventionPack();
            pack.Add(new CamelCaseElementNameConvention());

            ConventionRegistry.Register(
               "CamelCase",
               pack,
               t => true);


            BsonClassMap.RegisterClassMap<EntityBase>(cm => {
                cm.AutoMap();
                cm.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId)).SetIdGenerator(StringObjectIdGenerator.Instance);
                cm.SetIsRootClass(true);
                cm.SetIgnoreExtraElements(true);
                cm.SetIgnoreExtraElementsIsInherited(true);
            });
       
        }
    }
}
