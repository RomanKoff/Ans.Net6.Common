﻿using System.Collections.Generic;

namespace Ans.Net6.Common
{

    public interface ITreeProvider<T>
    {
        List<T> All { get; set; }
        T Root { get; set; }
        T GetItem(int key);
        T GetItem(string key);
        void Refresh();
        void ItemRelease(T item);
        void SetTree(T root, bool genIds);
        void SetList(ICollection<T> items);
    }



    public abstract class __TreeProvider_Proto<T>
       : ITreeProvider<T>
    {
        public abstract void Refresh();
        public abstract void SetList(ICollection<T> items);
        public abstract void SetTree(T root, bool genIds);
        public abstract void ItemRelease(T item);
        public abstract T GetItem(int key);
        public abstract T GetItem(string key);

        public List<T> All { get; set; }
        public T Root { get; set; }
    }

}