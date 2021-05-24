using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class GameEvent
    {
        protected List<IListener> listeners = new List<IListener>();
        public string Title { get; private set; }

        public GameEvent(string title)
        {
            Title = title;
        }

        public void Attach(IListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void Detach(IListener listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }

        public void Notify()
        {
            foreach (IListener listener in listeners)
            {
                listener.OnNotify(this);
            }
        }
    }
}
