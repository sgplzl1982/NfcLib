// HandleContainer.cs -*-c#-*-
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace com.esp.falplib
{
    /// <summary>
    /// GC除外変数を保持し解放する為のクラス
    /// </summary>
    class HandleContainer
    {
        private List<GCHandle> handleList
            = new List<GCHandle>();

        /// <summary>
        /// 保持変数の追加
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public GCHandle AddPinnedObject(Object obj)
        {
            return GCHandle.Alloc(obj, GCHandleType.Pinned);
        }
        
        /// <summary>
        /// 保持変数の解放
        /// </summary>
        public void FreeHandle()
        {
            foreach (GCHandle handle in handleList)
            {
                if (handle.IsAllocated)
                    handle.Free();
            }
            handleList.Clear();
        }
    }
}