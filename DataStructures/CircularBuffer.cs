using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class CircularBuffer<T>  : Buffer<T>
    {
        int _capacity;
        public CircularBuffer(int capacity = 10)
        {
            _capacity = capacity;
        }

        public override void Write(T value)
        {
            base.Write(value);
            if (_queue.Count > _capacity)
            {

                var discard = _queue.Dequeue();

                OneItemDiscarded(discard, value);
            }
        }

        private void OneItemDiscarded(T discard, T value)
        {
            if (ItemDiscarded != null)
            {
                var args = new ItemDiscardedEventArgs<T>(discard, value);
                ItemDiscarded(this, args);
            }
        }

        public event EventHandler<ItemDiscardedEventArgs<T>> ItemDiscarded;

        public bool IsFull { get { return _queue.Count == _capacity; } }

    }

    public class ItemDiscardedEventArgs<T> : EventArgs
    {
        public T ItemDiscarded { get; set; }
        public T NewItem { get; set; }

        public ItemDiscardedEventArgs(T itemDiscarded, T newItem)
        {
            ItemDiscarded = itemDiscarded;
            NewItem = newItem;
        }
    }
}
