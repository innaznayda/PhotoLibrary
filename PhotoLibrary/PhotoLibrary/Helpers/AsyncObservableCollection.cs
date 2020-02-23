using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace PhotoLibrary.Helpers {
    public class AsyncObservableCollection<T> : ObservableCollection<T> {
        private AsyncOperation asyncOp = null;

        public AsyncObservableCollection() {
            CreateAsyncOp();
        }

        public AsyncObservableCollection(IEnumerable<T> list)
            : base(list) {
            CreateAsyncOp();
        }

        private void CreateAsyncOp() {
            asyncOp = AsyncOperationManager.CreateOperation(null);
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e) {
            asyncOp.Post(RaiseCollectionChanged, e);
        }

        private void RaiseCollectionChanged(object param) {
            base.OnCollectionChanged((NotifyCollectionChangedEventArgs)param);
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e) {
            asyncOp.Post(RaisePropertyChanged, e);
        }

        private void RaisePropertyChanged(object param) {
            base.OnPropertyChanged((PropertyChangedEventArgs)param);
        }
    }
}
