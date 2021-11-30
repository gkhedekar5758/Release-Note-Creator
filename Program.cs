using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Runtime.InteropServices;
using System.Collections;
using System.Net;
namespace ConsoleApplication1
{
    class Program
    {
        [DllImport("Microsoft.WITDataStore32.dll", CharSet = CharSet.Unicode)]
        public static extern int hello();
        [STAThread]
        static void Main(string[] args)
        {
            #region classiccode
            // THIS IS CLASSIC ******************************************
            MainLogic mlObj = new MainLogic();
            mlObj.mainMethodd();
            
            // *********************************

            #endregion
            #region trial3
            //int[] numbers = new int[15];
            //numbers[0] = 2571664;
            //numbers[1] = 2814825;
            //numbers[2] = 2872067;
            //numbers[3] = 2849622;
            //numbers[4] = 2316527;
            //numbers[5] = 3111967;
            //numbers[6] = 3115163;
            //numbers[7] = 3129909;
            //numbers[8] = 3147021;
            //numbers[9] = 3188105;
            //numbers[10] = 3180864;
            //numbers[11] = 3199403;
            //numbers[12] = 3224017;
            //numbers[13] = 2809057;
            //numbers[14] = 3377269;

            //TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri("http://alm-prod-app1:8080/tfs/boc_projects"));
            //tpc.EnsureAuthenticated();
            //WorkItemStore item = (WorkItemStore)tpc.GetService(typeof(WorkItemStore));
            //TfsConfigurationServer config = TfsConfigurationServerFactory.GetConfigurationServer(new Uri("http://alm-prod-app1:8080/tfs/boc_projects"));
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    WorkItem WInumber = item.GetWorkItem(numbers[i]);
            //    Console.WriteLine(numbers[i]+"  =  "+WInumber.IterationPath);

            //    Console.WriteLine("*****************************");

            //}



            #endregion
            //     [DllImport("Microsoft.WITDataStore32.dll", CharSet = CharSet.Unicode)]
            #region trail2
            ////TeamFoundationServer tfs = TeamFoundationServerFactory.GetServer("TFSATServer");
            //string bugnumber = Console.ReadLine();

            //// WindowsCredential wincred = new WindowsCredential(cred);

            //TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri("http://alm-prod-app1:8080/tfs/boc_projects"));
            //tpc.EnsureAuthenticated();
            //WorkItemStore item = (WorkItemStore)tpc.GetService(typeof(WorkItemStore));
            //TfsConfigurationServer config = TfsConfigurationServerFactory.GetConfigurationServer(new Uri("http://alm-prod-app1:8080/tfs/boc_projects"));
            //WorkItem number = item.GetWorkItem(Int32.Parse(bugnumber));

            //Console.WriteLine(number.AreaPath);
            //Console.WriteLine(number.Title.ToString());
            //// Console.WriteLine(number.Fields["Target Release"].Value.ToString());
            ////Console.Read();
            ////creating new thing
            //for (int i = 0; i < number.Fields.Count; i++)
            //{
            //    if (number.Fields[i].Value != null) Console.WriteLine((number.Fields[i].Name + "=" + number.Fields[i].Value.ToString()));
            //    Console.WriteLine();
            //}
            ////get the parent
            ////var parentLink=number.WorkItemLinks.Cast<WorkItem>().FirstOrDefault()
            
            //WorkItem parentitem = getParentWorkItemMethod(number, item);


            ////get the parent ends here

            ////Project teampro = item.Projects["SPFM"];
            //TeamProjectPicker pp = new TeamProjectPicker(TeamProjectPickerMode.SingleProject, false);
            //pp.ShowDialog();
            //pp.SelectedTeamProjectCollection.EnsureAuthenticated();
            //WorkItemType wiType = item.Projects[0].WorkItemTypes[10];

            //WorkItem newWI = new WorkItem(wiType);

            //newWI.Title = "Title by GUK";
            //newWI.State = "New";
            ////newWI.IterationPath = "SPFM\\PFM\\17.3\\I19";
            //// newWI.Fields["Team"].Value = "PFM-Fighting Bees";
            //newWI.Fields["Release Note Header"].Value = "guk creating this rnote";
            //newWI.Fields["Release Note"].Value = "thisadoa dfadsf asdfasd";
            //newWI.Fields["Work Item Type"].Value = wiType.Name;
            //newWI.Fields["Area Path"].Value = pp.SelectedTeamProjectCollection.Name.ToString();
            //// newWI.Fields["Area Id"].Value = pp.SelectedTeamProjectCollection.InstanceId.ToString();
            ////pp.SelectedProjects.
            //var a = pp.SelectedProjects;     //information of selected proect
            //foreach (var property in a)
            //{
            //    Console.WriteLine(property.ToString());
            //}
            ////newWI.Fields["Assigned To"].Value = "Khedekar,Gaurang";
            ////newWI.Fields["Team Project"].Value = "SPFM";
            ////newWI.Fields["Area Path"].Value = "SPFM\\PFM\\Regulatory (Optum)\\State Reporting";

            ////newWI.Fields["System.AssignedTo"].Value = "User1";
            //ArrayList aListval = newWI.Validate();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("********************************************************************************");
            //for (int i = 0; i < newWI.Fields.Count; i++)
            //{
            //    if (newWI.Fields[i].Value != null) Console.WriteLine((newWI.Fields[i].Name + "=" + newWI.Fields[i].Value.ToString()));
            //    Console.WriteLine();
            //}

            //// now this is giving error becuase I am landing in first project not SPFM
            //newWI.Save();

            //Console.WriteLine(newWI.Id);

            ////Console.WriteLine(ex.Message); 
            //Console.WriteLine("SAVED SUCCEFUKLLY");
            //Console.Read();
            #endregion

            #region trial1
            //Uri collectionUri = (args.Length < 1) ?
            //        new Uri("http://alm-prod-app1:8080/tfs/boc_projects") : new Uri(args[0]);
            //    TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(collectionUri);
            //    WorkItemStore workItemStore = tpc.GetService<WorkItemStore>();
            //    Project teamProject = workItemStore.Projects["DinnerNow"];
            //   // WorkItemType workItemType = teamProject.WorkItemTypes["User Story"];
            //    WorkItemType WT = teamProject.WorkItemTypes["Release Note"];

            //    // Create the work item. 
            //    WorkItem userStory = new WorkItem(WT)
            //    {
            //        // The title is generally the only required field that doesn’t have a default value. 
            //        // You must set it, or you can’t save the work item. If you’re working with another
            //        // type of work item, there may be other fields that you’ll have to set.
            //        Title = "Recently ordered menu",
            //        Description =
            //            "As a return customer, I want to see items that I've recently ordered."
            //    };

            //    // Save the new user story. 
            //    userStory.Save();
            #endregion
        }

        static WorkItem getParentWorkItemMethod(WorkItem id,WorkItemStore k)
        {
            StringBuilder queryString = new StringBuilder("SELECT [System.Id]" +
                                                  " FROM WorkItemLinks " +
                                                  " WHERE [Source].[System.WorkItemType] = '" + id.Fields["Work Item Type"].Value.ToString()+ "'" +
                                                  //" AND [Source].[System.TeamProject] = '" + TFS_TIMESHEET_PROJECT_KEY + "'" +
                                                  " AND [Source].[System.Id] = " + Convert.ToInt32(          id.Fields["ID"].Value)
                                                  );
            Query wiQuery = new Query(k, queryString.ToString());
           // Query worquery=new Query()
            WorkItemLinkInfo[] wiTrees = wiQuery.RunLinkQuery();
            WorkItem wi = k.GetWorkItem(wiTrees[1].TargetId);

            return wi;
            //return null;
        }
    }
}
