using System.Collections;
using System.Collections.Generic;
using HospitalControl.Exceptions;

namespace HospitalControl
{
    public class HospitalPayable
    {
        private List<IReceiver> _receivers;
        public List<IReceiver> Receivers
        {
            get { return _receivers; }
            set { _receivers = value; }
        }

        public HospitalPayable()
        {
            _receivers = new List<IReceiver>();
        }

        public void AddReceiver(IReceiver receiver)
        {
            if (_receivers.Any(x => x.Id == receiver.Id))
            {
                throw new InvalidSearchException("Este colaborador já existe!");
            }
            _receivers.Add(receiver);
        }

        public void RemoveReceiver(string identification)
        {
            IReceiver receiverToRemove = new IReceiver("");

            foreach (IReceiver receiver in Receivers)
            {
                if (receiver.Id == identification)
                {
                    receiverToRemove = receiver;
                    break;
                }
            }

            if (string.IsNullOrEmpty(receiverToRemove.Id))
            {
                throw new InvalidSearchException("Este colaborador não existe!");
            }

            Receivers.Remove(receiverToRemove);
        }

        public IReceiver SearchReceiver(string identification)
        {
            foreach (IReceiver receiver in _receivers)
            {
                if (receiver.Id == identification)
                {
                    IReceiver searchedReceiver = receiver;
                }
            }

            if (string.IsNullOrEmpty(searchedReceiver.Id))
            {
                throw new InvalidSearchException("Este colaborador não existe!");
            }
            
            return searchedReceiver;
        }
    }
}