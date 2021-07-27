using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[5];
            var list = new List<int>();
            var linkedList = new LinkedList<int>();
            var queue = new Queue<int>();
            var stack = new Stack<int>();
            var hashSet = new HashSet<int>();
            var hashTable = new Dictionary<string, int>();

            var hasDuplicates = CheckHasDuplicated(new[] { "a", "b", "c", "d", "a", "e" }); //true

            Console.WriteLine("Hello World!");
        }

        private static bool CheckHasDuplicated<T>(T[] collection)
        {
            var hashSet = new HashSet<T>(collection);
            return hashSet.Count == collection.Length;
        }

        // merge entities and details by ids to have one composite object with all related data
        private static IEnumerable<MergedEntity> MergeEntities(Entity[] entities, EntityDetails[] details)
        {
            return entities.Join(
                details,
                x => x.Id,
                y => y.Id,
                (x, y) => new MergedEntity { Id = x.Id, Name = x.Name, Details = y.Details });

            //var list = new LinkedList<MergedEntity>();
            //var dictionary = entities
            //    .Select(x => new MergedEntity { Id = x.Id, Name = x.Name })
            //    .ToDictionary(x => x.Id);

            //foreach (var detail in details)
            //{
            //    if (dictionary.TryGetValue(detail.Id, out var value))
            //    {
            //        value.Details = detail.Details;
            //    }
            //}

            //return dictionary.Select(x => x.Value);

            //foreach (var entity in entities)
            //{
            //    var detail = details.First(x => x.Id == entity.Id);
            //    list.AddLast(new MergedEntity
            //    {
            //        Id = entity.Id,
            //        Name = entity.Name,
            //        Details = detail.Details
            //    });
            //}
            /*for (int i = 0; i<entities.Length || i < details.Length; i++)
            {
                list.AddLast(new MergedEntity
                {
                    Id = entities[i].Id,
                    Name = entities[i].Name,
                    Details = details[i].Details
                });
            }*/

            return list;
        }

        // should set Name property for all entities to "uniqueName"
        private static IEnumerable<MergedEntity> SetEntitiesName(MergedEntity[] entities)
        {
            foreach (var entity in entities)
            {
                entity.Name = "uniqueName";
            }

            return entities;
        }

        // should return all entities which has given name
        private static IEnumerable<MergedEntity> FilterEntitiesByName(MergedEntity[] entities, string name)
        {
            var list = new LinkedList<MergedEntity>();

            foreach (var entity in entities)
            {
                if (entity.Name == name)
                {
                    list.AddLast(entity);
                }
            }

            return list;
        }

        private static IEnumerable<MergedEntity> FilterEntitiesByName(MergedEntity[] entities, string name)
        {
            return entities.Where(x => x.Name == name);
        }
    }

    class Entity
    {
        public string Id { get;  set; }
        public string Name { get; set; }
    }

    class EntityDetails
    {
        public string Id { get; set; }
        public string Details { get; set; }
    }

    class MergedEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
    }

}
