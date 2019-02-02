using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxUWP.Disposable {
    public class DisposeBag : IDisposable { 

        #region Fields

        /// <summary>
        /// List of IDisposable instance.
        /// </summary>
        private List<IDisposable> Bag = new List<IDisposable>();

        #endregion


        #region Method

        /// <summary>
        /// Disposes the observer, causing it to transition to the stopped step.
        /// </summary>
        public void Dispose() {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


        /// <summary>
        ///  Core implementation of <see cref="IDisposable"/>
        /// </summary>
        /// <param name="disposing"><c>true</c> if the Dispose call was triggered by the <see cref="IDisposable.Dispose"/> method; <c>false</c> if it was triggered by the finalizer.</param>
        public void Dispose(bool disposing) {
            if(disposing) {
                this.Bag.ForEach(obj => {
                    try {
                        obj.Dispose();
                    } catch {

                    }
                });
                this.Bag.Clear();

#if DEBUG
                Debug.WriteLine("DisposeBag done");
#endif
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">IDisposable object</param>
        public void Collect(IDisposable obj) {
            this.Bag.Add(obj);
        }

        #endregion
    }
}
