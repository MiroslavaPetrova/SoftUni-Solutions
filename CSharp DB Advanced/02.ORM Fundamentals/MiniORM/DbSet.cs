using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MiniORM
{
    public class DBSet<TEntity> : ICollection<TEntity>
        where TEntity : class, new ()
    {
        internal DBSet(IEnumerable<TEntity> entities)
        {
            this.Entities = entities.ToList();

            this.ChangeTracker = new ChangeTracker<TEntity>(entities); 
        }

        internal IList<TEntity> Entities { get; set; }

        internal ChangeTracker<TEntity> ChangeTracker { get; set; }

        public void Add(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item connot be null!");
            }
            this.Entities.Add(item);

            this.ChangeTracker.Add(item);
        }

        public bool Remove(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null!");
            }

            bool successfullyRemoved = this.Entities.Remove(item);

            if (successfullyRemoved)
            {
                this.ChangeTracker.Remove(item);
            }

            return successfullyRemoved;
        }

        public void Clear()             //TODO may occur a mistake
        {
            foreach (var entity in Entities)
            {
                this.ChangeTracker.Remove(entity);
            }

            this.Entities.Clear();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities.ToArray())
            {
                this.Remove(entity);
            }
        }

        public int Count => this.Entities.Count();

        public bool IsReadOnly => this.Entities.IsReadOnly;

        public bool Contains(TEntity item) => this.Entities.Contains(item);

        public void CopyTo(TEntity[] array, int arrayIndex) => this.Entities.CopyTo(array, arrayIndex);

        public IEnumerator<TEntity> GetEnumerator() => this.Entities.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}