using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
namespace Defence
{
    public interface ObjectPool<T>
    {
        T BorrowObject();
    }
}
