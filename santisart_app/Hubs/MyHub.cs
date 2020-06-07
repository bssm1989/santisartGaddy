using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using santisart_app.Models;

namespace santisart_app.Hubs
{
    public class MyHub:Hub
    {
        public void Sendmsg(string txt, String who)
        {
            try
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                context.Clients.All.callreturn(txt);
                //UserHubModels modeltemp = DataRepository.UserHubModelsList.Where(w => w.UserName.Equals(who)).FirstOrDefault(); 
                //if (modeltemp != null)
                //{
                    //var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                    //context.Clients.Client(modeltemp.ConnectionIds).callreturn(txt);

                //}

            }
            catch (Exception ex)
            {

                ex.ToString();
            }
        }
        public void setID(string who)
        {
            if (DataRepository.UserHubModelsList == null)
            {
                DataRepository.UserHubModelsList = new List<UserHubModels>();

            }
            UserHubModels model = new UserHubModels(); 
            model.UserName = who; model.ConnectionIds = Context.ConnectionId;
            UserHubModels modeltemp = DataRepository.UserHubModelsList.Where(w => w.UserName.Equals(model.UserName) || w.ConnectionIds.Equals(model.ConnectionIds)).FirstOrDefault(); 
            if (modeltemp == null)
            {

                DataRepository.UserHubModelsList.Add(model);
            }
            else
            {
                DataRepository.UserHubModelsList.Remove(modeltemp); 
            DataRepository.UserHubModelsList.Add(model);

            }


        }

        public override Task OnConnected()
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;
            return base.OnDisconnected(stopCalled);
        }
    }

}