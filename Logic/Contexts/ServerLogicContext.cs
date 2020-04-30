using Data.Api;
using Data.Contexts;
using Data.Model;
using Logic.Api;
using Logic.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Contexts
{
    public class ServerLogicContext : ServerLogicLayer
    {
        private ServerDataLayer _serverDataContext;
        private IdGenerator _idGenerator;

        public ServerLogicContext()
        {
            _serverDataContext = new ServerDataContext();
            _idGenerator = new IdGenerator();
        }

        public ServerLogicContext(ServerDataLayer serverDataContext)
        {
            _serverDataContext = serverDataContext;
            _idGenerator = new IdGenerator();
        }

        public ClientDto SendClientInfo(string id)
        {
            return _serverDataContext.SendClientInfo(id).ToDto();
        }

        public List<MerchandiseDto> SendMerchandises()
        {
            return _serverDataContext.SendMerchandises().ToDto();
        }

        public OrderDto SendOrder(string id)
        {
            return _serverDataContext.SendOrder(id).ToDto();
        }

        public string SaveOrder(OrderDto orderDto)
        {
            string clientResult = "";

            try
            {
                ClientContactInfo clientInfo = _serverDataContext.SendClientInfo(orderDto.ClientInfo.Id);
            }
            catch (KeyNotFoundException e)
            {
                ClientContactInfo newClientInfo = orderDto.ClientInfo.FromDto();
                newClientInfo.Id = _idGenerator.GetNextClientId();
                clientResult = _serverDataContext.SaveClientInfo(newClientInfo);
            }
            catch (Exception e)
            {
                throw new Exception("Some error occured");
            }

            string result = clientResult + " " + _serverDataContext.SaveOrder(orderDto.FromDto());

            return result;
        }

        public string CloseOrder(string id, DateTime dateTime)
        {
            string result = _serverDataContext.CloseOrder(id, dateTime);

            return result;
        } 
    }
}
