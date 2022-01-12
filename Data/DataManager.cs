using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using UIBlazor.Services;
using UIBlazor.Models.SharedTablesModel;
using UIBlazor.Models;
using UIBlazor.Models.ApplicationModel;
using UIBlazor.SharedTables.Data;
using UIBlazor.Data.ApplicationsToIT;
using UIBlazor.Data.Mongo;


namespace UIBlazor.Data
{

    public class DataManager
    {
        public BuildingsManager BuildingsManager { get; set; }
        public DepartamentManager DepartamentsManager { get; set; }
        public EmployeeManager EmployeesManager { get; set; }
        public PositionManager PositionsManager { get; set; }
        public RoomManager RoomsManager { get; set; }
        public SubdivisionManager SubdivisionsManager { get; set; }
        public ApplicationToITDataManager ApplicationsTOITDataManager { get; set; }
        public ApplicationPriorityManager ApplicationPrioritysManager { get; set; }
        public ApplicationStateManager ApplicationStatesManager{ get; set; }
        public ApplicationTypeManager ApplicationTypesManager{ get; set; }
        public MongoManager MongoDbManager { get; set; }
        public ActionManager ActionManager { get; set; }
        //public RoleManager RoleManager { get; set; }

        private readonly HttpClient _client;
        private readonly string serverAddres = "https://localhost:7001";



        public DataManager(HttpClient client, TokenProvider tokenProvider)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (tokenProvider == null) throw new ArgumentNullException(nameof(tokenProvider));

            _client = client;
            _client.BaseAddress = new Uri(serverAddres);
            _client.DefaultRequestHeaders.Add("Accept", "*text/plain*");
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer " + tokenProvider.AccessToken);

            BuildingsManager = new BuildingsManager(_client);
            DepartamentsManager = new DepartamentManager(_client);
            EmployeesManager = new EmployeeManager(_client);
            PositionsManager = new PositionManager(_client);
            RoomsManager = new RoomManager(_client);
            SubdivisionsManager = new SubdivisionManager(_client);
            //RoleManager = new RoleManager(_client);

            ApplicationsTOITDataManager = new ApplicationToITDataManager(_client);
            ApplicationPrioritysManager = new ApplicationPriorityManager(_client);
            ApplicationStatesManager = new ApplicationStateManager(_client);
            ApplicationTypesManager = new ApplicationTypeManager(_client);
            ActionManager = new ActionManager(_client);

            MongoDbManager = new MongoManager(_client);
        }
    }
}
