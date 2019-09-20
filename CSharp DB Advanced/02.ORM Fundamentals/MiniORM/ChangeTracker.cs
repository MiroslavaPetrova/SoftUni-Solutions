using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MiniORM
{
    internal class ChangeTracker<TEntity> where TEntity : class, new()
    {
        private readonly List<TEntity> allEntities;

        private readonly List<TEntity> added;

        private readonly List<TEntity> removed;

        public ChangeTracker(IEnumerable<TEntity> entities)
        {
            this.added = new List<TEntity>();

            this.removed = new List<TEntity>();

            this.allEntities = CloneEntities(entities);
        }

        public IReadOnlyCollection<TEntity> AllEntities => this.allEntities.AsReadOnly();

        public IReadOnlyCollection<TEntity> Added => this.added.AsReadOnly();

        public IReadOnlyCollection<TEntity> Removed => this.removed.AsReadOnly();

        private static List<TEntity> CloneEntities(IEnumerable<TEntity> entities)
        {
            var clonedEntities = new List<TEntity>();

            var propertiesToClone = typeof(TEntity).GetProperties()
                .Where(pi => AllowedSqlTypes.SqlTypes.Contains(pi.PropertyType))
                .ToArray();

            foreach (var entity in entities)
            {
                var clonedInstance = Activator.CreateInstance<TEntity>();

                foreach (var property in propertiesToClone)
                {
                    var initialValue = property.GetValue(entity);
                    property.SetValue(clonedInstance, initialValue);
                }

                clonedEntities.Add(clonedInstance);
            }
            return clonedEntities;
        }

        public void Add(TEntity item) => this.added.Add(item);

        public void Remove(TEntity item) => this.removed.Add(item);


        public IEnumerable<TEntity> GetModifiedEntities(DBSet<TEntity> dbSet)
        {
            var modifiedEntities = new List<TEntity>();

            var primaryKeys = typeof(TEntity).GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (var proxyEntity in AllEntities)
            {
                var primaryKeyValues = GetPrimaryKeyValues(primaryKeys, proxyEntity).ToArray();

                var entity = dbSet.Entities.Single(e =>
                    GetPrimaryKeyValues(primaryKeys, e).SequenceEqual(primaryKeyValues));

                var isModified = IsModified(proxyEntity, entity);
                if (isModified)
                {
                    modifiedEntities.Add(entity);
                }
            }

            return modifiedEntities;
        }

        private static bool IsModified(TEntity entity, TEntity proxyEntity)
        {
            var monitoredProperties = typeof(TEntity).GetProperties()
                .Where(pi => AllowedSqlTypes.SqlTypes.Contains(pi.PropertyType));


            /// e.g. Go through all properties of the Employee class;
            /// Take FirstName value of entity and compare it to FirstName value of clonedEntity
            /// If there is any difference, we have modification.
            /// Then go on with every other value of the monitored properties,
            /// e.g. LastName, Salary, Address, Age and save the changed ones in modifiedProperties.

            var modifiedProperties = monitoredProperties
                .Where(pi => !Equals(pi.GetValue(entity), pi.GetValue(proxyEntity)))
                .ToArray();

            return modifiedProperties.Any();
        }
        public IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, TEntity entity)
        {
            var primaryKeyProperties = primaryKeys
                .Select(pi => pi.GetValue(entity));

            return primaryKeyProperties; // let's say the values of all Ids of the Employee class
        }
    }
}
