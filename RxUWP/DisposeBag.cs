using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxUWP {
    public class DisposeBag : IDisposable {

        /// <summary>
        /// Disposeメソッド
        /// </summary>
        public void Dispose() {
            this.Bag.ForEach(obj => {
                try {
                    obj.Dispose();
                } catch {
#if DEBUG
                    Debug.WriteLine("Dispose処理に失敗しました。");
#endif
                }
            });
            this.Bag.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">IDisposable object</param>
        public void Collect(IDisposable obj) {
            this.Bag.Add(obj);
        }

        /// <summary>
        /// IDisposeインスタンスを格納する 
        /// </summary>
        private List<IDisposable> Bag = new List<IDisposable>();
    }
}
