using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Avalonia.Terminal.Helpers
{
    internal static class IEnumerableExtension
    {
        extension<T>(IEnumerable<T> collection)
        {
            public ObservableCollection<T> ToObservable()
            {
                return new ObservableCollection<T>(collection);
            }
        }
    }
}
